# Contributing & Publishing Guide

So you've cloned the repo. Here's how to get from a fresh checkout to a published NuGet package.

## Prerequisites

You'll need Visual Studio 2022 (17.8+) with the **.NET desktop development** and **Windows App SDK** workloads installed. Make sure you have the .NET 8 SDK — you can verify with `dotnet --version`. You'll also need a NuGet.org account; if you don't have one, create it at nuget.org and generate an API key under your profile with the "Push" scope.

## Building Locally

Open a terminal at the repo root and restore + build:

```sh
dotnet restore MonacoEditor.WinUI3.sln
dotnet build src/MonacoEditor.WinUI3/MonacoEditor.WinUI3.csproj -c Release -p:Platform=x64
```

If you want to test the sample app first, open the `.sln` in Visual Studio, set `MonacoEditor.WinUI3.Sample` as the startup project, pick x64, and hit F5. Confirm the editor loads and two-way binding works before packaging.

## Updating the Version

Before packing, bump the version in `src/MonacoEditor.WinUI3/MonacoEditor.WinUI3.csproj`. Find the `<Version>` tag and update it following semver — for example, `1.0.0` → `1.1.0` for new features, or `1.0.1` for a bugfix.

## Creating the NuGet Package

From the repo root:

```sh
dotnet pack src/MonacoEditor.WinUI3/MonacoEditor.WinUI3.csproj -c Release -o ./artifacts
```

This produces `artifacts/MonacoEditor.WinUI3.<version>.nupkg`. You can inspect it by renaming it to `.zip` and opening it, or using NuGet Package Explorer if you want to verify the embedded `index.html`, the `Themes/Generic.xaml`, and the `README.md` are all included.

## Testing the Package Locally

Before pushing to nuget.org, test the package against a fresh project. Create a local feed:

```sh
dotnet nuget add source ./artifacts --name LocalTest
```

Then create a throwaway WinUI 3 app, add the package from that local source, drop in a `<monaco:MonacoEditorControl Text="{x:Bind ...}" />`, and confirm everything works end to end. Remove the local source when you're done:

```sh
dotnet nuget remove source LocalTest
```

## Publishing to NuGet.org

Once you're confident the package is solid:

```sh
dotnet nuget push ./artifacts/MonacoEditor.WinUI3.*.nupkg --api-key YOUR_API_KEY --source https://api.nuget.org/v3/index.json
```

The package typically appears on nuget.org within a few minutes, though indexing for search can take up to an hour. If you're re-publishing the same version, NuGet will reject it — versions are immutable, so bump the version number first.

## Publishing via CI (GitHub Actions)

The repo includes `.github/workflows/build.yml` which automates this. To enable it, add your NuGet API key as a repository secret named `NUGET_API_KEY` (Settings → Secrets and variables → Actions → New repository secret). Then create a GitHub Release — the workflow triggers on `release: published`, builds all three platforms, packs, and pushes to nuget.org automatically. Tag your release with the version number (e.g. `v1.1.0`) to keep things tidy.

## Keeping Monaco Up to Date

Run the update script before a release to make sure you're shipping the latest editor:

```powershell
Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass
.\scripts\Update-Monaco.ps1
```

Or let the weekly GitHub Actions workflow handle it — it opens a PR automatically when a new Monaco version is available. Merge the PR, bump your package version, and publish.

## Bundling Monaco into the NuGet Package

By default, Monaco is **not** committed to the repo. The control falls back to loading it from the jsDelivr CDN at runtime (you'll see a warning in the WebView2 DevTools console and in the VS Output window if `MonacoBaseUrl` is unset). This is fine for development but is unsuitable for offline or store-distributed apps.

To bundle Monaco into the NuGet package:

**Step 1 — Download Monaco locally:**

```powershell
.\scripts\Update-Monaco.ps1
```

This downloads the minified Monaco distribution to `src/MonacoEditor.WinUI3/Web/monaco/`. The `.csproj` already includes `Web\**\*` as both an `EmbeddedResource` and a NuGet `contentFile`, so no project file changes are needed.

**Step 2 — Verify the files are present:**

Confirm that `src/MonacoEditor.WinUI3/Web/monaco/vs/loader.js` exists before packing.

**Step 3 — Pack and verify:**

```sh
dotnet pack src/MonacoEditor.WinUI3/MonacoEditor.WinUI3.csproj -c Release -o ./artifacts
```

Rename the resulting `.nupkg` to `.zip` and open it. You should see `contentFiles/any/any/MonacoWeb/monaco/vs/` inside the archive.

**Step 4 — Configure the control in the consuming app:**

The NuGet contentFiles are deployed to the consuming app's output directory under `MonacoWeb/`. Point the control at them using a virtual host mapping in your app's startup code:

```csharp
// In your WebView2 setup (e.g. after EnsureCoreWebView2Async):
var monacoFolder = System.IO.Path.Combine(
    System.AppContext.BaseDirectory, "MonacoWeb", "monaco");

webView.CoreWebView2.SetVirtualHostNameToFolderMapping(
    "monaco-local.editor", monacoFolder,
    CoreWebView2HostResourceAccessKind.Allow);
```

Then set the property on the control:

```xml
<monaco:MonacoEditorControl MonacoBaseUrl="https://monaco-local.editor" ... />
```

When `MonacoBaseUrl` is set the debug warnings disappear — both the `console.warn` in the browser console and the `Debug.WriteLine` in the VS Output window.

> **Note:** Committing `Web/monaco/` is optional. For CI, add `.\scripts\Update-Monaco.ps1` as a build step before `dotnet pack`. The weekly automation PR already does this.

## Checklist Before Every Release

1. Monaco is up to date (run `Update-Monaco.ps1` or merge the automated PR)
2. Version is bumped in the `.csproj`
3. README reflects any API changes
4. Local build passes on x64
5. Sample app runs and two-way binding works
6. Local package test succeeds against a clean project
7. Commit, tag, push, create a GitHub Release (or `dotnet nuget push` manually)

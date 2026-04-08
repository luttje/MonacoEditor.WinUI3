# MonacoEditor.WinUI3

A NuGet package that wraps the [Monaco Editor](https://microsoft.github.io/monaco-editor/) (the code editor that powers VS Code) as a native **WinUI 3** control using **WebView2**. Drop it into any WinUI 3 app and get a full-featured code editor with **two-way data binding**, IntelliSense, syntax highlighting for 70+ languages, and theming — all in one XAML tag.

## Features

- **Two-way `Text` binding** — bind the editor content to your ViewModel with `{x:Bind Text, Mode=TwoWay}`
- **Dependency properties** — `Text`, `EditorLanguage`, `EditorTheme`, `IsReadOnly`, `MonacoBaseUrl`
- **Rich async API** — `GetTextAsync`, `InsertTextAtCursorAsync`, `GetSelectedTextAsync`, `SetCursorPositionAsync`, `TriggerActionAsync`, and more
- **Events** — `EditorReady`, `TextChanged`
- **Automatic layout** — the editor resizes with its container
- **CDN or local** — loads Monaco from jsDelivr CDN by default, or bundle files locally
- **Automated updates** — GitHub Actions workflow + PowerShell script to pull the latest Monaco release

## Quick Start

### 1. Install

```
dotnet add package MonacoEditor.WinUI3
```

Or via NuGet Package Manager in Visual Studio, search for `MonacoEditor.WinUI3`.

### 2. Add the namespace

```xml
<Window
    xmlns:monaco="using:MonacoEditor.WinUI3"
    ...>
```

### 3. Use the control

```xml
<monaco:MonacoEditorControl
    Text="{x:Bind MyCode, Mode=TwoWay}"
    EditorLanguage="csharp"
    EditorTheme="vs-dark" />
```

That's it. The editor loads Monaco from the CDN, initializes, and keeps `MyCode` in sync.

## Full Example (MVVM)

```xml
<Page
    xmlns:monaco="using:MonacoEditor.WinUI3">

    <Grid RowDefinitions="*,Auto">
        <monaco:MonacoEditorControl
            Text="{x:Bind ViewModel.SourceCode, Mode=TwoWay}"
            EditorLanguage="{x:Bind ViewModel.Language, Mode=OneWay}"
            EditorTheme="{x:Bind ViewModel.Theme, Mode=OneWay}"
            IsReadOnly="{x:Bind ViewModel.IsReadOnly, Mode=OneWay}"
            EditorReady="OnEditorReady"
            TextChanged="OnTextChanged" />

        <TextBlock Grid.Row="1"
                   Text="{x:Bind ViewModel.StatusMessage, Mode=OneWay}"
                   Padding="12,6" />
    </Grid>
</Page>
```

```csharp
public partial class EditorViewModel : ObservableObject
{
    [ObservableProperty] private string sourceCode = "// Hello, Monaco!";
    [ObservableProperty] private string language = "javascript";
    [ObservableProperty] private string theme = "vs-dark";
    [ObservableProperty] private bool isReadOnly = false;
    [ObservableProperty] private string statusMessage = "";
}
```

## API Reference

### Dependency Properties

| Property | Type | Default | Description |
|---|---|---|---|
| `Text` | `string` | `""` | Full editor content. Supports two-way binding. |
| `EditorLanguage` | `string` | `"plaintext"` | Language mode for syntax highlighting. |
| `EditorTheme` | `string` | `"vs"` | Visual theme: `vs`, `vs-dark`, `hc-black`, `hc-light`. |
| `IsReadOnly` | `bool` | `false` | Toggle read-only mode. |
| `MonacoBaseUrl` | `string?` | `null` | Override the Monaco source URL (CDN or local path). |

### Events

| Event | Args | Description |
|---|---|---|
| `EditorReady` | `EventArgs` | Fired once when the editor is fully loaded and interactive. |
| `TextChanged` | `MonacoTextChangedEventArgs` | Fired on each user-initiated content change. `e.Text` contains the full text. |

### Async Methods

```csharp
// Get/set text
Task<string> GetTextAsync()

// Editor options (pass any Monaco IEditorOptions as JSON)
Task SetOptionsAsync(string optionsJson)

// Cursor & selection
Task<(int Line, int Column)> GetCursorPositionAsync()
Task SetCursorPositionAsync(int lineNumber, int column)
Task<string> GetSelectedTextAsync()
Task InsertTextAtCursorAsync(string text)

// Focus & actions
Task FocusEditorAsync()
Task TriggerActionAsync(string actionId)
```

### Example: Trigger Format Document

```csharp
await Editor.TriggerActionAsync("editor.action.formatDocument");
```

### Example: Custom Editor Options

```csharp
await Editor.SetOptionsAsync("""
{
    "fontSize": 16,
    "minimap": { "enabled": false },
    "lineNumbers": "relative",
    "wordWrap": "bounded",
    "wordWrapColumn": 100
}
""");
```

## How It Works

The architecture is simple and robust:

```txt
┌─────────────────────────────────────┐
│          WinUI 3 Application        │
│                                     │
│   ┌─────────────────────────────┐   │
│   │   MonacoEditorControl       │   │
│   │   (TemplatedControl)        │   │
│   │                             │   │
│   │   DP: Text ←──TwoWay──→ VM  │   │
│   │   DP: Language, Theme, ...  │   │
│   │                             │   │
│   │   ┌─────────────────────┐   │   │
│   │   │     WebView2        │   │   │
│   │   │                     │   │   │
│   │   │  ┌───────────────┐  │   │   │
│   │   │  │ Monaco Editor │  │   │   │
│   │   │  │  (index.html) │  │   │   │
│   │   │  └───────────────┘  │   │   │
│   │   └─────────────────────┘   │   │
│   └─────────────────────────────┘   │
└─────────────────────────────────────┘

  C# → JS:  ExecuteScriptAsync("setText(...)")
  JS → C#:  chrome.webview.postMessage({ type, text })
```

- **C# to JavaScript**: The control calls `ExecuteScriptAsync` to invoke functions defined in the hosted HTML page (`setText`, `setLanguage`, `setTheme`, etc.)
- **JavaScript to C#**: Monaco's `onDidChangeModelContent` event triggers `postMessage` back to the C# `WebMessageReceived` handler, which updates the `Text` dependency property
- **Echo suppression**: A flag prevents infinite update loops when the binding updates flow in both directions

## Updating Monaco Editor

### Manual (PowerShell)

From the repository root:

```powershell
# Update to latest
.\scripts\Update-Monaco.ps1

# Update to a specific version
.\scripts\Update-Monaco.ps1 -Version "0.55.1"

# CDN-only (just update the fallback URL, don't download files)
.\scripts\Update-Monaco.ps1 -CdnOnly
```

### Automated (GitHub Actions)

The repository includes `.github/workflows/update-monaco.yml` which:

1. **Runs weekly** (Monday 08:00 UTC) or on manual trigger
2. Queries npm for the latest stable `monaco-editor` version
3. Compares against the version in `index.html`
4. If newer: runs `Update-Monaco.ps1` and opens a **pull request**

To enable:

- Ensure the `GITHUB_TOKEN` has PR creation permissions (default in most repos)
- Optionally pin to a specific version via manual workflow dispatch

## Loading Modes

### CDN (default, zero config)

Monaco loads from `cdn.jsdelivr.net`. Nothing to download or bundle. The control works immediately after installation.

### Local / Bundled

1. Run `.\scripts\Update-Monaco.ps1` to download Monaco into `src/MonacoEditor.WinUI3/Web/monaco/`
2. Set `MonacoBaseUrl` on the control:

```xml
<monaco:MonacoEditorControl
    MonacoBaseUrl="monaco"
    ... />
```

1. The files are embedded in the NuGet package via `<EmbeddedResource>`

### Custom CDN / Self-hosted

Point to any URL that hosts the Monaco `min/vs` directory:

```xml
<monaco:MonacoEditorControl
    MonacoBaseUrl="https://my-cdn.example.com/monaco/0.55.1/min"
    ... />
```

## Requirements

- **.NET 8** or **.NET 9** (multi-targeted)
- **Windows App SDK 1.8+** (WinUI 3)
- **WebView2 Runtime** (ships with Windows 11; auto-installs with Edge on Windows 10)
- **Windows 10 version 1809** (build 17763) or later

## Contributing

1. Fork and clone
2. Open `MonacoEditor.WinUI3.sln` in Visual Studio 2022+
3. Set `MonacoEditor.WinUI3.Sample` as the startup project
4. Build and run (x64)

PRs welcome — especially for additional Monaco API surface, accessibility improvements, and testing.

## License

This project is MIT licensed, see [LICENSE](LICENSE).

Monaco Editor itself is licensed under the [MIT License](https://github.com/microsoft/monaco-editor/blob/main/LICENSE.md) by Microsoft.

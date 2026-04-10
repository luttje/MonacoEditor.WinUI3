# MonacoEditor.WinUI3

[![GitHub License](https://img.shields.io/github/license/luttje/MonacoEditor.WinUI3)](https://github.com/luttje/MonacoEditor.WinUI3/blob/main/LICENSE)
[![NuGet Version](https://img.shields.io/nuget/vpre/MonacoEditor.WinUI3)](https://www.nuget.org/packages/MonacoEditor.WinUI3)
[![GitHub Actions Workflow Status](https://img.shields.io/github/actions/workflow/status/luttje/MonacoEditor.WinUI3/test.yml?label=tests)](https://github.com/luttje/MonacoEditor.WinUI3/actions/workflows/test.yml)

A NuGet package that wraps the [Monaco Editor](https://microsoft.github.io/monaco-editor/) (the code editor that powers VS Code) as a **WinUI 3** control using **WebView2**. Drop it into any WinUI 3 app and get a full-featured code editor with **two-way data binding**, IntelliSense, syntax highlighting for 70+ languages, and theming.

## Features

- **Two-way `Text` binding**: bind the editor content to your ViewModel with `{x:Bind Text, Mode=TwoWay}`
- **Rich async API**: `GetTextAsync`, `InsertTextAtCursorAsync`, `GetSelectedTextAsync`, `SetCursorPositionAsync`, `TriggerActionAsync`, and more
- **Events**: `EditorReady`, `TextChanged`
- **Automatic layout**: the editor resizes with its container
- **Bundled by default**: Monaco files are included in the package; no internet connection required. CDN loading is available as an opt-in.

## Quick Start

### 1. Install

```sh
dotnet add package MonacoEditor.WinUI3 --prerelease
```

Or via NuGet Package Manager in Visual Studio, search for `MonacoEditor.WinUI3`.

 > [!IMPORTANT]
> `--prerelease` is required when installing this package. The Monaco Editor version is encoded in the prerelease tag of the package version. When using NuGet, make sure to enable **Include Prerelease** to see and install this package.

### 2. Add the namespace

To your Window or Page XAML open tag, add `xmlns:monaco="using:MonacoEditor.WinUI3"`:

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

That's it. The editor loads Monaco from bundled local files.

## Full Example (MVVM)

```xml
<Page xmlns:monaco="using:MonacoEditor.WinUI3">
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="*" />
            <RowDefinition Height="Auto" />
        </Grid.RowDefinitions>
        
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
    [ObservableProperty] 
    public partial string SourceCode { get; set; } = "// Hello, Monaco!";
    [ObservableProperty] 
    public partial string Language { get; set; } = "javascript";
    [ObservableProperty] 
    public partial string Theme { get; set; } = "vs-dark";
    [ObservableProperty] 
    public partial bool IsReadOnly { get; set; } = false;
    [ObservableProperty] 
    public partial string StatusMessage { get; set; } = "";
}
```

## API Reference

### Properties

| Property | Type | Default | Description |
| --- | --- | --- | --- |
| `Text` | `string` | `""` | Full editor content. Supports two-way binding. |
| `EditorLanguage` | `string` | `"plaintext"` | Language mode for syntax highlighting. |
| `EditorTheme` | `string` | `"vs"` | Visual theme: `vs`, `vs-dark`, `hc-black`, `hc-light`. |
| `IsReadOnly` | `bool` | `false` | Toggle read-only mode. |
| `MonacoBaseUrl` | `string?` | `null` | Override the Monaco source URL. Set to a CDN URL to load remotely instead of using bundled files. |

### Events

| Event | Args | Description |
| --- | --- | --- |
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

## Loading Modes

### Bundled (default, zero config)

Monaco is bundled with the NuGet package and loaded from local files. No internet connection is needed, which is ideal for desktop and store-distributed apps.

### CDN / Self-hosted

To load Monaco from a CDN or self-hosted URL instead of the bundled files, set `MonacoBaseUrl` explicitly:

```xml
<monaco:MonacoEditorControl
    MonacoBaseUrl="https://cdn.jsdelivr.net/npm/monaco-editor@0.55.1/min"
    ... />
```

This requires an internet connection at runtime.

## Requirements

- **.NET 8** or **.NET 9** (multi-targeted)
- **Windows App SDK 1.8+** (WinUI 3)
- **WebView2 Runtime** (ships with Windows 11; auto-installs with Edge on Windows 10)
- **Windows 10 version 1809** (build 17763) or later

## License

This project is MIT licensed, see [LICENSE](https://github.com/luttje/MonacoEditor.WinUI3/blob/main/LICENSE).

Monaco Editor itself is licensed under the [MIT License](https://github.com/microsoft/monaco-editor/blob/main/LICENSE.md) by Microsoft.

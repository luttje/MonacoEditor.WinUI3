using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.Web.WebView2.Core;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

namespace MonacoEditor.WinUI3;

/// <summary>
/// A WinUI 3 control that hosts the Monaco Editor (VS Code's editor engine)
/// inside a WebView2 control. Supports two-way text binding via the
/// <see cref="Text"/> dependency property.
/// </summary>
[TemplatePart(Name = PartWebView, Type = typeof(WebView2))]
public sealed partial class MonacoEditorControl : Control
{
    private const string PartWebView = "PART_WebView";

    private WebView2? _webView;
    private bool _isEditorReady;
    private bool _isSuppressingTextChange;
    private string? _pendingText;
    private string? _pendingLanguage;
    private string? _pendingTheme;
    private bool? _pendingReadOnly;
    private string? _pendingOptions;
    private bool _hasShownWebView;

    /// <summary>Raised when the Monaco editor has finished loading and is ready.</summary>
    public event EventHandler? EditorReady;

    /// <summary>Raised when the text content changes inside the editor (user-initiated).</summary>
    public event EventHandler<MonacoTextChangedEventArgs>? TextChanged;

    #region Text (two-way bindable)

    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register(
            nameof(Text),
            typeof(string),
            typeof(MonacoEditorControl),
            new PropertyMetadata(string.Empty, OnTextPropertyChanged)
        );

    /// <summary>
    /// Gets or sets the full text content of the editor.
    /// This property supports two-way binding.
    /// </summary>
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    private static void OnTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is MonacoEditorControl control && !control._isSuppressingTextChange)
        {
            control.PushTextToEditor((string)e.NewValue);
        }
    }

    #endregion

    #region EditorLanguage

    public static readonly DependencyProperty EditorLanguageProperty =
        DependencyProperty.Register(
            nameof(EditorLanguage),
            typeof(string),
            typeof(MonacoEditorControl),
            new PropertyMetadata("plaintext", OnEditorLanguagePropertyChanged)
        );

    /// <summary>
    /// Gets or sets the language mode (e.g. "javascript", "csharp", "json").
    /// Named EditorLanguage to avoid hiding FrameworkElement.Language.
    /// </summary>
    public string EditorLanguage
    {
        get => (string)GetValue(EditorLanguageProperty);
        set => SetValue(EditorLanguageProperty, value);
    }

    private static void OnEditorLanguagePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is MonacoEditorControl control)
        {
            control.PushLanguageToEditor((string)e.NewValue);
        }
    }

    #endregion

    #region EditorTheme

    public static readonly DependencyProperty EditorThemeProperty =
        DependencyProperty.Register(
            nameof(EditorTheme),
            typeof(string),
            typeof(MonacoEditorControl),
            new PropertyMetadata("vs", OnEditorThemePropertyChanged)
        );

    /// <summary>
    /// Gets or sets the editor theme ("vs", "vs-dark", "hc-black", "hc-light").
    /// </summary>
    public string EditorTheme
    {
        get => (string)GetValue(EditorThemeProperty);
        set => SetValue(EditorThemeProperty, value);
    }

    private static void OnEditorThemePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is MonacoEditorControl control)
        {
            control.PushThemeToEditor((string)e.NewValue);
        }
    }

    #endregion

    #region IsReadOnly

    public static readonly DependencyProperty IsReadOnlyProperty =
        DependencyProperty.Register(
            nameof(IsReadOnly),
            typeof(bool),
            typeof(MonacoEditorControl),
            new PropertyMetadata(false, OnIsReadOnlyPropertyChanged)
        );

    /// <summary>
    /// Gets or sets whether the editor is read-only.
    /// </summary>
    public bool IsReadOnly
    {
        get => (bool)GetValue(IsReadOnlyProperty);
        set => SetValue(IsReadOnlyProperty, value);
    }

    private static void OnIsReadOnlyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is MonacoEditorControl control)
        {
            control.PushReadOnlyToEditor((bool)e.NewValue);
        }
    }

    #endregion

    #region MonacoBaseUrl

    public static readonly DependencyProperty MonacoBaseUrlProperty =
        DependencyProperty.Register(
            nameof(MonacoBaseUrl),
            typeof(string),
            typeof(MonacoEditorControl),
            new PropertyMetadata(null)
        );

    /// <summary>
    /// Optional override for the Monaco Editor base URL. If null, the bundled
    /// local files are used. Set to a CDN URL to load Monaco from a remote source.
    /// </summary>
    public string? MonacoBaseUrl
    {
        get => (string?)GetValue(MonacoBaseUrlProperty);
        set => SetValue(MonacoBaseUrlProperty, value);
    }

    #endregion

    public MonacoEditorControl()
    {
        DefaultStyleKey = typeof(MonacoEditorControl);
    }

    protected override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        _webView = GetTemplateChild(PartWebView) as WebView2;
        if (_webView is not null)
        {
            _webView.NavigationCompleted += OnNavigationCompleted;
            _webView.WebMessageReceived += OnWebMessageReceived;
            _ = InitializeAsync();
        }
    }

    private async Task InitializeAsync()
    {
        if (_webView is null)
            return;

        try
        {
            await _webView.EnsureCoreWebView2Async();

            if (!string.IsNullOrEmpty(MonacoBaseUrl) &&
                (MonacoBaseUrl.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                 MonacoBaseUrl.StartsWith("https://", StringComparison.OrdinalIgnoreCase)))
            {
                // Absolute URL (CDN or self-hosted) — inject as-is
                await _webView.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync(
                    $"window.__MONACO_BASE_URL__ = '{EscapeJs(MonacoBaseUrl)}';");
            }
            else
            {
                // Local path: use explicit relative path or default to "monaco"
                var relativePath = string.IsNullOrEmpty(MonacoBaseUrl) ? "monaco" : MonacoBaseUrl;
                var assemblyDir = Path.GetDirectoryName(typeof(MonacoEditorControl).Assembly.Location) ?? ".";
                var monacoPath = Path.GetFullPath(Path.Combine(assemblyDir, relativePath));

                if (!Directory.Exists(monacoPath))
                {
                    // NuGet content files are placed under MonacoWeb/ in the output directory
                    monacoPath = Path.GetFullPath(Path.Combine(assemblyDir, "MonacoWeb", relativePath));
                }

                if (Directory.Exists(monacoPath))
                {
                    const string virtualHost = "monacoeditor-assets.local";
                    _webView.CoreWebView2.SetVirtualHostNameToFolderMapping(
                        virtualHost,
                        monacoPath,
                        Microsoft.Web.WebView2.Core.CoreWebView2HostResourceAccessKind.Allow);

                    await _webView.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync(
                        $"window.__MONACO_BASE_URL__ = 'https://{virtualHost}';");
                }
                else
                {
                    Trace.WriteLine(
                        $"[MonacoEditor.WinUI3] ERROR: Bundled Monaco files not found. " +
                        "Run scripts/Update-Monaco.ps1 to download Monaco files, or set MonacoBaseUrl " +
                        "to a CDN URL (e.g. \"https://cdn.jsdelivr.net/npm/monaco-editor@0.55.1/min\").");
                }
            }

            // Pre-apply theme background to prevent FOUC
            var initialTheme = EditorTheme ?? "vs";
            await _webView.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync(
                $"document.addEventListener('DOMContentLoaded', () => {{ applyThemeBackground('{EscapeJs(initialTheme)}'); }});");

            // Load the embedded HTML
            var html = LoadEmbeddedHtml();
            _webView.NavigateToString(html);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"[MonacoEditor] Init error: {ex}");
        }
    }

    private static string LoadEmbeddedHtml()
    {
        var assembly = typeof(MonacoEditorControl).Assembly;
        var resourceName = "MonacoEditor.WinUI3.Web.index.html";

        using var stream = assembly.GetManifestResourceStream(resourceName);

        if (stream is null)
        {
            // Fallback: try to load from disk next to the assembly
            var dir = Path.GetDirectoryName(assembly.Location) ?? ".";
            var filePath = Path.Combine(dir, "MonacoWeb", "index.html");

            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath);
            }

            throw new FileNotFoundException(
                $"Could not find embedded resource '{resourceName}' or file '{filePath}'.");
        }

        using var reader = new StreamReader(stream);

        return reader.ReadToEnd();
    }

    private void OnNavigationCompleted(WebView2 sender, CoreWebView2NavigationCompletedEventArgs args)
    {
        // The page is loaded; editor "ready" is signaled via postMessage
    }

    private void OnWebMessageReceived(WebView2 sender, CoreWebView2WebMessageReceivedEventArgs args)
    {
        try
        {
            var json = args.TryGetWebMessageAsString();

            if (string.IsNullOrEmpty(json))
                return;

            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;

            if (!root.TryGetProperty("type", out var typeProp))
                return;

            var type = typeProp.GetString();

            switch (type)
            {
                case "ready":
                    HandleEditorReady();
                    break;
                case "contentChanged":
                    if (root.TryGetProperty("text", out var textProp))
                    {
                        HandleContentChanged(textProp.GetString() ?? string.Empty);
                    }
                    break;
            }
        }
        catch (JsonException ex)
        {
            Debug.WriteLine($"[MonacoEditor] Message error: {ex}");
        }
    }

    private void HandleEditorReady()
    {
        _isEditorReady = true;

        // Show the WebView now that the editor is ready and themed
        if (!_hasShownWebView && _webView is not null)
        {
            _hasShownWebView = true;
            DispatcherQueue.TryEnqueue(() =>
            {
                _webView.Visibility = Visibility.Visible;
            });
        }

        // Flush any pending state
        if (_pendingText is not null)
            PushTextToEditor(_pendingText);

        if (_pendingLanguage is not null)
            PushLanguageToEditor(_pendingLanguage);

        if (_pendingTheme is not null)
            PushThemeToEditor(_pendingTheme);

        if (_pendingReadOnly is not null)
            PushReadOnlyToEditor(_pendingReadOnly.Value);

        if (_pendingOptions is not null)
            _ = SetOptionsAsync(_pendingOptions);

        _pendingText = null;
        _pendingLanguage = null;
        _pendingTheme = null;
        _pendingReadOnly = null;
        _pendingOptions = null;

        EditorReady?.Invoke(this, EventArgs.Empty);
    }

    private void HandleContentChanged(string text)
    {
        // Update the dependency property without echoing back to JS
        _isSuppressingTextChange = true;
        Text = text;
        _isSuppressingTextChange = false;

        TextChanged?.Invoke(this, new MonacoTextChangedEventArgs(text));
    }

    private async void PushTextToEditor(string text)
    {
        if (!_isEditorReady || _webView is null)
        {
            _pendingText = text;
            return;
        }

        var escaped = EscapeJs(text);
        await _webView.ExecuteScriptAsync($"setText(`{escaped}`);");
    }

    private async void PushLanguageToEditor(string language)
    {
        if (!_isEditorReady || _webView is null)
        {
            _pendingLanguage = language;
            return;
        }

        await _webView.ExecuteScriptAsync($"setLanguage('{EscapeJs(language)}');");
    }

    private async void PushThemeToEditor(string theme)
    {
        if (!_isEditorReady || _webView is null)
        {
            _pendingTheme = theme;
            return;
        }

        // Update both Monaco theme and body background
        await _webView.ExecuteScriptAsync($"setTheme('{EscapeJs(theme)}'); applyThemeBackground('{EscapeJs(theme)}');");
    }

    private async void PushReadOnlyToEditor(bool readOnly)
    {
        if (!_isEditorReady || _webView is null)
        {
            _pendingReadOnly = readOnly;
            return;
        }

        await _webView.ExecuteScriptAsync($"setReadOnly({(readOnly ? "true" : "false")});");
    }

    /// <summary>Get the full text content asynchronously.</summary>
    public async Task<string> GetTextAsync()
    {
        if (!_isEditorReady || _webView is null)
            return Text;

        var result = await _webView.ExecuteScriptAsync("getText();");
        return JsonSerializer.Deserialize<string>(result) ?? string.Empty;
    }

    /// <summary>Set arbitrary editor options as a JSON string.</summary>
    public async Task SetOptionsAsync(string optionsJson)
    {
        if (!_isEditorReady || _webView is null)
        {
            _pendingOptions = optionsJson;
            return;
        }

        var escaped = EscapeJs(optionsJson);

        await _webView.ExecuteScriptAsync($"setOptions('{escaped}');");
    }

    /// <summary>Focus the editor.</summary>
    public async Task FocusEditorAsync()
    {
        if (_isEditorReady && _webView is not null)
            await _webView.ExecuteScriptAsync("focusEditor();");
    }

    /// <summary>Insert text at the current cursor position.</summary>
    public async Task InsertTextAtCursorAsync(string text)
    {
        if (!_isEditorReady || _webView is null)
            return;

        var escaped = EscapeJs(text);

        await _webView.ExecuteScriptAsync($"insertTextAtCursor(`{escaped}`);");
    }

    /// <summary>Get the currently selected text.</summary>
    public async Task<string> GetSelectedTextAsync()
    {
        if (!_isEditorReady || _webView is null)
            return string.Empty;

        var result = await _webView.ExecuteScriptAsync("getSelectedText();");

        return JsonSerializer.Deserialize<string>(result) ?? string.Empty;
    }

    /// <summary>Get the cursor position.</summary>
    public async Task<(int Line, int Column)> GetCursorPositionAsync()
    {
        if (!_isEditorReady || _webView is null)
            return (1, 1);

        var result = await _webView.ExecuteScriptAsync("getCursorPosition();");
        var json = JsonSerializer.Deserialize<string>(result) ?? "{}";

        using var doc = JsonDocument.Parse(json);

        var line = doc.RootElement.GetProperty("lineNumber").GetInt32();
        var col = doc.RootElement.GetProperty("column").GetInt32();

        return (line, col);
    }

    /// <summary>Set the cursor position.</summary>
    public async Task SetCursorPositionAsync(int lineNumber, int column)
    {
        if (!_isEditorReady || _webView is null)
            return;

        await _webView.ExecuteScriptAsync($"setCursorPosition({lineNumber}, {column});");
    }

    /// <summary>Trigger a built-in Monaco action by ID.</summary>
    public async Task TriggerActionAsync(string actionId)
    {
        if (!_isEditorReady || _webView is null)
            return;

        await _webView.ExecuteScriptAsync($"triggerAction('{EscapeJs(actionId)}');");
    }

    /// <summary>
    /// Escapes a string for safe insertion into JavaScript template literals
    /// and single-quoted strings.
    /// </summary>
    private static string EscapeJs(string value)
    {
        return value
            .Replace("\\", "\\\\")
            .Replace("`", "\\`")
            .Replace("'", "\\'")
            .Replace("\"", "\\\"")
            .Replace("$", "\\$")
            .Replace("\r\n", "\\n")
            .Replace("\r", "\\n")
            .Replace("\n", "\\n");
    }
}

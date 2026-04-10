namespace MonacoEditor.WinUI3;

/// <summary>
/// Configuration options for inline suggestions (ghost text).
/// Corresponds to Monaco's <c>IInlineSuggestOptions</c>.
/// </summary>
public sealed class InlineSuggestOptions : OptionsBase
{
    private bool? _enabled;
    private string? _mode;
    private string? _showToolbar;
    private bool? _syntaxHighlightingEnabled;
    private bool? _suppressSuggestions;
    private int? _minShowDelay;
    private bool? _suppressInSnippetMode;
    private bool? _keepOnBlur;
    private string? _fontFamily;

    /// <summary>Enable or disable automatic inline completions.</summary>
    public bool? Enabled
    {
        get => _enabled;
        set => SetProperty(ref _enabled, value);
    }

    /// <summary>
    /// Ghost text display mode. Use <see cref="InlineSuggestMode"/> constants.
    /// Defaults to <c>"prefix"</c>.
    /// </summary>
    public string? Mode
    {
        get => _mode;
        set => SetProperty(ref _mode, value);
    }

    /// <summary>
    /// When to show the inline suggestion toolbar.
    /// Use <see cref="InlineSuggestToolbar"/> constants.
    /// </summary>
    public string? ShowToolbar
    {
        get => _showToolbar;
        set => SetProperty(ref _showToolbar, value);
    }

    /// <summary>Whether syntax highlighting is applied to inline suggestions.</summary>
    public bool? SyntaxHighlightingEnabled
    {
        get => _syntaxHighlightingEnabled;
        set => SetProperty(ref _syntaxHighlightingEnabled, value);
    }

    /// <summary>Suppress the suggest widget when an inline suggestion is shown.</summary>
    public bool? SuppressSuggestions
    {
        get => _suppressSuggestions;
        set => SetProperty(ref _suppressSuggestions, value);
    }

    /// <summary>Minimum delay (ms) before inline suggestions are shown.</summary>
    public int? MinShowDelay
    {
        get => _minShowDelay;
        set => SetProperty(ref _minShowDelay, value);
    }

    /// <summary>Suppress inline suggestions while a snippet is active.</summary>
    public bool? SuppressInSnippetMode
    {
        get => _suppressInSnippetMode;
        set => SetProperty(ref _suppressInSnippetMode, value);
    }

    /// <summary>Keep inline suggestions visible when the editor loses focus.</summary>
    public bool? KeepOnBlur
    {
        get => _keepOnBlur;
        set => SetProperty(ref _keepOnBlur, value);
    }

    /// <summary>Font family for inline suggestions.</summary>
    public string? FontFamily
    {
        get => _fontFamily;
        set => SetProperty(ref _fontFamily, value);
    }
}

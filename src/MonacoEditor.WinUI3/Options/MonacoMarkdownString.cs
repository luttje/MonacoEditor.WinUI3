namespace MonacoEditor.WinUI3;

/// <summary>
/// A simple inline Markdown string used for the <see cref="MonacoEditorOptions.ReadOnlyMessage"/> option.
/// Corresponds to Monaco's <c>IMarkdownString</c>.
/// </summary>
public sealed class MonacoMarkdownString : OptionsBase
{
    private string? _value;
    private bool? _isTrusted;
    private bool? _supportThemeIcons;
    private bool? _supportHtml;

    /// <summary>The Markdown content.</summary>
    public string? Value
    {
        get => _value;
        set => SetProperty(ref _value, value);
    }

    /// <summary>Whether the markdown content is trusted (enables commands).</summary>
    public bool? IsTrusted
    {
        get => _isTrusted;
        set => SetProperty(ref _isTrusted, value);
    }

    /// <summary>Whether to support theme icons in the markdown content.</summary>
    public bool? SupportThemeIcons
    {
        get => _supportThemeIcons;
        set => SetProperty(ref _supportThemeIcons, value);
    }

    /// <summary>Whether to support raw HTML in the markdown content.</summary>
    public bool? SupportHtml
    {
        get => _supportHtml;
        set => SetProperty(ref _supportHtml, value);
    }
}

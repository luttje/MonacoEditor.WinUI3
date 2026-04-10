namespace MonacoEditor.WinUI3;

/// <summary>
/// Configuration options for editor inlay hints.
/// Corresponds to Monaco's <c>IEditorInlayHintsOptions</c>.
/// </summary>
public sealed class InlayHintsOptions : OptionsBase
{
    private string? _enabled;
    private int? _fontSize;
    private string? _fontFamily;
    private bool? _padding;
    private int? _maximumLength;

    /// <summary>
    /// Enable or disable inlay hints.
    /// Use <see cref="InlayHintsEnabled"/> constants.
    /// </summary>
    public string? Enabled
    {
        get => _enabled;
        set => SetProperty(ref _enabled, value);
    }

    /// <summary>Font size of inlay hints. Defaults to 90% of the editor font size.</summary>
    public int? FontSize
    {
        get => _fontSize;
        set => SetProperty(ref _fontSize, value);
    }

    /// <summary>Font family of inlay hints. Defaults to editor font family.</summary>
    public string? FontFamily
    {
        get => _fontFamily;
        set => SetProperty(ref _fontFamily, value);
    }

    /// <summary>Enables padding around the inlay hint. Defaults to <c>false</c>.</summary>
    public bool? Padding
    {
        get => _padding;
        set => SetProperty(ref _padding, value);
    }

    /// <summary>Maximum length for inlay hints per line. Set to 0 for unlimited.</summary>
    public int? MaximumLength
    {
        get => _maximumLength;
        set => SetProperty(ref _maximumLength, value);
    }
}

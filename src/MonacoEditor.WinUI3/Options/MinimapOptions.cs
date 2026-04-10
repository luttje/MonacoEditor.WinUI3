namespace MonacoEditor.WinUI3;

/// <summary>
/// Configuration options for the editor minimap.
/// Corresponds to Monaco's <c>IEditorMinimapOptions</c>.
/// </summary>
public sealed class MinimapOptions : OptionsBase
{
    private bool? _enabled;
    private string? _autohide;
    private string? _side;
    private string? _size;
    private string? _showSlider;
    private bool? _renderCharacters;
    private int? _maxColumn;
    private double? _scale;
    private bool? _showRegionSectionHeaders;
    private bool? _showMarkSectionHeaders;
    private string? _markSectionHeaderRegex;
    private double? _sectionHeaderFontSize;
    private double? _sectionHeaderLetterSpacing;

    /// <summary>Enable the rendering of the minimap. Defaults to <c>true</c>.</summary>
    public bool? Enabled
    {
        get => _enabled;
        set => SetProperty(ref _enabled, value);
    }

    /// <summary>
    /// Control when the minimap is hidden.
    /// Use <see cref="MinimapAutohide"/> constants.
    /// </summary>
    public string? Autohide
    {
        get => _autohide;
        set => SetProperty(ref _autohide, value);
    }

    /// <summary>
    /// Side of the minimap in the editor.
    /// Use <see cref="MinimapSide"/> constants. Defaults to <c>"right"</c>.
    /// </summary>
    public string? Side
    {
        get => _side;
        set => SetProperty(ref _side, value);
    }

    /// <summary>
    /// Minimap rendering mode.
    /// Use <see cref="MinimapSize"/> constants. Defaults to <c>"proportional"</c>.
    /// </summary>
    public string? Size
    {
        get => _size;
        set => SetProperty(ref _size, value);
    }

    /// <summary>
    /// Rendering of the minimap slider.
    /// Use <see cref="MinimapShowSlider"/> constants. Defaults to <c>"mouseover"</c>.
    /// </summary>
    public string? ShowSlider
    {
        get => _showSlider;
        set => SetProperty(ref _showSlider, value);
    }

    /// <summary>Render actual text (instead of color blocks). Defaults to <c>true</c>.</summary>
    public bool? RenderCharacters
    {
        get => _renderCharacters;
        set => SetProperty(ref _renderCharacters, value);
    }

    /// <summary>Limit the width of the minimap to at most this many columns. Defaults to 120.</summary>
    public int? MaxColumn
    {
        get => _maxColumn;
        set => SetProperty(ref _maxColumn, value);
    }

    /// <summary>Relative size of the font in the minimap. Defaults to 1.</summary>
    public double? Scale
    {
        get => _scale;
        set => SetProperty(ref _scale, value);
    }

    /// <summary>Whether to show named regions as section headers. Defaults to <c>true</c>.</summary>
    public bool? ShowRegionSectionHeaders
    {
        get => _showRegionSectionHeaders;
        set => SetProperty(ref _showRegionSectionHeaders, value);
    }

    /// <summary>Whether to show MARK: comments as section headers. Defaults to <c>true</c>.</summary>
    public bool? ShowMarkSectionHeaders
    {
        get => _showMarkSectionHeaders;
        set => SetProperty(ref _showMarkSectionHeaders, value);
    }

    /// <summary>
    /// Custom regex for section header parsing. Must include a named group <c>(?&lt;label&gt;.+)</c>.
    /// </summary>
    public string? MarkSectionHeaderRegex
    {
        get => _markSectionHeaderRegex;
        set => SetProperty(ref _markSectionHeaderRegex, value);
    }

    /// <summary>Font size of section headers. Defaults to 9.</summary>
    public double? SectionHeaderFontSize
    {
        get => _sectionHeaderFontSize;
        set => SetProperty(ref _sectionHeaderFontSize, value);
    }

    /// <summary>Letter spacing of section header characters (CSS px). Defaults to 1.</summary>
    public double? SectionHeaderLetterSpacing
    {
        get => _sectionHeaderLetterSpacing;
        set => SetProperty(ref _sectionHeaderLetterSpacing, value);
    }
}

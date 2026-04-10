namespace MonacoEditor.WinUI3;

/// <summary>
/// Specifies an explicit width and height for the editor container.
/// Corresponds to Monaco's <c>IDimension</c>.
/// </summary>
public sealed class DimensionOptions : OptionsBase
{
    private int? _width;
    private int? _height;

    /// <summary>Width in pixels.</summary>
    public int? Width
    {
        get => _width;
        set => SetProperty(ref _width, value);
    }

    /// <summary>Height in pixels.</summary>
    public int? Height
    {
        get => _height;
        set => SetProperty(ref _height, value);
    }
}

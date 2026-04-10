namespace MonacoEditor.WinUI3;

/// <summary>
/// Spacing options around the editor content area.
/// Corresponds to Monaco's <c>IEditorPaddingOptions</c>.
/// </summary>
public sealed class PaddingOptions : OptionsBase
{
    private int? _top;
    private int? _bottom;

    /// <summary>Spacing (px) between the top edge of the editor and the first line.</summary>
    public int? Top
    {
        get => _top;
        set => SetProperty(ref _top, value);
    }

    /// <summary>Spacing (px) between the bottom edge of the editor and the last line.</summary>
    public int? Bottom
    {
        get => _bottom;
        set => SetProperty(ref _bottom, value);
    }
}

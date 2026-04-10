namespace MonacoEditor.WinUI3;

/// <summary>
/// Configuration options for the editor scrollbars.
/// Corresponds to Monaco's <c>IEditorScrollbarOptions</c>.
/// </summary>
public sealed class ScrollbarOptions : OptionsBase
{
    private int? _arrowSize;
    private string? _vertical;
    private string? _horizontal;
    private bool? _useShadows;
    private bool? _verticalHasArrows;
    private bool? _horizontalHasArrows;
    private bool? _handleMouseWheel;
    private bool? _alwaysConsumeMouseWheel;
    private int? _horizontalScrollbarSize;
    private int? _verticalScrollbarSize;
    private int? _verticalSliderSize;
    private int? _horizontalSliderSize;
    private bool? _scrollByPage;
    private bool? _ignoreHorizontalScrollbarInContentHeight;

    /// <summary>Size of arrow buttons (if displayed). Defaults to 11. Cannot be updated after creation.</summary>
    public int? ArrowSize { get => _arrowSize; set => SetProperty(ref _arrowSize, value); }

    /// <summary>
    /// Visibility of the vertical scrollbar.
    /// Use <see cref="ScrollbarVisibility"/> constants. Defaults to <c>"auto"</c>.
    /// </summary>
    public string? Vertical { get => _vertical; set => SetProperty(ref _vertical, value); }

    /// <summary>
    /// Visibility of the horizontal scrollbar.
    /// Use <see cref="ScrollbarVisibility"/> constants. Defaults to <c>"auto"</c>.
    /// </summary>
    public string? Horizontal { get => _horizontal; set => SetProperty(ref _horizontal, value); }

    /// <summary>Cast shadows when content is scrolled. Defaults to <c>true</c>. Cannot be updated after creation.</summary>
    public bool? UseShadows { get => _useShadows; set => SetProperty(ref _useShadows, value); }

    /// <summary>Render arrows at the top and bottom of the vertical scrollbar. Cannot be updated after creation.</summary>
    public bool? VerticalHasArrows { get => _verticalHasArrows; set => SetProperty(ref _verticalHasArrows, value); }

    /// <summary>Render arrows at the left and right of the horizontal scrollbar. Cannot be updated after creation.</summary>
    public bool? HorizontalHasArrows { get => _horizontalHasArrows; set => SetProperty(ref _horizontalHasArrows, value); }

    /// <summary>React to mouse wheel events by scrolling. Defaults to <c>true</c>.</summary>
    public bool? HandleMouseWheel { get => _handleMouseWheel; set => SetProperty(ref _handleMouseWheel, value); }

    /// <summary>Always consume mouse wheel events (call preventDefault). Defaults to <c>true</c>. Cannot be updated after creation.</summary>
    public bool? AlwaysConsumeMouseWheel { get => _alwaysConsumeMouseWheel; set => SetProperty(ref _alwaysConsumeMouseWheel, value); }

    /// <summary>Height (px) of the horizontal scrollbar. Defaults to 12.</summary>
    public int? HorizontalScrollbarSize { get => _horizontalScrollbarSize; set => SetProperty(ref _horizontalScrollbarSize, value); }

    /// <summary>Width (px) of the vertical scrollbar. Defaults to 14.</summary>
    public int? VerticalScrollbarSize { get => _verticalScrollbarSize; set => SetProperty(ref _verticalScrollbarSize, value); }

    /// <summary>Width (px) of the vertical slider. Cannot be updated after creation.</summary>
    public int? VerticalSliderSize { get => _verticalSliderSize; set => SetProperty(ref _verticalSliderSize, value); }

    /// <summary>Height (px) of the horizontal slider. Cannot be updated after creation.</summary>
    public int? HorizontalSliderSize { get => _horizontalSliderSize; set => SetProperty(ref _horizontalSliderSize, value); }

    /// <summary>Gutter clicks move the view by a page rather than jumping to the position.</summary>
    public bool? ScrollByPage { get => _scrollByPage; set => SetProperty(ref _scrollByPage, value); }

    /// <summary>When set, the horizontal scrollbar will not increase content height.</summary>
    public bool? IgnoreHorizontalScrollbarInContentHeight { get => _ignoreHorizontalScrollbarInContentHeight; set => SetProperty(ref _ignoreHorizontalScrollbarInContentHeight, value); }
}

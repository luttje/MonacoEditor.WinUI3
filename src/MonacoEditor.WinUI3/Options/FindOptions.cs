namespace MonacoEditor.WinUI3;

/// <summary>
/// Configuration options for the editor find widget.
/// Corresponds to Monaco's <c>IEditorFindOptions</c>.
/// </summary>
public sealed class FindOptions : OptionsBase
{
    private bool? _cursorMoveOnType;
    private bool? _findOnType;
    private string? _seedSearchStringFromSelection;
    private string? _autoFindInSelection;
    private bool? _addExtraSpaceOnTop;
    private bool? _loop;

    /// <summary>Controls whether the cursor should move to find matches while typing.</summary>
    public bool? CursorMoveOnType
    {
        get => _cursorMoveOnType;
        set => SetProperty(ref _cursorMoveOnType, value);
    }

    /// <summary>Controls whether find operations are triggered on each keystroke.</summary>
    public bool? FindOnType
    {
        get => _findOnType;
        set => SetProperty(ref _findOnType, value);
    }

    /// <summary>
    /// Controls if we seed the search string from the editor selection.
    /// Use <c>"never"</c>, <c>"always"</c>, or <c>"selection"</c>.
    /// </summary>
    public string? SeedSearchStringFromSelection
    {
        get => _seedSearchStringFromSelection;
        set => SetProperty(ref _seedSearchStringFromSelection, value);
    }

    /// <summary>
    /// Controls the condition for turning on find-in-selection automatically.
    /// Use <c>"never"</c>, <c>"always"</c>, or <c>"multiline"</c>.
    /// </summary>
    public string? AutoFindInSelection
    {
        get => _autoFindInSelection;
        set => SetProperty(ref _autoFindInSelection, value);
    }

    /// <summary>Controls whether the find widget should add extra space on top of the editor.</summary>
    public bool? AddExtraSpaceOnTop
    {
        get => _addExtraSpaceOnTop;
        set => SetProperty(ref _addExtraSpaceOnTop, value);
    }

    /// <summary>Controls if Find in Selection button appears enabled when editor selection is empty.</summary>
    public bool? Loop
    {
        get => _loop;
        set => SetProperty(ref _loop, value);
    }
}

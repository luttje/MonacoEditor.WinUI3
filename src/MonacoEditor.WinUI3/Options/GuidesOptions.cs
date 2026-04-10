namespace MonacoEditor.WinUI3;

/// <summary>
/// Configuration options for editor indent guides.
/// Corresponds to Monaco's <c>IGuidesOptions</c>.
/// </summary>
public sealed class GuidesOptions : OptionsBase
{
    private BoolOrString? _bracketPairs;
    private BoolOrString? _bracketPairsHorizontal;
    private bool? _highlightActiveBracketPair;
    private bool? _indentation;
    private BoolOrString? _highlightActiveIndentation;

    /// <summary>
    /// Enable rendering of bracket pair guides. Accepts <c>true</c>, <c>false</c>, or
    /// <c>"active"</c>.
    /// </summary>
    public BoolOrString? BracketPairs
    {
        get => _bracketPairs;
        set => SetProperty(ref _bracketPairs, value);
    }

    /// <summary>
    /// Enable rendering of vertical bracket pair guides. Accepts <c>true</c>, <c>false</c>, or
    /// <c>"active"</c>.
    /// </summary>
    public BoolOrString? BracketPairsHorizontal
    {
        get => _bracketPairsHorizontal;
        set => SetProperty(ref _bracketPairsHorizontal, value);
    }

    /// <summary>Enable highlighting of the active bracket pair.</summary>
    public bool? HighlightActiveBracketPair
    {
        get => _highlightActiveBracketPair;
        set => SetProperty(ref _highlightActiveBracketPair, value);
    }

    /// <summary>Enable rendering of indent guides.</summary>
    public bool? Indentation
    {
        get => _indentation;
        set => SetProperty(ref _indentation, value);
    }

    /// <summary>
    /// Enable highlighting of the active indent guide. Accepts <c>true</c>, <c>false</c>, or
    /// <c>"always"</c>.
    /// </summary>
    public BoolOrString? HighlightActiveIndentation
    {
        get => _highlightActiveIndentation;
        set => SetProperty(ref _highlightActiveIndentation, value);
    }
}

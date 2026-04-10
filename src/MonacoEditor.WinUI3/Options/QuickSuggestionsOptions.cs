namespace MonacoEditor.WinUI3;

/// <summary>
/// Per-context quick suggestion settings.
/// Each property accepts <c>true</c>/<c>false</c> or a
/// <see cref="QuickSuggestionsValue"/> string (<c>"on"</c>, <c>"inline"</c>, <c>"off"</c>).
/// Corresponds to Monaco's <c>IQuickSuggestionsOptions</c>.
/// </summary>
public sealed class QuickSuggestionsOptions : OptionsBase
{
    private BoolOrString? _other;
    private BoolOrString? _comments;
    private BoolOrString? _strings;

    /// <summary>Quick suggestions in other contexts.</summary>
    public BoolOrString? Other
    {
        get => _other;
        set => SetProperty(ref _other, value);
    }

    /// <summary>Quick suggestions inside comments.</summary>
    public BoolOrString? Comments
    {
        get => _comments;
        set => SetProperty(ref _comments, value);
    }

    /// <summary>Quick suggestions inside string literals.</summary>
    public BoolOrString? Strings
    {
        get => _strings;
        set => SetProperty(ref _strings, value);
    }
}

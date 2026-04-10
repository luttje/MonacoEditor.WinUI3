namespace MonacoEditor.WinUI3;

/// <summary>
/// Configuration options for the smart-select (expand/shrink selection) feature.
/// Corresponds to Monaco's <c>ISmartSelectOptions</c>.
/// </summary>
public sealed class SmartSelectOptions : OptionsBase
{
    private bool? _selectLeadingAndTrailingWhitespace;
    private bool? _selectSubwords;

    /// <summary>Whether to include leading/trailing whitespace in selection expansion.</summary>
    public bool? SelectLeadingAndTrailingWhitespace
    {
        get => _selectLeadingAndTrailingWhitespace;
        set => SetProperty(ref _selectLeadingAndTrailingWhitespace, value);
    }

    /// <summary>Whether to expand selection to subwords (camelCase parts).</summary>
    public bool? SelectSubwords
    {
        get => _selectSubwords;
        set => SetProperty(ref _selectSubwords, value);
    }
}

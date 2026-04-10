namespace MonacoEditor.WinUI3;

/// <summary>
/// Configuration options for bracket pair colorization.
/// Corresponds to Monaco's <c>IBracketPairColorizationOptions</c>.
/// </summary>
public sealed class BracketPairColorizationOptions : OptionsBase
{
    private bool? _enabled;
    private bool? _independentColorPoolPerBracketType;

    /// <summary>Enable or disable bracket pair colorization.</summary>
    public bool? Enabled
    {
        get => _enabled;
        set => SetProperty(ref _enabled, value);
    }

    /// <summary>Use independent color pool per bracket type.</summary>
    public bool? IndependentColorPoolPerBracketType
    {
        get => _independentColorPoolPerBracketType;
        set => SetProperty(ref _independentColorPoolPerBracketType, value);
    }
}

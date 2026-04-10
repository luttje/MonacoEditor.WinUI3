namespace MonacoEditor.WinUI3;

/// <summary>
/// Configuration options for parameter hint tooltips.
/// Corresponds to Monaco's <c>IEditorParameterHintOptions</c>.
/// </summary>
public sealed class ParameterHintsOptions : OptionsBase
{
    private bool? _enabled;
    private bool? _cycle;

    /// <summary>Enable parameter hints. Defaults to <c>true</c>.</summary>
    public bool? Enabled
    {
        get => _enabled;
        set => SetProperty(ref _enabled, value);
    }

    /// <summary>Enable cycling through parameter hints. Defaults to <c>false</c>.</summary>
    public bool? Cycle
    {
        get => _cycle;
        set => SetProperty(ref _cycle, value);
    }
}

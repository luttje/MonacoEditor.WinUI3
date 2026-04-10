namespace MonacoEditor.WinUI3;

/// <summary>
/// Configuration options for the editor lightbulb (code-actions) indicator.
/// Corresponds to Monaco's <c>IEditorLightbulbOptions</c>.
/// </summary>
public sealed class LightbulbOptions : OptionsBase
{
    private string? _enabled;

    /// <summary>
    /// Enable the lightbulb code action menu.
    /// Use <see cref="ShowLightbulbIconMode"/> constants (<c>"off"</c>, <c>"onCode"</c>, <c>"on"</c>).
    /// Defaults to <c>"onCode"</c>.
    /// </summary>
    public string? Enabled
    {
        get => _enabled;
        set => SetProperty(ref _enabled, value);
    }
}

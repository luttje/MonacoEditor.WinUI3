namespace MonacoEditor.WinUI3;

/// <summary>
/// Configuration options for paste-as behaviour.
/// Corresponds to Monaco's <c>IPasteAsOptions</c>.
/// </summary>
public sealed class PasteAsOptions : OptionsBase
{
    private bool? _enabled;
    private string? _showPasteSelector;

    /// <summary>Enable paste-as functionality. Defaults to <c>true</c>.</summary>
    public bool? Enabled
    {
        get => _enabled;
        set => SetProperty(ref _enabled, value);
    }

    /// <summary>
    /// Controls if a widget is shown after a paste.
    /// Use <see cref="PasteShowSelector"/> constants. Defaults to <c>"afterPaste"</c>.
    /// </summary>
    public string? ShowPasteSelector
    {
        get => _showPasteSelector;
        set => SetProperty(ref _showPasteSelector, value);
    }
}

namespace MonacoEditor.WinUI3;

/// <summary>
/// Configuration options for dropping content into the editor.
/// Corresponds to Monaco's <c>IDropIntoEditorOptions</c>.
/// </summary>
public sealed class DropIntoEditorOptions : OptionsBase
{
    private bool? _enabled;
    private string? _showDropSelector;

    /// <summary>Enable dropping into the editor. Defaults to <c>true</c>.</summary>
    public bool? Enabled
    {
        get => _enabled;
        set => SetProperty(ref _enabled, value);
    }

    /// <summary>
    /// Controls if a widget is shown after a drop.
    /// Use <see cref="DropShowSelector"/> constants. Defaults to <c>"afterDrop"</c>.
    /// </summary>
    public string? ShowDropSelector
    {
        get => _showDropSelector;
        set => SetProperty(ref _showDropSelector, value);
    }
}

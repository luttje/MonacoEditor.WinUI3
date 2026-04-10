namespace MonacoEditor.WinUI3;

/// <summary>
/// Configuration options for the editor hover tooltip.
/// Corresponds to Monaco's <c>IEditorHoverOptions</c>.
/// </summary>
public sealed class HoverOptions : OptionsBase
{
    private bool? _enabled;
    private int? _delay;
    private bool? _sticky;
    private int? _hidingDelay;
    private bool? _above;

    /// <summary>Enable the hover. Defaults to <c>true</c>.</summary>
    public bool? Enabled
    {
        get => _enabled;
        set => SetProperty(ref _enabled, value);
    }

    /// <summary>Delay (ms) for showing the hover. Defaults to 300.</summary>
    public int? Delay
    {
        get => _delay;
        set => SetProperty(ref _delay, value);
    }

    /// <summary>
    /// Whether the hover is sticky so it can be clicked and its contents selected.
    /// Defaults to <c>true</c>.
    /// </summary>
    public bool? Sticky
    {
        get => _sticky;
        set => SetProperty(ref _sticky, value);
    }

    /// <summary>
    /// How long (ms) the hover is visible after the cursor leaves it.
    /// Requires <see cref="Sticky"/> = <c>true</c>.
    /// </summary>
    public int? HidingDelay
    {
        get => _hidingDelay;
        set => SetProperty(ref _hidingDelay, value);
    }

    /// <summary>Whether the hover should be shown above the line if possible.</summary>
    public bool? Above
    {
        get => _above;
        set => SetProperty(ref _above, value);
    }
}

namespace MonacoEditor.WinUI3;

/// <summary>
/// Configuration options for sticky scroll (pinned scope headers).
/// Corresponds to Monaco's <c>IEditorStickyScrollOptions</c>.
/// </summary>
public sealed class StickyScrollOptions : OptionsBase
{
    private bool? _enabled;
    private int? _maxLineCount;
    private string? _defaultModel;
    private bool? _scrollWithEditor;

    /// <summary>Enable sticky scroll. Defaults to <c>true</c> in VS Code.</summary>
    public bool? Enabled
    {
        get => _enabled;
        set => SetProperty(ref _enabled, value);
    }

    /// <summary>Maximum number of sticky lines to show.</summary>
    public int? MaxLineCount
    {
        get => _maxLineCount;
        set => SetProperty(ref _maxLineCount, value);
    }

    /// <summary>
    /// Model to use for sticky scroll content.
    /// Use <see cref="StickyScrollDefaultModel"/> constants.
    /// </summary>
    public string? DefaultModel
    {
        get => _defaultModel;
        set => SetProperty(ref _defaultModel, value);
    }

    /// <summary>Whether sticky scroll scrolls with the horizontal scrollbar.</summary>
    public bool? ScrollWithEditor
    {
        get => _scrollWithEditor;
        set => SetProperty(ref _scrollWithEditor, value);
    }
}

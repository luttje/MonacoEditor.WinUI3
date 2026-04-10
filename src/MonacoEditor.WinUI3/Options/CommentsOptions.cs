namespace MonacoEditor.WinUI3;

/// <summary>
/// Configuration options for editor comments.
/// Corresponds to Monaco's <c>IEditorCommentsOptions</c>.
/// </summary>
public sealed class CommentsOptions : OptionsBase
{
    private bool? _insertSpace;
    private bool? _ignoreEmptyLines;

    /// <summary>Insert a space after the line comment token and inside block comment tokens.</summary>
    public bool? InsertSpace
    {
        get => _insertSpace;
        set => SetProperty(ref _insertSpace, value);
    }

    /// <summary>Ignore empty lines when inserting line comments.</summary>
    public bool? IgnoreEmptyLines
    {
        get => _ignoreEmptyLines;
        set => SetProperty(ref _ignoreEmptyLines, value);
    }
}

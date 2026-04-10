using System.Text.Json.Serialization;

namespace MonacoEditor.WinUI3;

/// <summary>
/// Defines a vertical ruler line in the editor.
/// Corresponds to Monaco's <c>IRulerOption</c>.
/// </summary>
public sealed class RulerOption : OptionsBase
{
    private int? _column;
    private string? _color;

    /// <summary>The column at which to render the ruler.</summary>
    public int? Column
    {
        get => _column;
        set => SetProperty(ref _column, value);
    }

    /// <summary>CSS colour string for the ruler line, or <c>null</c> for the default colour.</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Color
    {
        get => _color;
        set => SetProperty(ref _color, value);
    }

    /// <summary>Creates a <see cref="RulerOption"/> positioned at the given column.</summary>
    public static implicit operator RulerOption(int column) => new() { Column = column };
}

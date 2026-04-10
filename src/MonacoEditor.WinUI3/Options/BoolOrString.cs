using System.Text.Json;
using System.Text.Json.Serialization;

namespace MonacoEditor.WinUI3;

/// <summary>
/// Represents a Monaco option value that can be either a boolean or a string,
/// corresponding to TypeScript union types such as <c>string | boolean</c>
/// (e.g. <c>fontLigatures</c>, <c>fontVariations</c>).
/// </summary>
[JsonConverter(typeof(BoolOrStringConverter))]
public sealed class BoolOrString
{
    private readonly bool _boolValue;
    private readonly string? _stringValue;
    private readonly bool _isBool;

    private BoolOrString(bool value) { _boolValue = value; _isBool = true; }
    private BoolOrString(string value) { _stringValue = value; _isBool = false; }

    /// <summary>Creates a <see cref="BoolOrString"/> from a boolean value.</summary>
    public static implicit operator BoolOrString(bool value) => new(value);

    /// <summary>Creates a <see cref="BoolOrString"/> from a string value.</summary>
    public static implicit operator BoolOrString(string value) => new(value);

    internal void WriteTo(Utf8JsonWriter writer)
    {
        if (_isBool) writer.WriteBooleanValue(_boolValue);
        else writer.WriteStringValue(_stringValue);
    }
}

internal sealed class BoolOrStringConverter : JsonConverter<BoolOrString>
{
    public override BoolOrString? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => reader.TokenType switch
        {
            JsonTokenType.True => (BoolOrString)true,
            JsonTokenType.False => (BoolOrString)false,
            JsonTokenType.String => (BoolOrString)(reader.GetString() ?? string.Empty),
            _ => null,
        };

    public override void Write(Utf8JsonWriter writer, BoolOrString value, JsonSerializerOptions options)
        => value.WriteTo(writer);
}

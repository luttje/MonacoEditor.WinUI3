using System.Text.Json;
using System.Text.Json.Serialization;

namespace MonacoEditor.WinUI3;

/// <summary>
/// Represents the Monaco <c>quickSuggestions</c> option value, which accepts either
/// a boolean or a <see cref="QuickSuggestionsOptions"/> object.
/// </summary>
[JsonConverter(typeof(BoolOrQuickSuggestionsConverter))]
public sealed class BoolOrQuickSuggestions
{
    private readonly bool _boolValue;
    private readonly QuickSuggestionsOptions? _options;
    private readonly bool _isBool;

    private BoolOrQuickSuggestions(bool value) { _boolValue = value; _isBool = true; }
    private BoolOrQuickSuggestions(QuickSuggestionsOptions value) { _options = value; _isBool = false; }

    /// <summary>Creates a <see cref="BoolOrQuickSuggestions"/> from a boolean value.</summary>
    public static implicit operator BoolOrQuickSuggestions(bool value) => new(value);

    /// <summary>Creates a <see cref="BoolOrQuickSuggestions"/> from a <see cref="QuickSuggestionsOptions"/>.</summary>
    public static implicit operator BoolOrQuickSuggestions(QuickSuggestionsOptions value) => new(value);

    internal void WriteTo(Utf8JsonWriter writer, JsonSerializerOptions options)
    {
        if (_isBool) writer.WriteBooleanValue(_boolValue);
        else JsonSerializer.Serialize(writer, _options, options);
    }
}

internal sealed class BoolOrQuickSuggestionsConverter : JsonConverter<BoolOrQuickSuggestions>
{
    public override BoolOrQuickSuggestions? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => reader.TokenType switch
        {
            JsonTokenType.True => (BoolOrQuickSuggestions)true,
            JsonTokenType.False => (BoolOrQuickSuggestions)false,
            _ => (BoolOrQuickSuggestions)(JsonSerializer.Deserialize<QuickSuggestionsOptions>(ref reader, options) ?? new()),
        };

    public override void Write(Utf8JsonWriter writer, BoolOrQuickSuggestions value, JsonSerializerOptions options)
        => value.WriteTo(writer, options);
}

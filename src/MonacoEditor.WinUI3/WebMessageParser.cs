using System.Text.Json;

namespace MonacoEditor.WinUI3;

/// <summary>Discriminated union of messages the JS side can send to C#.</summary>
internal abstract record WebMessage
{
    internal sealed record Ready : WebMessage;
    internal sealed record ContentChanged(string Text) : WebMessage;
    internal sealed record Unknown(string Type) : WebMessage;
}

/// <summary>
/// Parses raw JSON strings posted from the Monaco editor page via
/// <c>window.chrome.webview.postMessage</c>.
/// </summary>
internal static class WebMessageParser
{
    /// <summary>
    /// Parses <paramref name="json"/> into a <see cref="WebMessage"/>.
    /// Returns <see langword="null"/> when the input is empty or not a valid JSON object
    /// with a "type" field.
    /// </summary>
    internal static WebMessage? Parse(string? json)
    {
        if (string.IsNullOrEmpty(json))
            return null;

        try
        {
            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;

            if (!root.TryGetProperty("type", out var typeProp))
                return null;

            var type = typeProp.GetString();

            return type switch
            {
                "ready" => new WebMessage.Ready(),
                "contentChanged" => new WebMessage.ContentChanged(
                    root.TryGetProperty("text", out var textProp)
                        ? (textProp.GetString() ?? string.Empty)
                        : string.Empty),
                _ => new WebMessage.Unknown(type ?? string.Empty),
            };
        }
        catch (JsonException)
        {
            return null;
        }
    }
}

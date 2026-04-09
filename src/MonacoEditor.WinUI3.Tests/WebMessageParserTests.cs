namespace MonacoEditor.WinUI3.Tests;

/// <summary>
/// Verifies the JSON message parser that handles messages posted by the
/// Monaco editor page via <c>window.chrome.webview.postMessage</c>.
/// </summary>
[TestClass]
public class WebMessageParserTests
{
    [TestMethod]
    public void NullInput_ReturnsNull()
    {
        Assert.IsNull(WebMessageParser.Parse(null));
    }

    [TestMethod]
    public void EmptyInput_ReturnsNull()
    {
        Assert.IsNull(WebMessageParser.Parse(string.Empty));
    }

    [TestMethod]
    public void MalformedJson_ReturnsNull()
    {
        Assert.IsNull(WebMessageParser.Parse("{not valid json"));
    }

    [TestMethod]
    public void PlainString_ReturnsNull()
    {
        // A raw string (not a JSON object) should not crash and returns null
        Assert.IsNull(WebMessageParser.Parse("hello"));
    }

    [TestMethod]
    public void MissingTypeField_ReturnsNull()
    {
        Assert.IsNull(WebMessageParser.Parse("{\"text\":\"hello\"}"));
    }

    [TestMethod]
    public void UnknownType_ReturnsUnknownMessage()
    {
        var msg = WebMessageParser.Parse("{\"type\":\"somethingInvalid\"}");

        Assert.IsInstanceOfType<WebMessage.Unknown>(msg);
        Assert.AreEqual("somethingInvalid", ((WebMessage.Unknown)msg!).Type);
    }

    [TestMethod]
    public void NullTypeValue_ReturnsUnknownWithEmptyType()
    {
        var msg = WebMessageParser.Parse("{\"type\":null}");

        Assert.IsInstanceOfType<WebMessage.Unknown>(msg);
        Assert.AreEqual(string.Empty, ((WebMessage.Unknown)msg!).Type);
    }

    [TestMethod]
    public void ReadyMessage_ReturnsReadyInstance()
    {
        var msg = WebMessageParser.Parse("{\"type\":\"ready\"}");

        Assert.IsInstanceOfType<WebMessage.Ready>(msg);
    }

    [TestMethod]
    public void ReadyMessage_WithExtraFields_StillParsesAsReady()
    {
        var msg = WebMessageParser.Parse("{\"type\":\"ready\",\"ignored\":true}");

        Assert.IsInstanceOfType<WebMessage.Ready>(msg);
    }

    [TestMethod]
    public void ContentChangedMessage_ReturnsContentChangedWithText()
    {
        var msg = WebMessageParser.Parse("{\"type\":\"contentChanged\",\"text\":\"hello world\"}");

        Assert.IsInstanceOfType<WebMessage.ContentChanged>(msg);
        Assert.AreEqual("hello world", ((WebMessage.ContentChanged)msg!).Text);
    }

    [TestMethod]
    public void ContentChangedMessage_EmptyText_ReturnsEmptyString()
    {
        var msg = WebMessageParser.Parse("{\"type\":\"contentChanged\",\"text\":\"\"}");

        Assert.IsInstanceOfType<WebMessage.ContentChanged>(msg);
        Assert.AreEqual(string.Empty, ((WebMessage.ContentChanged)msg!).Text);
    }

    [TestMethod]
    public void ContentChangedMessage_MissingTextField_TextIsEmptyString()
    {
        // The JS side should always send "text", but we handle the absence gracefully
        var msg = WebMessageParser.Parse("{\"type\":\"contentChanged\"}");

        Assert.IsInstanceOfType<WebMessage.ContentChanged>(msg);
        Assert.AreEqual(string.Empty, ((WebMessage.ContentChanged)msg!).Text);
    }

    [TestMethod]
    public void ContentChangedMessage_MultilineText_PreservesNewlines()
    {
        var json = "{\"type\":\"contentChanged\",\"text\":\"line1\\nline2\"}";
        var msg = WebMessageParser.Parse(json);

        Assert.IsInstanceOfType<WebMessage.ContentChanged>(msg);
        Assert.AreEqual("line1\nline2", ((WebMessage.ContentChanged)msg!).Text);
    }

    [TestMethod]
    public void ContentChangedMessage_TextWithSpecialChars_PreservesContent()
    {
        var json = "{\"type\":\"contentChanged\",\"text\":\"a\\\"b\\\\c\"}";
        var msg = WebMessageParser.Parse(json);

        Assert.IsInstanceOfType<WebMessage.ContentChanged>(msg);
        Assert.AreEqual("a\"b\\c", ((WebMessage.ContentChanged)msg!).Text);
    }
}

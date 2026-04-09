namespace MonacoEditor.WinUI3.Tests;

/// <summary>
/// Verifies the JS script strings that <see cref="JsScripts"/> produces.
/// </summary>
[TestClass]
public class JsScriptBuilderTests
{
    [TestMethod]
    public void SetText_WrapInBacktickTemplateLiteral()
    {
        // setText must use backticks so multi-line content is valid JS
        Assert.AreEqual("setText(`hello`);", JsScripts.SetText("hello"));
    }

    [TestMethod]
    public void SetText_EscapesNewlinesInPayload()
    {
        Assert.AreEqual(@"setText(`line1\nline2`);", JsScripts.SetText("line1\nline2"));
    }

    [TestMethod]
    public void SetText_EscapesBackticksInPayload()
    {
        Assert.AreEqual(@"setText(`say \`hi\``);", JsScripts.SetText("say `hi`"));
    }

    [TestMethod]
    public void SetText_EscapesDollarSignsInPayload()
    {
        // Un-escaped ${…} inside a template literal would be evaluated by JS
        Assert.AreEqual(@"setText(`\${x}`);", JsScripts.SetText("${x}"));
    }

    [TestMethod]
    public void SetLanguage_WrapInSingleQuotes()
    {
        Assert.AreEqual("setLanguage('csharp');", JsScripts.SetLanguage("csharp"));
    }

    [TestMethod]
    public void SetLanguage_EscapesSingleQuotesInPayload()
    {
        Assert.AreEqual(@"setLanguage('it\'s');", JsScripts.SetLanguage("it's"));
    }

    [TestMethod]
    public void SetTheme_EscapesSpecialCharsInBothCalls()
    {
        var script = JsScripts.SetTheme("a'b");

        StringAssert.Contains(script, @"setTheme('a\'b');");
        StringAssert.Contains(script, @"applyThemeBackground('a\'b');");
    }

    [TestMethod]
    public void SetOptions_WrapInSingleQuotes()
    {
        // Use a payload with no special characters to test the wrapping alone
        Assert.AreEqual("setOptions('{}');", JsScripts.SetOptions("{}"));
    }

    [TestMethod]
    public void SetOptions_EscapesDoubleQuotesInPayload()
    {
        // JsEscape turns " into \" so the JS single-quoted string is not broken.
        // JS sees setOptions('{"fontSize":14}') after its own unescaping, which is
        // valid input for JSON.parse inside setOptions.
        var script = JsScripts.SetOptions("{\"fontSize\":14}");

        // Expected runtime string: setOptions('{\"fontSize\":14}');
        Assert.AreEqual("setOptions('{\\\"fontSize\\\":14}');", script);
    }

    [TestMethod]
    public void TriggerAction_WrapInSingleQuotes()
    {
        Assert.AreEqual("triggerAction('editor.action.formatDocument');",
            JsScripts.TriggerAction("editor.action.formatDocument"));
    }

    [TestMethod]
    public void TriggerAction_EscapesSingleQuotesInId()
    {
        Assert.AreEqual(@"triggerAction('it\'s an action');",
            JsScripts.TriggerAction("it's an action"));
    }
}

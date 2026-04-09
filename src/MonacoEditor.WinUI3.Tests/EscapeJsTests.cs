namespace MonacoEditor.WinUI3.Tests;

[TestClass]
public class EscapeJsTests
{
    [TestMethod]
    public void EmptyString_ReturnsEmpty()
    {
        Assert.AreEqual(string.Empty, JsEscape.Escape(string.Empty));
    }

    [TestMethod]
    public void PlainText_IsUnchanged()
    {
        const string input = "Hello, world!";
        Assert.AreEqual(input, JsEscape.Escape(input));
    }

    [TestMethod]
    public void Tab_IsUnchanged()
    {
        Assert.AreEqual("\t", JsEscape.Escape("\t"));
    }

    [TestMethod]
    public void UnicodeAndEmoji_AreUnchanged()
    {
        const string input = "こんにちは 🎉";
        Assert.AreEqual(input, JsEscape.Escape(input));
    }

    [TestMethod]
    public void Backslashes_AreDoubled()
    {
        Assert.AreEqual(@"foo\\bar", JsEscape.Escape(@"foo\bar"));
    }

    [TestMethod]
    public void ConsecutiveBackslashes_EachIsDoubled()
    {
        Assert.AreEqual(@"a\\\\b", JsEscape.Escape(@"a\\b"));
    }

    [TestMethod]
    public void Backticks_AreEscaped()
    {
        Assert.AreEqual(@"say \`hello\`", JsEscape.Escape("say `hello`"));
    }

    [TestMethod]
    public void SingleQuotes_AreEscaped()
    {
        Assert.AreEqual(@"it\'s", JsEscape.Escape("it's"));
    }

    [TestMethod]
    public void DoubleQuotes_AreEscaped()
    {
        Assert.AreEqual(@"say \""hi\""", JsEscape.Escape("say \"hi\""));
    }

    [TestMethod]
    public void DollarSigns_AreEscaped()
    {
        Assert.AreEqual(@"\${value}", JsEscape.Escape("${value}"));
    }

    [TestMethod]
    public void CrLf_BecomesEscapedN()
    {
        Assert.AreEqual(@"line1\nline2", JsEscape.Escape("line1\r\nline2"));
    }

    [TestMethod]
    public void Cr_BecomesEscapedN()
    {
        Assert.AreEqual(@"line1\nline2", JsEscape.Escape("line1\rline2"));
    }

    [TestMethod]
    public void Lf_BecomesEscapedN()
    {
        Assert.AreEqual(@"line1\nline2", JsEscape.Escape("line1\nline2"));
    }

    [TestMethod]
    public void MixedNewlines_AllBecomeEscapedN()
    {
        var input = "a\r\nb\nc\rd";
        Assert.AreEqual(@"a\nb\nc\nd", JsEscape.Escape(input));
    }

    [TestMethod]
    public void BackslashBeforeNewline_BothAreEscaped()
    {
        Assert.AreEqual(@"\\\n", JsEscape.Escape("\\\n"));
    }

    [TestMethod]
    public void AllSpecialCharsCombined_AreEscapedCorrectly()
    {
        var input = "path\\to\\`file` costs $5 and it's \"great\"\r\n";
        var expected = @"path\\to\\\`file\` costs \$5 and it\'s \""great\""\n";
        Assert.AreEqual(expected, JsEscape.Escape(input));
    }
}


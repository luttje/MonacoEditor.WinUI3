using System.Reflection;

namespace MonacoEditor.WinUI3.Tests;

[TestClass]
public class EmbeddedResourceTests
{
    private static Assembly LibraryAssembly =>
        typeof(MonacoEditorControl).Assembly;

    [TestMethod]
    public void IndexHtml_IsEmbeddedAsResource()
    {
        const string resourceName = "MonacoEditor.WinUI3.Web.index.html";

        using var stream = LibraryAssembly.GetManifestResourceStream(resourceName);

        Assert.IsNotNull(stream, $"Embedded resource '{resourceName}' was not found.");
    }

    [TestMethod]
    public void IndexHtml_ContainsEditorContainer()
    {
        const string resourceName = "MonacoEditor.WinUI3.Web.index.html";

        using var stream = LibraryAssembly.GetManifestResourceStream(resourceName);
        Assert.IsNotNull(stream);

        using var reader = new StreamReader(stream!);
        var html = reader.ReadToEnd();

        Assert.Contains("editor-container", html,
            "The embedded HTML should contain the editor-container element.");
    }

    [TestMethod]
    public void IndexHtml_ContainsReadyMessagePost()
    {
        const string resourceName = "MonacoEditor.WinUI3.Web.index.html";

        using var stream = LibraryAssembly.GetManifestResourceStream(resourceName);
        Assert.IsNotNull(stream);

        using var reader = new StreamReader(stream!);
        var html = reader.ReadToEnd();

        Assert.IsTrue(
            html.Contains("type: 'ready'") || html.Contains("type:'ready'"),
            "The embedded HTML should post a 'ready' message.");
    }

    [TestMethod]
    public void IndexHtml_ContainsContentChangedMessagePost()
    {
        const string resourceName = "MonacoEditor.WinUI3.Web.index.html";

        using var stream = LibraryAssembly.GetManifestResourceStream(resourceName);
        Assert.IsNotNull(stream);

        using var reader = new StreamReader(stream!);
        var html = reader.ReadToEnd();

        Assert.Contains("contentChanged", html,
            "The embedded HTML should post 'contentChanged' messages.");
    }

    [TestMethod]
    public void IndexHtml_DeclaresExpectedJsFunctions()
    {
        const string resourceName = "MonacoEditor.WinUI3.Web.index.html";

        using var stream = LibraryAssembly.GetManifestResourceStream(resourceName);
        Assert.IsNotNull(stream);

        using var reader = new StreamReader(stream!);
        var html = reader.ReadToEnd();

        // These JS functions are called from the C# control via ExecuteScriptAsync
        string[] expectedFunctions =
        [
            "function setText(",
            "function getText(",
            "function setLanguage(",
            "function setTheme(",
            "function setOptions(",
            "function setReadOnly(",
            "function focusEditor(",
            "function getCursorPosition(",
            "function setCursorPosition(",
            "function insertTextAtCursor(",
            "function getSelectedText(",
            "function triggerAction(",
        ];

        foreach (var fn in expectedFunctions)
        {
            Assert.Contains(fn, html,
                $"The embedded HTML should declare '{fn}'.");
        }
    }

    [TestMethod]
    public void AllEmbeddedResources_ContainExpectedPrefix()
    {
        var resourceNames = LibraryAssembly.GetManifestResourceNames();

        Assert.IsNotEmpty(resourceNames,
            "Assembly should contain at least one embedded resource.");

        foreach (var name in resourceNames)
        {
            Assert.StartsWith("MonacoEditor.WinUI3.", name,
                $"Embedded resource '{name}' should have the expected namespace prefix.");
        }
    }
}

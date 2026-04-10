using System.Text.Json;

namespace MonacoEditor.WinUI3.Tests;

/// <summary>
/// Verifies that <see cref="MonacoEditorOptions"/> and sub-option classes serialise
/// to the camelCase JSON that Monaco expects.
/// </summary>
[TestClass]
public class OptionsSerializationTests
{
    private static string Serialize(MonacoEditorOptions opts) => opts.Serialize();

    private static JsonElement ParseElement(string json) => JsonDocument.Parse(json).RootElement;

    [TestMethod]
    public void EmptyOptions_SerializesToEmptyObject()
    {
        var json = Serialize(new MonacoEditorOptions());
        Assert.AreEqual("{}", json);
    }

    [TestMethod]
    public void FontSize_SerializesCamelCase()
    {
        var json = Serialize(new MonacoEditorOptions { FontSize = 16 });
        var root = ParseElement(json);

        Assert.IsTrue(root.TryGetProperty("fontSize", out var value), "Expected 'fontSize' key");
        Assert.AreEqual(16.0, value.GetDouble());
    }

    [TestMethod]
    public void MultipleScalars_AllSerialised()
    {
        var opts = new MonacoEditorOptions
        {
            FontSize = 14,
            FontFamily = "Cascadia Code",
            LineNumbers = LineNumbers.On,
            WordWrap = WordWrap.On,
        };

        var json = Serialize(opts);
        var root = ParseElement(json);

        Assert.IsTrue(root.TryGetProperty("fontSize", out _));
        Assert.IsTrue(root.TryGetProperty("fontFamily", out _));
        Assert.IsTrue(root.TryGetProperty("lineNumbers", out var ln));
        Assert.AreEqual("on", ln.GetString());
        Assert.IsTrue(root.TryGetProperty("wordWrap", out var ww));
        Assert.AreEqual("on", ww.GetString());
    }

    [TestMethod]
    public void NullProperties_AreOmitted()
    {
        var opts = new MonacoEditorOptions { FontSize = 12 };
        var json = Serialize(opts);

        Assert.DoesNotContain("fontFamily", json, StringComparison.Ordinal);
        Assert.DoesNotContain("minimap", json, StringComparison.Ordinal);
    }

    [TestMethod]
    public void BoolOrString_FromTrue_SerializesBoolean()
    {
        var opts = new MonacoEditorOptions { FontLigatures = true };
        var root = ParseElement(Serialize(opts));

        Assert.IsTrue(root.TryGetProperty("fontLigatures", out var val));
        Assert.AreEqual(JsonValueKind.True, val.ValueKind);
    }

    [TestMethod]
    public void BoolOrString_FromFalse_SerializesBoolean()
    {
        var opts = new MonacoEditorOptions { FontLigatures = false };
        var root = ParseElement(Serialize(opts));

        Assert.IsTrue(root.TryGetProperty("fontLigatures", out var val));
        Assert.AreEqual(JsonValueKind.False, val.ValueKind);
    }

    [TestMethod]
    public void BoolOrString_FromString_SerializesString()
    {
        var opts = new MonacoEditorOptions { FontLigatures = "'calt', 'ss01'" };
        var root = ParseElement(Serialize(opts));

        Assert.IsTrue(root.TryGetProperty("fontLigatures", out var val));
        Assert.AreEqual(JsonValueKind.String, val.ValueKind);
        Assert.AreEqual("'calt', 'ss01'", val.GetString());
    }

    [TestMethod]
    public void BoolOrQuickSuggestions_FromFalse_SerializesBoolean()
    {
        var opts = new MonacoEditorOptions { QuickSuggestions = false };
        var root = ParseElement(Serialize(opts));

        Assert.IsTrue(root.TryGetProperty("quickSuggestions", out var val));
        Assert.AreEqual(JsonValueKind.False, val.ValueKind);
    }

    [TestMethod]
    public void BoolOrQuickSuggestions_FromOptions_SerializesObject()
    {
        var opts = new MonacoEditorOptions
        {
            QuickSuggestions = new QuickSuggestionsOptions
            {
                Other = true,
                Comments = false,
                Strings = "on",
            }
        };

        var root = ParseElement(Serialize(opts));
        Assert.IsTrue(root.TryGetProperty("quickSuggestions", out var qs));
        Assert.AreEqual(JsonValueKind.Object, qs.ValueKind);
        Assert.AreEqual(JsonValueKind.True, qs.GetProperty("other").ValueKind);
        Assert.AreEqual(JsonValueKind.False, qs.GetProperty("comments").ValueKind);
        Assert.AreEqual("on", qs.GetProperty("strings").GetString());
    }

    [TestMethod]
    public void MinimapOptions_Serialises()
    {
        var opts = new MonacoEditorOptions
        {
            Minimap = new MinimapOptions
            {
                Enabled = false,
                Side = MinimapSide.Left,
                MaxColumn = 100,
            }
        };

        var root = ParseElement(Serialize(opts));
        Assert.IsTrue(root.TryGetProperty("minimap", out var mm));
        Assert.AreEqual(JsonValueKind.False, mm.GetProperty("enabled").ValueKind);
        Assert.AreEqual("left", mm.GetProperty("side").GetString());
        Assert.AreEqual(100, mm.GetProperty("maxColumn").GetInt32());
    }

    [TestMethod]
    public void ScrollbarOptions_Serialises()
    {
        var opts = new MonacoEditorOptions
        {
            Scrollbar = new ScrollbarOptions
            {
                Vertical = ScrollbarVisibility.Hidden,
                HorizontalScrollbarSize = 8,
            }
        };

        var root = ParseElement(Serialize(opts));
        Assert.IsTrue(root.TryGetProperty("scrollbar", out var sb));
        Assert.AreEqual("hidden", sb.GetProperty("vertical").GetString());
        Assert.AreEqual(8, sb.GetProperty("horizontalScrollbarSize").GetInt32());
    }

    [TestMethod]
    public void GuidesOptions_BoolOrString_BracketPairs()
    {
        var opts = new MonacoEditorOptions
        {
            Guides = new GuidesOptions
            {
                BracketPairs = "active",
                Indentation = true,
            }
        };

        var root = ParseElement(Serialize(opts));
        var guides = root.GetProperty("guides");
        Assert.AreEqual("active", guides.GetProperty("bracketPairs").GetString());
        Assert.AreEqual(JsonValueKind.True, guides.GetProperty("indentation").ValueKind);
    }

    [TestMethod]
    public void RulerOption_ImplicitFromInt_Serialises()
    {
        RulerOption r = 80;
        Assert.AreEqual(80, r.Column);
    }

    [TestMethod]
    public void Rulers_Array_Serialises()
    {
        var opts = new MonacoEditorOptions { Rulers = [80, 120] };
        var root = ParseElement(Serialize(opts));

        Assert.IsTrue(root.TryGetProperty("rulers", out var rulers));
        Assert.AreEqual(JsonValueKind.Array, rulers.ValueKind);
        Assert.AreEqual(80, rulers[0].GetProperty("column").GetInt32());
        Assert.AreEqual(120, rulers[1].GetProperty("column").GetInt32());
    }

    [TestMethod]
    public void PropertyChange_RaisesPropertyChanged()
    {
        var opts = new MonacoEditorOptions();
        string? changedName = null;
        opts.PropertyChanged += (_, e) => changedName = e.PropertyName;

        opts.FontSize = 18;

        Assert.AreEqual(nameof(MonacoEditorOptions.FontSize), changedName);
    }

    [TestMethod]
    public void SubOptionPropertyChange_BubblesUpToParent()
    {
        var opts = new MonacoEditorOptions
        {
            Minimap = new MinimapOptions()
        };

        bool parentFired = false;
        opts.PropertyChanged += (_, _) => parentFired = true;

        opts.Minimap.Enabled = false;

        Assert.IsTrue(parentFired, "Change to sub-option should bubble up to MonacoEditorOptions.PropertyChanged");
    }

    [TestMethod]
    public void SubOption_Detached_NoLongerBubbles()
    {
        var minimap = new MinimapOptions();
        var opts = new MonacoEditorOptions { Minimap = minimap };

        // Detach
        opts.Minimap = null;

        int fireCount = 0;
        opts.PropertyChanged += (_, _) => fireCount++;

        // Mutate the detached sub-option — should NOT bubble
        minimap.Enabled = false;

        Assert.AreEqual(0, fireCount, "Detached sub-option changes should not bubble");
    }
}

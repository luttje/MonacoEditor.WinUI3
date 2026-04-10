namespace MonacoEditor.WinUI3;

/// <summary>Possible values for <see cref="MonacoEditorOptions.AcceptSuggestionOnEnter"/>.</summary>
public static class AcceptSuggestionOnEnter
{
    public const string Off = "off";
    public const string On = "on";
    public const string Smart = "smart";
}

/// <summary>Possible values for <see cref="MonacoEditorOptions.AccessibilitySupport"/>.</summary>
public static class AccessibilitySupport
{
    public const string Off = "off";
    public const string On = "on";
    public const string Auto = "auto";
}

/// <summary>Possible values for auto-closing bracket/comment/quote options.</summary>
public static class AutoClosingStrategy
{
    public const string Always = "always";
    public const string LanguageDefined = "languageDefined";
    public const string BeforeWhitespace = "beforeWhitespace";
    public const string Never = "never";
}

/// <summary>Possible values for auto-closing delete/overtype options.</summary>
public static class AutoClosingEditStrategy
{
    public const string Always = "always";
    public const string Auto = "auto";
    public const string Never = "never";
}

/// <summary>Possible values for <see cref="MonacoEditorOptions.AutoIndent"/>.</summary>
public static class AutoIndent
{
    public const string None = "none";
    public const string Keep = "keep";
    public const string Brackets = "brackets";
    public const string Advanced = "advanced";
    public const string Full = "full";
}

/// <summary>Possible values for <see cref="MonacoEditorOptions.AutoSurround"/>.</summary>
public static class AutoSurround
{
    public const string LanguageDefined = "languageDefined";
    public const string Quotes = "quotes";
    public const string Brackets = "brackets";
    public const string Never = "never";
}

/// <summary>Possible values for <see cref="MonacoEditorOptions.ColorDecoratorsActivatedOn"/>.</summary>
public static class ColorDecoratorsActivatedOn
{
    public const string ClickAndHover = "clickAndHover";
    public const string Click = "click";
    public const string Hover = "hover";
}

/// <summary>Possible values for <see cref="MonacoEditorOptions.CursorBlinking"/>.</summary>
public static class CursorBlinking
{
    public const string Blink = "blink";
    public const string Smooth = "smooth";
    public const string Phase = "phase";
    public const string Expand = "expand";
    public const string Solid = "solid";
}

/// <summary>Possible values for <see cref="MonacoEditorOptions.CursorSmoothCaretAnimation"/>.</summary>
public static class CursorSmoothCaretAnimation
{
    public const string Off = "off";
    public const string On = "on";
    public const string Explicit = "explicit";
}

/// <summary>Possible values for <see cref="MonacoEditorOptions.CursorStyle"/> and <see cref="MonacoEditorOptions.OvertypeCursorStyle"/>.</summary>
public static class CursorStyle
{
    public const string Line = "line";
    public const string Block = "block";
    public const string Underline = "underline";
    public const string LineThin = "line-thin";
    public const string BlockOutline = "block-outline";
    public const string UnderlineThin = "underline-thin";
}

/// <summary>Possible values for <see cref="MonacoEditorOptions.CursorSurroundingLinesStyle"/>.</summary>
public static class CursorSurroundingLinesStyle
{
    public const string Default = "default";
    public const string All = "all";
}

/// <summary>Possible values for <see cref="MonacoEditorOptions.DefaultColorDecorators"/>.</summary>
public static class DefaultColorDecorators
{
    public const string Auto = "auto";
    public const string Always = "always";
    public const string Never = "never";
}

/// <summary>Possible values for <see cref="DropIntoEditorOptions.ShowDropSelector"/>.</summary>
public static class DropShowSelector
{
    public const string AfterDrop = "afterDrop";
    public const string Never = "never";
}

/// <summary>Possible values for <see cref="MonacoEditorOptions.ExperimentalGpuAcceleration"/>.</summary>
public static class ExperimentalGpuAcceleration
{
    public const string Off = "off";
    public const string On = "on";
}

/// <summary>Possible values for <see cref="MonacoEditorOptions.ExperimentalWhitespaceRendering"/>.</summary>
public static class ExperimentalWhitespaceRendering
{
    public const string Off = "off";
    public const string Svg = "svg";
    public const string Font = "font";
}

/// <summary>Possible values for <see cref="MonacoEditorOptions.FoldingStrategy"/>.</summary>
public static class FoldingStrategy
{
    public const string Auto = "auto";
    public const string Indentation = "indentation";
}

/// <summary>Possible values for <see cref="GotoLocationOptions"/> multiple-match properties.</summary>
public static class GotoLocationValues
{
    public const string Peek = "peek";
    public const string GotoAndPeek = "gotoAndPeek";
    public const string Goto = "goto";
}

/// <summary>Possible values for <see cref="InlayHintsOptions.Enabled"/>.</summary>
public static class InlayHintsEnabled
{
    public const string On = "on";
    public const string Off = "off";
    public const string OffUnlessPressed = "offUnlessPressed";
    public const string OnUnlessPressed = "onUnlessPressed";
}

/// <summary>Possible values for <see cref="InlineSuggestOptions.Mode"/>.</summary>
public static class InlineSuggestMode
{
    public const string Prefix = "prefix";
    public const string Subword = "subword";
    public const string SubwordSmart = "subwordSmart";
}

/// <summary>Possible values for <see cref="InlineSuggestOptions.ShowToolbar"/>.</summary>
public static class InlineSuggestToolbar
{
    public const string Always = "always";
    public const string OnHover = "onHover";
    public const string Never = "never";
}

/// <summary>
/// Possible values for <see cref="MonacoEditorOptions.LineNumbers"/>.
/// Note: the function variant of <c>LineNumbersType</c> is not supported via JSON binding.
/// </summary>
public static class LineNumbers
{
    public const string On = "on";
    public const string Off = "off";
    public const string Relative = "relative";
    public const string Interval = "interval";
}

/// <summary>Possible values for <see cref="MonacoEditorOptions.MatchBrackets"/>.</summary>
public static class MatchBrackets
{
    public const string Always = "always";
    public const string Near = "near";
    public const string Never = "never";
}

/// <summary>Possible values for <see cref="MinimapOptions.Autohide"/>.</summary>
public static class MinimapAutohide
{
    public const string None = "none";
    public const string Mouseover = "mouseover";
    public const string Scroll = "scroll";
}

/// <summary>Possible values for <see cref="MinimapOptions.ShowSlider"/>.</summary>
public static class MinimapShowSlider
{
    public const string Always = "always";
    public const string Mouseover = "mouseover";
}

/// <summary>Possible values for <see cref="MinimapOptions.Side"/>.</summary>
public static class MinimapSide
{
    public const string Right = "right";
    public const string Left = "left";
}

/// <summary>Possible values for <see cref="MinimapOptions.Size"/>.</summary>
public static class MinimapSize
{
    public const string Proportional = "proportional";
    public const string Fill = "fill";
    public const string Fit = "fit";
}

/// <summary>Possible values for <see cref="MonacoEditorOptions.MouseMiddleClickAction"/>.</summary>
public static class MouseMiddleClickAction
{
    public const string Default = "default";
    public const string OpenLink = "openLink";
    public const string CtrlLeftClick = "ctrlLeftClick";
}

/// <summary>Possible values for <see cref="MonacoEditorOptions.MouseStyle"/>.</summary>
public static class MouseStyle
{
    public const string Default = "default";
    public const string Text = "text";
    public const string Copy = "copy";
}

/// <summary>Possible values for <see cref="MonacoEditorOptions.MultiCursorModifier"/>.</summary>
public static class MultiCursorModifier
{
    public const string CtrlCmd = "ctrlCmd";
    public const string Alt = "alt";
}

/// <summary>Possible values for <see cref="MonacoEditorOptions.MultiCursorPaste"/>.</summary>
public static class MultiCursorPaste
{
    public const string Spread = "spread";
    public const string Full = "full";
}

/// <summary>Possible values for <see cref="MonacoEditorOptions.OccurrencesHighlight"/>.</summary>
public static class OccurrencesHighlight
{
    public const string Off = "off";
    public const string SingleFile = "singleFile";
    public const string MultiFile = "multiFile";
}

/// <summary>Possible values for <see cref="PasteAsOptions.ShowPasteSelector"/>.</summary>
public static class PasteShowSelector
{
    public const string AfterPaste = "afterPaste";
    public const string Never = "never";
}

/// <summary>Possible values for <see cref="MonacoEditorOptions.PeekWidgetDefaultFocus"/>.</summary>
public static class PeekWidgetDefaultFocus
{
    public const string Tree = "tree";
    public const string Editor = "editor";
}

/// <summary>Possible values for <see cref="QuickSuggestionsOptions"/> per-context properties.</summary>
public static class QuickSuggestionsValue
{
    public const string On = "on";
    public const string Inline = "inline";
    public const string Off = "off";
}

/// <summary>Possible values for <see cref="MonacoEditorOptions.RenderFinalNewline"/>.</summary>
public static class RenderFinalNewline
{
    public const string On = "on";
    public const string Off = "off";
    public const string Dimmed = "dimmed";
}

/// <summary>Possible values for <see cref="MonacoEditorOptions.RenderLineHighlight"/>.</summary>
public static class RenderLineHighlight
{
    public const string None = "none";
    public const string Gutter = "gutter";
    public const string Line = "line";
    public const string All = "all";
}

/// <summary>Possible values for <see cref="MonacoEditorOptions.RenderValidationDecorations"/>.</summary>
public static class RenderValidationDecorations
{
    public const string Editable = "editable";
    public const string On = "on";
    public const string Off = "off";
}

/// <summary>Possible values for <see cref="MonacoEditorOptions.RenderWhitespace"/>.</summary>
public static class RenderWhitespace
{
    public const string None = "none";
    public const string Boundary = "boundary";
    public const string Selection = "selection";
    public const string Trailing = "trailing";
    public const string All = "all";
}

/// <summary>Possible values for <see cref="ScrollbarOptions.Vertical"/> and <see cref="ScrollbarOptions.Horizontal"/>.</summary>
public static class ScrollbarVisibility
{
    public const string Auto = "auto";
    public const string Visible = "visible";
    public const string Hidden = "hidden";
}

/// <summary>Possible values for <see cref="MonacoEditorOptions.ShowFoldingControls"/>.</summary>
public static class ShowFoldingControls
{
    public const string Always = "always";
    public const string Never = "never";
    public const string Mouseover = "mouseover";
}

/// <summary>Possible values for <see cref="LightbulbOptions.Enabled"/>.</summary>
public static class ShowLightbulbIconMode
{
    public const string Off = "off";
    public const string OnCode = "onCode";
    public const string On = "on";
}

/// <summary>Possible values for <see cref="MonacoEditorOptions.SnippetSuggestions"/>.</summary>
public static class SnippetSuggestions
{
    public const string None = "none";
    public const string Top = "top";
    public const string Bottom = "bottom";
    public const string Inline = "inline";
}

/// <summary>Possible values for <see cref="StickyScrollOptions.DefaultModel"/>.</summary>
public static class StickyScrollDefaultModel
{
    public const string OutlineModel = "outlineModel";
    public const string FoldingProviderModel = "foldingProviderModel";
    public const string IndentationModel = "indentationModel";
}

/// <summary>Possible values for <see cref="SuggestOptions.InsertMode"/>.</summary>
public static class SuggestInsertMode
{
    public const string Insert = "insert";
    public const string Replace = "replace";
}

/// <summary>Possible values for <see cref="SuggestOptions.PreviewMode"/>.</summary>
public static class SuggestPreviewMode
{
    public const string Prefix = "prefix";
    public const string Subword = "subword";
    public const string SubwordSmart = "subwordSmart";
}

/// <summary>Possible values for <see cref="SuggestOptions.SelectionMode"/>.</summary>
public static class SuggestSelectionMode
{
    public const string Always = "always";
    public const string Never = "never";
    public const string WhenTriggerCharacter = "whenTriggerCharacter";
    public const string WhenQuickSuggestion = "whenQuickSuggestion";
}

/// <summary>Possible values for <see cref="MonacoEditorOptions.SuggestSelection"/>.</summary>
public static class SuggestSelection
{
    public const string First = "first";
    public const string RecentlyUsed = "recentlyUsed";
    public const string RecentlyUsedByPrefix = "recentlyUsedByPrefix";
}

/// <summary>Possible values for <see cref="MonacoEditorOptions.TabCompletion"/>.</summary>
public static class TabCompletion
{
    public const string On = "on";
    public const string Off = "off";
    public const string OnlySnippets = "onlySnippets";
}

/// <summary>Possible values for <see cref="MonacoEditorOptions.UnusualLineTerminators"/>.</summary>
public static class UnusualLineTerminators
{
    public const string Off = "off";
    public const string Auto = "auto";
    public const string Prompt = "prompt";
}

/// <summary>Possible values for <see cref="MonacoEditorOptions.WordBasedSuggestions"/>.</summary>
public static class WordBasedSuggestions
{
    public const string Off = "off";
    public const string CurrentDocument = "currentDocument";
    public const string MatchingDocuments = "matchingDocuments";
    public const string AllDocuments = "allDocuments";
}

/// <summary>Possible values for <see cref="MonacoEditorOptions.WordBreak"/>.</summary>
public static class WordBreak
{
    public const string Normal = "normal";
    public const string KeepAll = "keepAll";
}

/// <summary>Possible values for <see cref="MonacoEditorOptions.WordWrap"/>.</summary>
public static class WordWrap
{
    public const string Off = "off";
    public const string On = "on";
    public const string WordWrapColumn = "wordWrapColumn";
    public const string Bounded = "bounded";
}

/// <summary>Possible values for <see cref="MonacoEditorOptions.WordWrapOverride1"/> and <see cref="MonacoEditorOptions.WordWrapOverride2"/>.</summary>
public static class WordWrapOverride
{
    public const string Off = "off";
    public const string On = "on";
    public const string Inherit = "inherit";
}

/// <summary>Possible values for <see cref="MonacoEditorOptions.WrappingIndent"/>.</summary>
public static class WrappingIndent
{
    public const string None = "none";
    public const string Same = "same";
    public const string Indent = "indent";
    public const string DeepIndent = "deepIndent";
}

/// <summary>Possible values for <see cref="MonacoEditorOptions.WrappingStrategy"/>.</summary>
public static class WrappingStrategy
{
    public const string Simple = "simple";
    public const string Advanced = "advanced";
}

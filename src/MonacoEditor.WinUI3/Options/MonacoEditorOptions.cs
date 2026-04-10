using System.Text.Json;
using System.Text.Json.Serialization;

namespace MonacoEditor.WinUI3;

/// <summary>
/// Typed configuration object covering the full
/// <c>IStandaloneEditorConstructionOptions</c> surface of the Monaco Editor.
/// </summary>
/// <remarks>
/// Assign an instance to <see cref="MonacoEditorControl.Options"/>; the control will push
/// the serialized options to Monaco immediately and re-push whenever any property changes.
/// Because this class implements <see cref="System.ComponentModel.INotifyPropertyChanged"/>
/// (via <see cref="OptionsBase"/>), all properties support XAML two-way data binding.
/// <para>
/// The following properties are intentionally excluded because they are already exposed as
/// first-class dependency properties on <see cref="MonacoEditorControl"/>:
/// <c>readOnly</c>&#160;→&#160;<see cref="MonacoEditorControl.IsReadOnly"/>,
/// <c>value</c>&#160;→&#160;<see cref="MonacoEditorControl.Text"/>,
/// <c>language</c>&#160;→&#160;<see cref="MonacoEditorControl.EditorLanguage"/>,
/// <c>theme</c>&#160;→&#160;<see cref="MonacoEditorControl.EditorTheme"/>.
/// </para>
/// </remarks>
public sealed class MonacoEditorOptions : OptionsBase
{
    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    };

    /// <summary>Serializes this options object to the compact JSON string that Monaco expects.</summary>
    internal string Serialize() => JsonSerializer.Serialize(this, SerializerOptions);

    #region Sub-option objects

    private BracketPairColorizationOptions? _bracketPairColorization;
    private CommentsOptions? _comments;
    private DimensionOptions? _dimension;
    private DropIntoEditorOptions? _dropIntoEditor;
    private FindOptions? _find;
    private GotoLocationOptions? _gotoLocation;
    private GuidesOptions? _guides;
    private HoverOptions? _hover;
    private InlayHintsOptions? _inlayHints;
    private InlineSuggestOptions? _inlineSuggest;
    private LightbulbOptions? _lightbulb;
    private MinimapOptions? _minimap;
    private PaddingOptions? _padding;
    private ParameterHintsOptions? _parameterHints;
    private PasteAsOptions? _pasteAs;
    private ScrollbarOptions? _scrollbar;
    private SmartSelectOptions? _smartSelect;
    private StickyScrollOptions? _stickyScroll;
    private SuggestOptions? _suggest;
    private UnicodeHighlightOptions? _unicodeHighlight;
    private MonacoMarkdownString? _readOnlyMessage;

    /// <summary>Controls bracket pair colorization.</summary>
    public BracketPairColorizationOptions? BracketPairColorization
    {
        get => _bracketPairColorization;
        set { UnsubscribeFromChild(_bracketPairColorization); SetProperty(ref _bracketPairColorization, value); SubscribeToChild(_bracketPairColorization); }
    }

    /// <summary>Controls comment insertion behaviour.</summary>
    public CommentsOptions? Comments
    {
        get => _comments;
        set { UnsubscribeFromChild(_comments); SetProperty(ref _comments, value); SubscribeToChild(_comments); }
    }

    /// <summary>Overrides the editor's width and height.</summary>
    public DimensionOptions? Dimension
    {
        get => _dimension;
        set { UnsubscribeFromChild(_dimension); SetProperty(ref _dimension, value); SubscribeToChild(_dimension); }
    }

    /// <summary>Controls drag-and-drop paste behaviour.</summary>
    public DropIntoEditorOptions? DropIntoEditor
    {
        get => _dropIntoEditor;
        set { UnsubscribeFromChild(_dropIntoEditor); SetProperty(ref _dropIntoEditor, value); SubscribeToChild(_dropIntoEditor); }
    }

    /// <summary>Controls the find (search) widget.</summary>
    public FindOptions? Find
    {
        get => _find;
        set { UnsubscribeFromChild(_find); SetProperty(ref _find, value); SubscribeToChild(_find); }
    }

    /// <summary>Controls go-to-definition/references behaviour.</summary>
    public GotoLocationOptions? GotoLocation
    {
        get => _gotoLocation;
        set { UnsubscribeFromChild(_gotoLocation); SetProperty(ref _gotoLocation, value); SubscribeToChild(_gotoLocation); }
    }

    /// <summary>Controls indent guide rendering.</summary>
    public GuidesOptions? Guides
    {
        get => _guides;
        set { UnsubscribeFromChild(_guides); SetProperty(ref _guides, value); SubscribeToChild(_guides); }
    }

    /// <summary>Controls the hover tooltip.</summary>
    public HoverOptions? Hover
    {
        get => _hover;
        set { UnsubscribeFromChild(_hover); SetProperty(ref _hover, value); SubscribeToChild(_hover); }
    }

    /// <summary>Controls inlay hints.</summary>
    public InlayHintsOptions? InlayHints
    {
        get => _inlayHints;
        set { UnsubscribeFromChild(_inlayHints); SetProperty(ref _inlayHints, value); SubscribeToChild(_inlayHints); }
    }

    /// <summary>Controls inline suggestions (ghost text).</summary>
    public InlineSuggestOptions? InlineSuggest
    {
        get => _inlineSuggest;
        set { UnsubscribeFromChild(_inlineSuggest); SetProperty(ref _inlineSuggest, value); SubscribeToChild(_inlineSuggest); }
    }

    /// <summary>Controls the lightbulb (code-actions) indicator.</summary>
    public LightbulbOptions? Lightbulb
    {
        get => _lightbulb;
        set { UnsubscribeFromChild(_lightbulb); SetProperty(ref _lightbulb, value); SubscribeToChild(_lightbulb); }
    }

    /// <summary>Controls the minimap.</summary>
    public MinimapOptions? Minimap
    {
        get => _minimap;
        set { UnsubscribeFromChild(_minimap); SetProperty(ref _minimap, value); SubscribeToChild(_minimap); }
    }

    /// <summary>Controls padding around the content area.</summary>
    public PaddingOptions? Padding
    {
        get => _padding;
        set { UnsubscribeFromChild(_padding); SetProperty(ref _padding, value); SubscribeToChild(_padding); }
    }

    /// <summary>Controls parameter hint tooltips.</summary>
    public ParameterHintsOptions? ParameterHints
    {
        get => _parameterHints;
        set { UnsubscribeFromChild(_parameterHints); SetProperty(ref _parameterHints, value); SubscribeToChild(_parameterHints); }
    }

    /// <summary>Controls the paste-as functionality.</summary>
    public PasteAsOptions? PasteAs
    {
        get => _pasteAs;
        set { UnsubscribeFromChild(_pasteAs); SetProperty(ref _pasteAs, value); SubscribeToChild(_pasteAs); }
    }

    /// <summary>Controls the scrollbars.</summary>
    public ScrollbarOptions? Scrollbar
    {
        get => _scrollbar;
        set { UnsubscribeFromChild(_scrollbar); SetProperty(ref _scrollbar, value); SubscribeToChild(_scrollbar); }
    }

    /// <summary>Controls smart selection (expand/shrink selection).</summary>
    public SmartSelectOptions? SmartSelect
    {
        get => _smartSelect;
        set { UnsubscribeFromChild(_smartSelect); SetProperty(ref _smartSelect, value); SubscribeToChild(_smartSelect); }
    }

    /// <summary>Controls sticky scroll (pinned scope lines).</summary>
    public StickyScrollOptions? StickyScroll
    {
        get => _stickyScroll;
        set { UnsubscribeFromChild(_stickyScroll); SetProperty(ref _stickyScroll, value); SubscribeToChild(_stickyScroll); }
    }

    /// <summary>Controls the suggestion (IntelliSense) widget.</summary>
    public SuggestOptions? Suggest
    {
        get => _suggest;
        set { UnsubscribeFromChild(_suggest); SetProperty(ref _suggest, value); SubscribeToChild(_suggest); }
    }

    /// <summary>Controls Unicode character highlighting.</summary>
    public UnicodeHighlightOptions? UnicodeHighlight
    {
        get => _unicodeHighlight;
        set { UnsubscribeFromChild(_unicodeHighlight); SetProperty(ref _unicodeHighlight, value); SubscribeToChild(_unicodeHighlight); }
    }

    /// <summary>
    /// Message shown when the user tries to edit a read-only model.
    /// Excluded from serialization when <c>null</c>.
    /// </summary>
    public MonacoMarkdownString? ReadOnlyMessage
    {
        get => _readOnlyMessage;
        set { UnsubscribeFromChild(_readOnlyMessage); SetProperty(ref _readOnlyMessage, value); SubscribeToChild(_readOnlyMessage); }
    }

    #endregion

    #region A–C

    private bool? _acceptSuggestionOnCommitCharacter;
    /// <summary>Accept suggestions on commit characters (e.g. <c>;</c>). Defaults to <c>true</c>.</summary>
    public bool? AcceptSuggestionOnCommitCharacter { get => _acceptSuggestionOnCommitCharacter; set => SetProperty(ref _acceptSuggestionOnCommitCharacter, value); }

    private string? _acceptSuggestionOnEnter;
    /// <summary>
    /// Accept suggestions on ENTER.
    /// Use <see cref="MonacoEditor.WinUI3.AcceptSuggestionOnEnter"/> constants.
    /// </summary>
    public string? AcceptSuggestionOnEnter { get => _acceptSuggestionOnEnter; set => SetProperty(ref _acceptSuggestionOnEnter, value); }

    private int? _accessibilityPageSize;
    /// <summary>Number of lines accessible to screen readers. Defaults to 10.</summary>
    public int? AccessibilityPageSize { get => _accessibilityPageSize; set => SetProperty(ref _accessibilityPageSize, value); }

    private string? _accessibilitySupport;
    /// <summary>
    /// Accessibility mode. Use <see cref="MonacoEditor.WinUI3.AccessibilitySupport"/> constants.
    /// Defaults to <c>"auto"</c>.
    /// </summary>
    public string? AccessibilitySupport { get => _accessibilitySupport; set => SetProperty(ref _accessibilitySupport, value); }

    private string? _ariaLabel;
    /// <summary>ARIA label for the editor's textarea (accessibility).</summary>
    public string? AriaLabel { get => _ariaLabel; set => SetProperty(ref _ariaLabel, value); }

    private bool? _ariaRequired;
    /// <summary>Whether the editor textarea element is required (ARIA).</summary>
    public bool? AriaRequired { get => _ariaRequired; set => SetProperty(ref _ariaRequired, value); }

    private string? _autoClosingBrackets;
    /// <summary>
    /// Auto-closing of brackets.
    /// Use <see cref="AutoClosingStrategy"/> constants. Defaults to <c>"languageDefined"</c>.
    /// </summary>
    public string? AutoClosingBrackets { get => _autoClosingBrackets; set => SetProperty(ref _autoClosingBrackets, value); }

    private string? _autoClosingComments;
    /// <summary>
    /// Auto-closing of comments.
    /// Use <see cref="AutoClosingStrategy"/> constants. Defaults to <c>"languageDefined"</c>.
    /// </summary>
    public string? AutoClosingComments { get => _autoClosingComments; set => SetProperty(ref _autoClosingComments, value); }

    private string? _autoClosingDelete;
    /// <summary>
    /// Controls whether the editor should automatically close brackets when the user deletes.
    /// Use <see cref="AutoClosingEditStrategy"/> constants. Defaults to <c>"auto"</c>.
    /// </summary>
    public string? AutoClosingDelete { get => _autoClosingDelete; set => SetProperty(ref _autoClosingDelete, value); }

    private string? _autoClosingOvertype;
    /// <summary>
    /// Controls whether the editor should automatically overtype closing brackets.
    /// Use <see cref="AutoClosingEditStrategy"/> constants. Defaults to <c>"auto"</c>.
    /// </summary>
    public string? AutoClosingOvertype { get => _autoClosingOvertype; set => SetProperty(ref _autoClosingOvertype, value); }

    private string? _autoClosingQuotes;
    /// <summary>
    /// Auto-closing of quotes.
    /// Use <see cref="AutoClosingStrategy"/> constants. Defaults to <c>"languageDefined"</c>.
    /// </summary>
    public string? AutoClosingQuotes { get => _autoClosingQuotes; set => SetProperty(ref _autoClosingQuotes, value); }

    private string? _autoIndent;
    /// <summary>
    /// Controls auto-indentation.
    /// Use <see cref="MonacoEditor.WinUI3.AutoIndent"/> constants. Defaults to <c>"advanced"</c>.
    /// </summary>
    public string? AutoIndent { get => _autoIndent; set => SetProperty(ref _autoIndent, value); }

    private string? _autoSurround;
    /// <summary>
    /// Auto-surround selection with brackets/quotes.
    /// Use <see cref="MonacoEditor.WinUI3.AutoSurround"/> constants. Defaults to <c>"languageDefined"</c>.
    /// </summary>
    public string? AutoSurround { get => _autoSurround; set => SetProperty(ref _autoSurround, value); }

    private bool? _automaticLayout;
    /// <summary>
    /// Automatically adjust the editor's dimensions when the container is resized.
    /// Defaults to <c>false</c>.
    /// </summary>
    public bool? AutomaticLayout { get => _automaticLayout; set => SetProperty(ref _automaticLayout, value); }

    private bool? _codeLens;
    /// <summary>Enable CodeLens. Defaults to <c>true</c>.</summary>
    public bool? CodeLens { get => _codeLens; set => SetProperty(ref _codeLens, value); }

    private string? _codeLensStyle;
    /// <summary>CodeLens font style (<c>"border"</c> or <c>"letter"</c>). Defaults to <c>"letter"</c>.</summary>
    public string? CodeLensStyle { get => _codeLensStyle; set => SetProperty(ref _codeLensStyle, value); }

    private bool? _colorDecorators;
    /// <summary>Enable inline color decorators. Defaults to <c>true</c>.</summary>
    public bool? ColorDecorators { get => _colorDecorators; set => SetProperty(ref _colorDecorators, value); }

    private string? _colorDecoratorsActivatedOn;
    /// <summary>
    /// When color decorators activate.
    /// Use <see cref="MonacoEditor.WinUI3.ColorDecoratorsActivatedOn"/> constants.
    /// </summary>
    public string? ColorDecoratorsActivatedOn { get => _colorDecoratorsActivatedOn; set => SetProperty(ref _colorDecoratorsActivatedOn, value); }

    private int? _colorDecoratorsLimit;
    /// <summary>Maximum number of color decorators to render. Defaults to 500.</summary>
    public int? ColorDecoratorsLimit { get => _colorDecoratorsLimit; set => SetProperty(ref _colorDecoratorsLimit, value); }

    private bool? _columnSelection;
    /// <summary>Enable column (block) selection via mouse. Defaults to <c>false</c>.</summary>
    public bool? ColumnSelection { get => _columnSelection; set => SetProperty(ref _columnSelection, value); }

    private bool? _contextmenu;
    /// <summary>Enable the context menu. Defaults to <c>true</c>.</summary>
    public bool? Contextmenu { get => _contextmenu; set => SetProperty(ref _contextmenu, value); }

    private bool? _copyWithSyntaxHighlighting;
    /// <summary>Copy with syntax highlighting. Defaults to <c>true</c>.</summary>
    public bool? CopyWithSyntaxHighlighting { get => _copyWithSyntaxHighlighting; set => SetProperty(ref _copyWithSyntaxHighlighting, value); }

    private string? _cursorBlinking;
    /// <summary>
    /// Cursor blinking animation.
    /// Use <see cref="MonacoEditor.WinUI3.CursorBlinking"/> constants. Defaults to <c>"blink"</c>.
    /// </summary>
    public string? CursorBlinking { get => _cursorBlinking; set => SetProperty(ref _cursorBlinking, value); }

    private string? _cursorSmoothCaretAnimation;
    /// <summary>
    /// Smooth caret animation.
    /// Use <see cref="MonacoEditor.WinUI3.CursorSmoothCaretAnimation"/> constants. Defaults to <c>"off"</c>.
    /// </summary>
    public string? CursorSmoothCaretAnimation { get => _cursorSmoothCaretAnimation; set => SetProperty(ref _cursorSmoothCaretAnimation, value); }

    private string? _cursorStyle;
    /// <summary>
    /// Cursor shape.
    /// Use <see cref="MonacoEditor.WinUI3.CursorStyle"/> constants. Defaults to <c>"line"</c>.
    /// </summary>
    public string? CursorStyle { get => _cursorStyle; set => SetProperty(ref _cursorStyle, value); }

    private int? _cursorSurroundingLines;
    /// <summary>Number of lines to keep visible above/below the cursor. Defaults to 0.</summary>
    public int? CursorSurroundingLines { get => _cursorSurroundingLines; set => SetProperty(ref _cursorSurroundingLines, value); }

    private string? _cursorSurroundingLinesStyle;
    /// <summary>
    /// Controls for which context <see cref="CursorSurroundingLines"/> is enforced.
    /// Use <see cref="MonacoEditor.WinUI3.CursorSurroundingLinesStyle"/> constants.
    /// </summary>
    public string? CursorSurroundingLinesStyle { get => _cursorSurroundingLinesStyle; set => SetProperty(ref _cursorSurroundingLinesStyle, value); }

    private int? _cursorWidth;
    /// <summary>Width (px) of the cursor when <see cref="CursorStyle"/> is <c>"line"</c>.</summary>
    public int? CursorWidth { get => _cursorWidth; set => SetProperty(ref _cursorWidth, value); }

    #endregion

    #region D–F

    private bool? _defaultColorDecorators;
    /// <summary>Use default colour decorators. Defaults to <c>true</c>.</summary>
    public bool? DefaultColorDecorators { get => _defaultColorDecorators; set => SetProperty(ref _defaultColorDecorators, value); }

    private bool? _definitionLinkOpensInPeek;
    /// <summary>Open definitions in a peek widget. Defaults to <c>false</c>.</summary>
    public bool? DefinitionLinkOpensInPeek { get => _definitionLinkOpensInPeek; set => SetProperty(ref _definitionLinkOpensInPeek, value); }

    private bool? _detectIndentation;
    /// <summary>
    /// Auto-detect indentation from file content.
    /// Defaults to <c>true</c>. (Corresponds to <c>IGlobalEditorOptions</c>.)
    /// </summary>
    public bool? DetectIndentation { get => _detectIndentation; set => SetProperty(ref _detectIndentation, value); }

    private bool? _disableLayerHinting;
    /// <summary>Disable layer hinting (may improve performance). Defaults to <c>false</c>.</summary>
    public bool? DisableLayerHinting { get => _disableLayerHinting; set => SetProperty(ref _disableLayerHinting, value); }

    private bool? _disableMonospaceOptimizations;
    /// <summary>Disable monospace font optimisations. Defaults to <c>false</c>.</summary>
    public bool? DisableMonospaceOptimizations { get => _disableMonospaceOptimizations; set => SetProperty(ref _disableMonospaceOptimizations, value); }

    private bool? _domReadOnly;
    /// <summary>Sets the underlying <c>textarea</c> to read-only without disabling the editor.</summary>
    public bool? DomReadOnly { get => _domReadOnly; set => SetProperty(ref _domReadOnly, value); }

    private bool? _dragAndDrop;
    /// <summary>Enable drag-and-drop of text. Defaults to <c>false</c>.</summary>
    public bool? DragAndDrop { get => _dragAndDrop; set => SetProperty(ref _dragAndDrop, value); }

    private bool? _emptySelectionClipboard;
    /// <summary>Copy the entire line when the selection is empty. Defaults to <c>true</c>.</summary>
    public bool? EmptySelectionClipboard { get => _emptySelectionClipboard; set => SetProperty(ref _emptySelectionClipboard, value); }

    private string? _experimentalGpuAcceleration;
    /// <summary>
    /// GPU-accelerated rendering (experimental).
    /// Use <see cref="MonacoEditor.WinUI3.ExperimentalGpuAcceleration"/> constants.
    /// </summary>
    public string? ExperimentalGpuAcceleration { get => _experimentalGpuAcceleration; set => SetProperty(ref _experimentalGpuAcceleration, value); }

    private string? _experimentalWhitespaceRendering;
    /// <summary>
    /// Whitespace rendering mode (experimental).
    /// Use <see cref="MonacoEditor.WinUI3.ExperimentalWhitespaceRendering"/> constants.
    /// </summary>
    public string? ExperimentalWhitespaceRendering { get => _experimentalWhitespaceRendering; set => SetProperty(ref _experimentalWhitespaceRendering, value); }

    private string? _extraEditorClassName;
    /// <summary>Extra CSS class names to apply to the editor's DOM element.</summary>
    public string? ExtraEditorClassName { get => _extraEditorClassName; set => SetProperty(ref _extraEditorClassName, value); }

    private double? _fastScrollSensitivity;
    /// <summary>Scroll speed multiplier when holding the <c>Alt</c> key. Defaults to 5.</summary>
    public double? FastScrollSensitivity { get => _fastScrollSensitivity; set => SetProperty(ref _fastScrollSensitivity, value); }

    private bool? _fixedOverflowWidgets;
    /// <summary>Render overflow widgets in a fixed position. Defaults to <c>false</c>.</summary>
    public bool? FixedOverflowWidgets { get => _fixedOverflowWidgets; set => SetProperty(ref _fixedOverflowWidgets, value); }

    private bool? _folding;
    /// <summary>Enable code folding. Defaults to <c>true</c>.</summary>
    public bool? Folding { get => _folding; set => SetProperty(ref _folding, value); }

    private bool? _foldingHighlight;
    /// <summary>Highlight folded regions. Defaults to <c>true</c>.</summary>
    public bool? FoldingHighlight { get => _foldingHighlight; set => SetProperty(ref _foldingHighlight, value); }

    private bool? _foldingImportsByDefault;
    /// <summary>Auto-fold import sections. Defaults to <c>false</c>.</summary>
    public bool? FoldingImportsByDefault { get => _foldingImportsByDefault; set => SetProperty(ref _foldingImportsByDefault, value); }

    private int? _foldingMaximumRegions;
    /// <summary>Maximum number of foldable regions. Defaults to 5000.</summary>
    public int? FoldingMaximumRegions { get => _foldingMaximumRegions; set => SetProperty(ref _foldingMaximumRegions, value); }

    private string? _foldingStrategy;
    /// <summary>
    /// Folding strategy.
    /// Use <see cref="MonacoEditor.WinUI3.FoldingStrategy"/> constants. Defaults to <c>"auto"</c>.
    /// </summary>
    public string? FoldingStrategy { get => _foldingStrategy; set => SetProperty(ref _foldingStrategy, value); }

    private string? _fontFamily;
    /// <summary>Editor font family. Defaults to the platform default monospace font.</summary>
    public string? FontFamily { get => _fontFamily; set => SetProperty(ref _fontFamily, value); }

    private BoolOrString? _fontLigatures;
    /// <summary>
    /// Enable font ligatures, or specify a feature-settings string.
    /// Accepts <c>true</c>, <c>false</c>, or a CSS <c>font-feature-settings</c> value.
    /// </summary>
    public BoolOrString? FontLigatures { get => _fontLigatures; set => SetProperty(ref _fontLigatures, value); }

    private double? _fontSize;
    /// <summary>Editor font size (px). Defaults to 14.</summary>
    public double? FontSize { get => _fontSize; set => SetProperty(ref _fontSize, value); }

    private string? _fontStyle;
    /// <summary>Editor font style (e.g. <c>"italic"</c>). Defaults to empty string.</summary>
    public string? FontStyle { get => _fontStyle; set => SetProperty(ref _fontStyle, value); }

    private BoolOrString? _fontVariations;
    /// <summary>
    /// Configure font variations.
    /// Accepts <c>true</c> to use the current font family, <c>false</c> to disable, or a
    /// CSS <c>font-variation-settings</c> string.
    /// </summary>
    public BoolOrString? FontVariations { get => _fontVariations; set => SetProperty(ref _fontVariations, value); }

    private string? _fontWeight;
    /// <summary>Editor font weight. Defaults to <c>"normal"</c>.</summary>
    public string? FontWeight { get => _fontWeight; set => SetProperty(ref _fontWeight, value); }

    private bool? _formatOnPaste;
    /// <summary>Auto-format on paste. Defaults to <c>false</c>.</summary>
    public bool? FormatOnPaste { get => _formatOnPaste; set => SetProperty(ref _formatOnPaste, value); }

    private bool? _formatOnType;
    /// <summary>Auto-format on type. Defaults to <c>false</c>.</summary>
    public bool? FormatOnType { get => _formatOnType; set => SetProperty(ref _formatOnType, value); }

    #endregion

    #region G–L

    private bool? _glyphMargin;
    /// <summary>Enable the glyph margin. Defaults to <c>true</c>.</summary>
    public bool? GlyphMargin { get => _glyphMargin; set => SetProperty(ref _glyphMargin, value); }

    private bool? _hideCursorInOverviewRuler;
    /// <summary>Do not show the cursor in the overview ruler. Defaults to <c>false</c>.</summary>
    public bool? HideCursorInOverviewRuler { get => _hideCursorInOverviewRuler; set => SetProperty(ref _hideCursorInOverviewRuler, value); }

    private bool? _inDiffEditor;
    /// <summary>Whether the editor is hosted inside a diff editor. Defaults to <c>false</c>.</summary>
    public bool? InDiffEditor { get => _inDiffEditor; set => SetProperty(ref _inDiffEditor, value); }

    private bool? _inlineCompletionsAccessibilityVerbose;
    /// <summary>Verbose accessibility for inline completions. Defaults to <c>false</c>.</summary>
    public bool? InlineCompletionsAccessibilityVerbose { get => _inlineCompletionsAccessibilityVerbose; set => SetProperty(ref _inlineCompletionsAccessibilityVerbose, value); }

    private bool? _insertSpaces;
    /// <summary>
    /// Insert spaces instead of tabs when pressing TAB.
    /// Defaults to <c>true</c>. (Corresponds to <c>IGlobalEditorOptions</c>.)
    /// </summary>
    public bool? InsertSpaces { get => _insertSpaces; set => SetProperty(ref _insertSpaces, value); }

    private bool? _largeFileOptimizations;
    /// <summary>
    /// Special handling for large files. Defaults to <c>true</c>.
    /// (Corresponds to <c>IGlobalEditorOptions</c>.)
    /// </summary>
    public bool? LargeFileOptimizations { get => _largeFileOptimizations; set => SetProperty(ref _largeFileOptimizations, value); }

    private double? _letterSpacing;
    /// <summary>Letter spacing (px). Defaults to 0.</summary>
    public double? LetterSpacing { get => _letterSpacing; set => SetProperty(ref _letterSpacing, value); }

    private string? _lineDecorationsWidth;
    /// <summary>
    /// Width (px) for line decorations. Accepts a number as a string (<c>"10"</c>) or a
    /// CSS length (<c>"1.3ch"</c>).
    /// </summary>
    public string? LineDecorationsWidth { get => _lineDecorationsWidth; set => SetProperty(ref _lineDecorationsWidth, value); }

    private double? _lineHeight;
    /// <summary>Line height. Defaults to normal.</summary>
    public double? LineHeight { get => _lineHeight; set => SetProperty(ref _lineHeight, value); }

    private string? _lineNumbers;
    /// <summary>
    /// Control the rendering of line numbers.
    /// Use <see cref="MonacoEditor.WinUI3.LineNumbers"/> constants. Defaults to <c>"on"</c>.
    /// </summary>
    public string? LineNumbers { get => _lineNumbers; set => SetProperty(ref _lineNumbers, value); }

    private int? _lineNumbersMinChars;
    /// <summary>Reserved character count for line numbers. Defaults to 5.</summary>
    public int? LineNumbersMinChars { get => _lineNumbersMinChars; set => SetProperty(ref _lineNumbersMinChars, value); }

    private bool? _linkedEditing;
    /// <summary>Enable linked editing. Defaults to <c>false</c>.</summary>
    public bool? LinkedEditing { get => _linkedEditing; set => SetProperty(ref _linkedEditing, value); }

    private bool? _links;
    /// <summary>Enable link detection. Defaults to <c>true</c>.</summary>
    public bool? Links { get => _links; set => SetProperty(ref _links, value); }

    #endregion

    #region M–P

    private string? _matchBrackets;
    /// <summary>
    /// Highlight matching brackets.
    /// Use <see cref="MonacoEditor.WinUI3.MatchBrackets"/> constants. Defaults to <c>"always"</c>.
    /// </summary>
    public string? MatchBrackets { get => _matchBrackets; set => SetProperty(ref _matchBrackets, value); }

    private int? _maxTokenizationLineLength;
    /// <summary>
    /// Maximum line length for tokenization. Defaults to 20000.
    /// (Corresponds to <c>IGlobalEditorOptions</c>.)
    /// </summary>
    public int? MaxTokenizationLineLength { get => _maxTokenizationLineLength; set => SetProperty(ref _maxTokenizationLineLength, value); }

    private string? _mouseStyle;
    /// <summary>
    /// Mouse cursor style.
    /// Use <see cref="MonacoEditor.WinUI3.MouseStyle"/> constants. Defaults to <c>"text"</c>.
    /// </summary>
    public string? MouseStyle { get => _mouseStyle; set => SetProperty(ref _mouseStyle, value); }

    private double? _mouseWheelScrollSensitivity;
    /// <summary>Mouse-wheel scroll sensitivity multiplier. Defaults to 1.</summary>
    public double? MouseWheelScrollSensitivity { get => _mouseWheelScrollSensitivity; set => SetProperty(ref _mouseWheelScrollSensitivity, value); }

    private bool? _mouseWheelZoom;
    /// <summary>Zoom the font with Ctrl+mouse-wheel. Defaults to <c>false</c>.</summary>
    public bool? MouseWheelZoom { get => _mouseWheelZoom; set => SetProperty(ref _mouseWheelZoom, value); }

    private int? _multiCursorLimit;
    /// <summary>Maximum number of cursors. Defaults to 10000.</summary>
    public int? MultiCursorLimit { get => _multiCursorLimit; set => SetProperty(ref _multiCursorLimit, value); }

    private bool? _multiCursorMergeOverlapping;
    /// <summary>Merge overlapping cursors. Defaults to <c>true</c>.</summary>
    public bool? MultiCursorMergeOverlapping { get => _multiCursorMergeOverlapping; set => SetProperty(ref _multiCursorMergeOverlapping, value); }

    private string? _multiCursorModifier;
    /// <summary>
    /// Modifier key for multi-cursor via mouse.
    /// Use <see cref="MonacoEditor.WinUI3.MultiCursorModifier"/> constants. Defaults to <c>"alt"</c>.
    /// </summary>
    public string? MultiCursorModifier { get => _multiCursorModifier; set => SetProperty(ref _multiCursorModifier, value); }

    private string? _multiCursorPaste;
    /// <summary>
    /// Behaviour when pasting with multiple cursors.
    /// Use <see cref="MonacoEditor.WinUI3.MultiCursorPaste"/> constants. Defaults to <c>"spread"</c>.
    /// </summary>
    public string? MultiCursorPaste { get => _multiCursorPaste; set => SetProperty(ref _multiCursorPaste, value); }

    private string? _occurrencesHighlight;
    /// <summary>
    /// Highlight occurrences of the selected word.
    /// Use <see cref="MonacoEditor.WinUI3.OccurrencesHighlight"/> constants. Defaults to <c>"singleFile"</c>.
    /// </summary>
    public string? OccurrencesHighlight { get => _occurrencesHighlight; set => SetProperty(ref _occurrencesHighlight, value); }

    private bool? _overviewRulerBorder;
    /// <summary>Render a border around the overview ruler. Defaults to <c>true</c>.</summary>
    public bool? OverviewRulerBorder { get => _overviewRulerBorder; set => SetProperty(ref _overviewRulerBorder, value); }

    private int? _overviewRulerLanes;
    /// <summary>Number of lanes in the overview ruler (1–3). Defaults to 3.</summary>
    public int? OverviewRulerLanes { get => _overviewRulerLanes; set => SetProperty(ref _overviewRulerLanes, value); }

    private string? _overtypeCursorStyle;
    /// <summary>
    /// Cursor style in overtype mode.
    /// Use <see cref="MonacoEditor.WinUI3.CursorStyle"/> constants.
    /// </summary>
    public string? OvertypeCursorStyle { get => _overtypeCursorStyle; set => SetProperty(ref _overtypeCursorStyle, value); }

    private string? _peekWidgetDefaultFocus;
    /// <summary>
    /// Default focus element in peek widgets.
    /// Use <see cref="MonacoEditor.WinUI3.PeekWidgetDefaultFocus"/> constants.
    /// </summary>
    public string? PeekWidgetDefaultFocus { get => _peekWidgetDefaultFocus; set => SetProperty(ref _peekWidgetDefaultFocus, value); }

    private BoolOrQuickSuggestions? _quickSuggestions;
    /// <summary>
    /// Enable quick suggestions (IntelliSense) as you type.
    /// Set <c>true</c>, <c>false</c>, or a <see cref="QuickSuggestionsOptions"/> object.
    /// </summary>
    public BoolOrQuickSuggestions? QuickSuggestions { get => _quickSuggestions; set => SetProperty(ref _quickSuggestions, value); }

    private int? _quickSuggestionsDelay;
    /// <summary>Delay (ms) before quick suggestions appear. Defaults to 10.</summary>
    public int? QuickSuggestionsDelay { get => _quickSuggestionsDelay; set => SetProperty(ref _quickSuggestionsDelay, value); }

    #endregion

    #region R–S

    private bool? _renderControlCharacters;
    /// <summary>Render control characters. Defaults to <c>true</c>.</summary>
    public bool? RenderControlCharacters { get => _renderControlCharacters; set => SetProperty(ref _renderControlCharacters, value); }

    private string? _renderFinalNewline;
    /// <summary>
    /// Render a final newline at the end of the file.
    /// Use <see cref="MonacoEditor.WinUI3.RenderFinalNewline"/> constants. Defaults to <c>"on"</c>.
    /// </summary>
    public string? RenderFinalNewline { get => _renderFinalNewline; set => SetProperty(ref _renderFinalNewline, value); }

    private string? _renderLineHighlight;
    /// <summary>
    /// Highlight the current line.
    /// Use <see cref="MonacoEditor.WinUI3.RenderLineHighlight"/> constants. Defaults to <c>"line"</c>.
    /// </summary>
    public string? RenderLineHighlight { get => _renderLineHighlight; set => SetProperty(ref _renderLineHighlight, value); }

    private bool? _renderLineHighlightOnlyWhenFocus;
    /// <summary>Only highlight the current line when the editor is focused. Defaults to <c>false</c>.</summary>
    public bool? RenderLineHighlightOnlyWhenFocus { get => _renderLineHighlightOnlyWhenFocus; set => SetProperty(ref _renderLineHighlightOnlyWhenFocus, value); }

    private string? _renderValidationDecorations;
    /// <summary>
    /// Render validation decorations (errors, warnings).
    /// Use <see cref="MonacoEditor.WinUI3.RenderValidationDecorations"/> constants. Defaults to <c>"editable"</c>.
    /// </summary>
    public string? RenderValidationDecorations { get => _renderValidationDecorations; set => SetProperty(ref _renderValidationDecorations, value); }

    private string? _renderWhitespace;
    /// <summary>
    /// Render whitespace characters.
    /// Use <see cref="MonacoEditor.WinUI3.RenderWhitespace"/> constants. Defaults to <c>"selection"</c>.
    /// </summary>
    public string? RenderWhitespace { get => _renderWhitespace; set => SetProperty(ref _renderWhitespace, value); }

    private int? _revealHorizontalRightPadding;
    /// <summary>Horizontal padding (px) when revealing the cursor. Defaults to 30.</summary>
    public int? RevealHorizontalRightPadding { get => _revealHorizontalRightPadding; set => SetProperty(ref _revealHorizontalRightPadding, value); }

    private bool? _roundedSelection;
    /// <summary>Render selections with rounded corners. Defaults to <c>true</c>.</summary>
    public bool? RoundedSelection { get => _roundedSelection; set => SetProperty(ref _roundedSelection, value); }

    private RulerOption[]? _rulers;
    /// <summary>
    /// Vertical ruler lines to render. Use <c>new RulerOption[] { 80, 120 }</c> or
    /// <c>new[] { new RulerOption { Column = 80, Color = "#ff0000" } }</c>.
    /// </summary>
    public RulerOption[]? Rulers { get => _rulers; set => SetProperty(ref _rulers, value); }

    private bool? _screenReaderAnnounceInlineSuggestion;
    /// <summary>Have the screen reader announce inline suggestions. Defaults to <c>true</c>.</summary>
    public bool? ScreenReaderAnnounceInlineSuggestion { get => _screenReaderAnnounceInlineSuggestion; set => SetProperty(ref _screenReaderAnnounceInlineSuggestion, value); }

    private int? _scrollBeyondLastColumn;
    /// <summary>Number of columns to scroll beyond the last column. Defaults to 5.</summary>
    public int? ScrollBeyondLastColumn { get => _scrollBeyondLastColumn; set => SetProperty(ref _scrollBeyondLastColumn, value); }

    private bool? _scrollBeyondLastLine;
    /// <summary>Allow scrolling beyond the last line. Defaults to <c>true</c>.</summary>
    public bool? ScrollBeyondLastLine { get => _scrollBeyondLastLine; set => SetProperty(ref _scrollBeyondLastLine, value); }

    private bool? _scrollPredominantAxis;
    /// <summary>Scroll only along the predominant scroll axis. Defaults to <c>true</c>.</summary>
    public bool? ScrollPredominantAxis { get => _scrollPredominantAxis; set => SetProperty(ref _scrollPredominantAxis, value); }

    private bool? _selectOnLineNumbers;
    /// <summary>Select the line on clicking the line number. Defaults to <c>true</c>.</summary>
    public bool? SelectOnLineNumbers { get => _selectOnLineNumbers; set => SetProperty(ref _selectOnLineNumbers, value); }

    private bool? _selectionHighlight;
    /// <summary>Highlight selections of matching text. Defaults to <c>true</c>.</summary>
    public bool? SelectionHighlight { get => _selectionHighlight; set => SetProperty(ref _selectionHighlight, value); }

    private bool? _showDeprecated;
    /// <summary>Strike-through deprecated symbols. Defaults to <c>true</c>.</summary>
    public bool? ShowDeprecated { get => _showDeprecated; set => SetProperty(ref _showDeprecated, value); }

    private string? _showFoldingControls;
    /// <summary>
    /// When to show folding controls.
    /// Use <see cref="MonacoEditor.WinUI3.ShowFoldingControls"/> constants. Defaults to <c>"mouseover"</c>.
    /// </summary>
    public string? ShowFoldingControls { get => _showFoldingControls; set => SetProperty(ref _showFoldingControls, value); }

    private bool? _showUnused;
    /// <summary>Fade out unused code. Defaults to <c>true</c>.</summary>
    public bool? ShowUnused { get => _showUnused; set => SetProperty(ref _showUnused, value); }

    private bool? _smoothScrolling;
    /// <summary>Animate scrolling. Defaults to <c>false</c>.</summary>
    public bool? SmoothScrolling { get => _smoothScrolling; set => SetProperty(ref _smoothScrolling, value); }

    private string? _snippetSuggestions;
    /// <summary>
    /// Show snippet suggestions in IntelliSense.
    /// Use <see cref="MonacoEditor.WinUI3.SnippetSuggestions"/> constants. Defaults to <c>"inline"</c>.
    /// </summary>
    public string? SnippetSuggestions { get => _snippetSuggestions; set => SetProperty(ref _snippetSuggestions, value); }

    private bool? _stickyTabStops;
    /// <summary>Vim-like tab stop behaviour. Defaults to <c>false</c>.</summary>
    public bool? StickyTabStops { get => _stickyTabStops; set => SetProperty(ref _stickyTabStops, value); }

    private int? _stopRenderingLineAfter;
    /// <summary>Stop rendering a line after this many characters. Defaults to 10000.</summary>
    public int? StopRenderingLineAfter { get => _stopRenderingLineAfter; set => SetProperty(ref _stopRenderingLineAfter, value); }

    private int? _suggestFontSize;
    /// <summary>Font size (px) for the suggest widget. Defaults to editor font size.</summary>
    public int? SuggestFontSize { get => _suggestFontSize; set => SetProperty(ref _suggestFontSize, value); }

    private int? _suggestLineHeight;
    /// <summary>Line height (px) for the suggest widget. Defaults to editor line height.</summary>
    public int? SuggestLineHeight { get => _suggestLineHeight; set => SetProperty(ref _suggestLineHeight, value); }

    private bool? _suggestOnTriggerCharacters;
    /// <summary>Trigger suggestions after trigger characters. Defaults to <c>true</c>.</summary>
    public bool? SuggestOnTriggerCharacters { get => _suggestOnTriggerCharacters; set => SetProperty(ref _suggestOnTriggerCharacters, value); }

    private string? _suggestSelection;
    /// <summary>
    /// How suggestions are pre-selected in the suggest widget.
    /// Use <see cref="MonacoEditor.WinUI3.SuggestSelection"/> constants. Defaults to <c>"recentlyUsed"</c>.
    /// </summary>
    public string? SuggestSelection { get => _suggestSelection; set => SetProperty(ref _suggestSelection, value); }

    #endregion

    #region T–Z

    private string? _tabCompletion;
    /// <summary>
    /// Tab key triggers snippets.
    /// Use <see cref="MonacoEditor.WinUI3.TabCompletion"/> constants. Defaults to <c>"off"</c>.
    /// </summary>
    public string? TabCompletion { get => _tabCompletion; set => SetProperty(ref _tabCompletion, value); }

    private int? _tabIndex;
    /// <summary>Tab index of the editor's textarea element.</summary>
    public int? TabIndex { get => _tabIndex; set => SetProperty(ref _tabIndex, value); }

    private int? _tabSize;
    /// <summary>
    /// Number of spaces a tab is equal to.
    /// Defaults to 4. (Corresponds to <c>IGlobalEditorOptions</c>.)
    /// </summary>
    public int? TabSize { get => _tabSize; set => SetProperty(ref _tabSize, value); }

    private bool? _trimAutoWhitespace;
    /// <summary>
    /// Remove trailing auto-inserted whitespace.
    /// Defaults to <c>true</c>. (Corresponds to <c>IGlobalEditorOptions</c>.)
    /// </summary>
    public bool? TrimAutoWhitespace { get => _trimAutoWhitespace; set => SetProperty(ref _trimAutoWhitespace, value); }

    private string? _unusualLineTerminators;
    /// <summary>
    /// Handling of unusual line terminators (LS, PS, NEL).
    /// Use <see cref="MonacoEditor.WinUI3.UnusualLineTerminators"/> constants. Defaults to <c>"prompt"</c>.
    /// </summary>
    public string? UnusualLineTerminators { get => _unusualLineTerminators; set => SetProperty(ref _unusualLineTerminators, value); }

    private bool? _useShadowDOM;
    /// <summary>
    /// Use a shadow DOM root for rendering. Defaults to <c>true</c>.
    /// Disable if the editor inside a shadow DOM causes issues.
    /// </summary>
    public bool? UseShadowDOM { get => _useShadowDOM; set => SetProperty(ref _useShadowDOM, value); }

    private bool? _useTabStops;
    /// <summary>Insert/delete whitespace as tab-stop units. Defaults to <c>true</c>.</summary>
    public bool? UseTabStops { get => _useTabStops; set => SetProperty(ref _useTabStops, value); }

    private string? _wordBasedSuggestions;
    /// <summary>
    /// Word-based completion source.
    /// Use <see cref="MonacoEditor.WinUI3.WordBasedSuggestions"/> constants. Defaults to <c>"matchingDocuments"</c>.
    /// (Corresponds to <c>IGlobalEditorOptions</c>.)
    /// </summary>
    public string? WordBasedSuggestions { get => _wordBasedSuggestions; set => SetProperty(ref _wordBasedSuggestions, value); }

    private bool? _wordBasedSuggestionsOnlySameLanguage;
    /// <summary>
    /// Limit word-based suggestions to the same language. Defaults to <c>false</c>.
    /// (Corresponds to <c>IGlobalEditorOptions</c>.)
    /// </summary>
    public bool? WordBasedSuggestionsOnlySameLanguage { get => _wordBasedSuggestionsOnlySameLanguage; set => SetProperty(ref _wordBasedSuggestionsOnlySameLanguage, value); }

    private string? _wordBreak;
    /// <summary>
    /// Word break rule for CJK content.
    /// Use <see cref="MonacoEditor.WinUI3.WordBreak"/> constants. Defaults to <c>"normal"</c>.
    /// </summary>
    public string? WordBreak { get => _wordBreak; set => SetProperty(ref _wordBreak, value); }

    private string[]? _wordSegmenterLocales;
    /// <summary>
    /// BCP 47 locale tags for word segmentation (e.g. <c>new[] { "ja" }</c>).
    /// Single locales must still be wrapped in an array.
    /// </summary>
    public string[]? WordSegmenterLocales { get => _wordSegmenterLocales; set => SetProperty(ref _wordSegmenterLocales, value); }

    private string? _wordSeparators;
    /// <summary>Characters to use as word separators when double-clicking.</summary>
    public string? WordSeparators { get => _wordSeparators; set => SetProperty(ref _wordSeparators, value); }

    private string? _wordWrap;
    /// <summary>
    /// Word-wrap mode.
    /// Use <see cref="MonacoEditor.WinUI3.WordWrap"/> constants. Defaults to <c>"off"</c>.
    /// </summary>
    public string? WordWrap { get => _wordWrap; set => SetProperty(ref _wordWrap, value); }

    private string? _wordWrapBreakAfterCharacters;
    /// <summary>Characters to break after when wrapping.</summary>
    public string? WordWrapBreakAfterCharacters { get => _wordWrapBreakAfterCharacters; set => SetProperty(ref _wordWrapBreakAfterCharacters, value); }

    private string? _wordWrapBreakBeforeCharacters;
    /// <summary>Characters to break before when wrapping.</summary>
    public string? WordWrapBreakBeforeCharacters { get => _wordWrapBreakBeforeCharacters; set => SetProperty(ref _wordWrapBreakBeforeCharacters, value); }

    private int? _wordWrapColumn;
    /// <summary>Column for word-wrap when <see cref="WordWrap"/> is <c>"wordWrapColumn"</c> or <c>"bounded"</c>. Defaults to 80.</summary>
    public int? WordWrapColumn { get => _wordWrapColumn; set => SetProperty(ref _wordWrapColumn, value); }

    private string? _wordWrapOverride1;
    /// <summary>
    /// Override 1 for word wrap (applied after <see cref="WordWrap"/>).
    /// Use <see cref="MonacoEditor.WinUI3.WordWrapOverride"/> constants.
    /// </summary>
    public string? WordWrapOverride1 { get => _wordWrapOverride1; set => SetProperty(ref _wordWrapOverride1, value); }

    private string? _wordWrapOverride2;
    /// <summary>
    /// Override 2 for word wrap (applied after <see cref="WordWrapOverride1"/>).
    /// Use <see cref="MonacoEditor.WinUI3.WordWrapOverride"/> constants.
    /// </summary>
    public string? WordWrapOverride2 { get => _wordWrapOverride2; set => SetProperty(ref _wordWrapOverride2, value); }

    private string? _wrappingIndent;
    /// <summary>
    /// Indentation for wrapped lines.
    /// Use <see cref="MonacoEditor.WinUI3.WrappingIndent"/> constants. Defaults to <c>"same"</c>.
    /// </summary>
    public string? WrappingIndent { get => _wrappingIndent; set => SetProperty(ref _wrappingIndent, value); }

    private string? _wrappingStrategy;
    /// <summary>
    /// Algorithm for word wrapping.
    /// Use <see cref="MonacoEditor.WinUI3.WrappingStrategy"/> constants. Defaults to <c>"simple"</c>.
    /// </summary>
    public string? WrappingStrategy { get => _wrappingStrategy; set => SetProperty(ref _wrappingStrategy, value); }

    #endregion
}

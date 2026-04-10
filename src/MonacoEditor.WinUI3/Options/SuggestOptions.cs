namespace MonacoEditor.WinUI3;

/// <summary>
/// Configuration options for the suggestion (IntelliSense) widget.
/// Corresponds to Monaco's <c>ISuggestOptions</c>.
/// </summary>
public sealed class SuggestOptions : OptionsBase
{
    private string? _insertMode;
    private bool? _filterGraceful;
    private bool? _snippetsPreventQuickSuggestions;
    private bool? _localityBonus;
    private bool? _shareSuggestSelections;
    private string? _selectionMode;
    private bool? _showIcons;
    private bool? _showStatusBar;
    private bool? _preview;
    private string? _previewMode;
    private bool? _showInlineDetails;
    private bool? _showMethods;
    private bool? _showFunctions;
    private bool? _showConstructors;
    private bool? _showDeprecated;
    private bool? _matchOnWordStartOnly;
    private bool? _showFields;
    private bool? _showVariables;
    private bool? _showClasses;
    private bool? _showStructs;
    private bool? _showInterfaces;
    private bool? _showModules;
    private bool? _showProperties;
    private bool? _showEvents;
    private bool? _showOperators;
    private bool? _showUnits;
    private bool? _showValues;
    private bool? _showConstants;
    private bool? _showEnums;
    private bool? _showEnumMembers;
    private bool? _showKeywords;
    private bool? _showWords;
    private bool? _showColors;
    private bool? _showFiles;
    private bool? _showReferences;
    private bool? _showFolders;
    private bool? _showTypeParameters;
    private bool? _showIssues;
    private bool? _showUsers;
    private bool? _showSnippets;

    /// <summary>
    /// Overwrite word ends on accept.
    /// Use <see cref="SuggestInsertMode"/> constants. Defaults to <c>"insert"</c>.
    /// </summary>
    public string? InsertMode { get => _insertMode; set => SetProperty(ref _insertMode, value); }

    /// <summary>Enable graceful matching. Defaults to <c>true</c>.</summary>
    public bool? FilterGraceful { get => _filterGraceful; set => SetProperty(ref _filterGraceful, value); }

    /// <summary>Prevent quick suggestions when a snippet is active. Defaults to <c>true</c>.</summary>
    public bool? SnippetsPreventQuickSuggestions { get => _snippetsPreventQuickSuggestions; set => SetProperty(ref _snippetsPreventQuickSuggestions, value); }

    /// <summary>Favour words that appear close to the cursor.</summary>
    public bool? LocalityBonus { get => _localityBonus; set => SetProperty(ref _localityBonus, value); }

    /// <summary>Enable global storage for remembering suggestions.</summary>
    public bool? ShareSuggestSelections { get => _shareSuggestSelections; set => SetProperty(ref _shareSuggestSelections, value); }

    /// <summary>
    /// Controls when suggestions are selected when triggered via quick suggest or trigger characters.
    /// Use <see cref="SuggestSelectionMode"/> constants.
    /// </summary>
    public string? SelectionMode { get => _selectionMode; set => SetProperty(ref _selectionMode, value); }

    /// <summary>Show icons in suggestions. Defaults to <c>true</c>.</summary>
    public bool? ShowIcons { get => _showIcons; set => SetProperty(ref _showIcons, value); }

    /// <summary>Show the suggest status bar.</summary>
    public bool? ShowStatusBar { get => _showStatusBar; set => SetProperty(ref _showStatusBar, value); }

    /// <summary>Show a preview of the selected suggestion.</summary>
    public bool? Preview { get => _preview; set => SetProperty(ref _preview, value); }

    /// <summary>
    /// Mode for the suggestion preview.
    /// Use <see cref="SuggestPreviewMode"/> constants.
    /// </summary>
    public string? PreviewMode { get => _previewMode; set => SetProperty(ref _previewMode, value); }

    /// <summary>Show details inline with the label. Defaults to <c>true</c>.</summary>
    public bool? ShowInlineDetails { get => _showInlineDetails; set => SetProperty(ref _showInlineDetails, value); }

    public bool? ShowMethods { get => _showMethods; set => SetProperty(ref _showMethods, value); }
    public bool? ShowFunctions { get => _showFunctions; set => SetProperty(ref _showFunctions, value); }
    public bool? ShowConstructors { get => _showConstructors; set => SetProperty(ref _showConstructors, value); }
    public bool? ShowDeprecated { get => _showDeprecated; set => SetProperty(ref _showDeprecated, value); }

    /// <summary>Controls whether suggestions match only from word start.</summary>
    public bool? MatchOnWordStartOnly { get => _matchOnWordStartOnly; set => SetProperty(ref _matchOnWordStartOnly, value); }

    public bool? ShowFields { get => _showFields; set => SetProperty(ref _showFields, value); }
    public bool? ShowVariables { get => _showVariables; set => SetProperty(ref _showVariables, value); }
    public bool? ShowClasses { get => _showClasses; set => SetProperty(ref _showClasses, value); }
    public bool? ShowStructs { get => _showStructs; set => SetProperty(ref _showStructs, value); }
    public bool? ShowInterfaces { get => _showInterfaces; set => SetProperty(ref _showInterfaces, value); }
    public bool? ShowModules { get => _showModules; set => SetProperty(ref _showModules, value); }
    public bool? ShowProperties { get => _showProperties; set => SetProperty(ref _showProperties, value); }
    public bool? ShowEvents { get => _showEvents; set => SetProperty(ref _showEvents, value); }
    public bool? ShowOperators { get => _showOperators; set => SetProperty(ref _showOperators, value); }
    public bool? ShowUnits { get => _showUnits; set => SetProperty(ref _showUnits, value); }
    public bool? ShowValues { get => _showValues; set => SetProperty(ref _showValues, value); }
    public bool? ShowConstants { get => _showConstants; set => SetProperty(ref _showConstants, value); }
    public bool? ShowEnums { get => _showEnums; set => SetProperty(ref _showEnums, value); }
    public bool? ShowEnumMembers { get => _showEnumMembers; set => SetProperty(ref _showEnumMembers, value); }
    public bool? ShowKeywords { get => _showKeywords; set => SetProperty(ref _showKeywords, value); }
    public bool? ShowWords { get => _showWords; set => SetProperty(ref _showWords, value); }
    public bool? ShowColors { get => _showColors; set => SetProperty(ref _showColors, value); }
    public bool? ShowFiles { get => _showFiles; set => SetProperty(ref _showFiles, value); }
    public bool? ShowReferences { get => _showReferences; set => SetProperty(ref _showReferences, value); }
    public bool? ShowFolders { get => _showFolders; set => SetProperty(ref _showFolders, value); }
    public bool? ShowTypeParameters { get => _showTypeParameters; set => SetProperty(ref _showTypeParameters, value); }
    public bool? ShowIssues { get => _showIssues; set => SetProperty(ref _showIssues, value); }
    public bool? ShowUsers { get => _showUsers; set => SetProperty(ref _showUsers, value); }
    public bool? ShowSnippets { get => _showSnippets; set => SetProperty(ref _showSnippets, value); }
}

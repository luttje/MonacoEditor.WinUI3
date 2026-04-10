using System.Collections.Generic;

namespace MonacoEditor.WinUI3;

/// <summary>
/// Configuration options for the Unicode highlight feature.
/// Corresponds to Monaco's <c>IUnicodeHighlightOptions</c>.
/// </summary>
public sealed class UnicodeHighlightOptions : OptionsBase
{
    private BoolOrString? _nonBasicASCII;
    private bool? _invisibleCharacters;
    private bool? _ambiguousCharacters;
    private BoolOrString? _includeComments;
    private BoolOrString? _includeStrings;
    private Dictionary<string, bool>? _allowedCharacters;
    private Dictionary<string, bool>? _allowedLocales;

    /// <summary>
    /// Highlight all non-basic ASCII characters.
    /// Accepts <c>true</c>, <c>false</c>, or <c>"inUntrustedWorkspace"</c>.
    /// </summary>
    public BoolOrString? NonBasicASCII
    {
        get => _nonBasicASCII;
        set => SetProperty(ref _nonBasicASCII, value);
    }

    /// <summary>Highlight zero-width or no-width characters.</summary>
    public bool? InvisibleCharacters
    {
        get => _invisibleCharacters;
        set => SetProperty(ref _invisibleCharacters, value);
    }

    /// <summary>Highlight characters that can be confused with basic ASCII.</summary>
    public bool? AmbiguousCharacters
    {
        get => _ambiguousCharacters;
        set => SetProperty(ref _ambiguousCharacters, value);
    }

    /// <summary>
    /// Also check characters inside comments.
    /// Accepts <c>true</c>, <c>false</c>, or <c>"inUntrustedWorkspace"</c>.
    /// </summary>
    public BoolOrString? IncludeComments
    {
        get => _includeComments;
        set => SetProperty(ref _includeComments, value);
    }

    /// <summary>
    /// Also check characters inside string literals.
    /// Accepts <c>true</c>, <c>false</c>, or <c>"inUntrustedWorkspace"</c>.
    /// </summary>
    public BoolOrString? IncludeStrings
    {
        get => _includeStrings;
        set => SetProperty(ref _includeStrings, value);
    }

    /// <summary>Characters (by Unicode scalar value string) that are allowed and not highlighted.</summary>
    public Dictionary<string, bool>? AllowedCharacters
    {
        get => _allowedCharacters;
        set => SetProperty(ref _allowedCharacters, value);
    }

    /// <summary>
    /// Locales whose common characters are allowed. Use BCP 47 locale tags, or the special
    /// keys <c>"_os"</c> and <c>"_vscode"</c>.
    /// </summary>
    public Dictionary<string, bool>? AllowedLocales
    {
        get => _allowedLocales;
        set => SetProperty(ref _allowedLocales, value);
    }
}

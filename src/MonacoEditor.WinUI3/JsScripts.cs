namespace MonacoEditor.WinUI3;

/// <summary>
/// Builds the JavaScript call strings that <see cref="MonacoEditorControl"/> sends
/// to the embedded Monaco editor via <c>ExecuteScriptAsync</c>.
/// </summary>
internal static class JsScripts
{
    internal static string SetText(string text)
        => $"setText(`{JsEscape.Escape(text)}`);";

    internal static string SetLanguage(string language)
        => $"setLanguage('{JsEscape.Escape(language)}');";

    internal static string SetTheme(string theme)
        => $"setTheme('{JsEscape.Escape(theme)}'); applyThemeBackground('{JsEscape.Escape(theme)}');";

    internal static string SetReadOnly(bool readOnly)
        => $"setReadOnly({(readOnly ? "true" : "false")});";

    internal static string SetOptions(string optionsJson)
        => $"setOptions('{JsEscape.Escape(optionsJson)}');";

    internal static string FocusEditor()
        => "focusEditor();";

    internal static string InsertTextAtCursor(string text)
        => $"insertTextAtCursor(`{JsEscape.Escape(text)}`);";

    internal static string GetText()
        => "getText();";

    internal static string GetSelectedText()
        => "getSelectedText();";

    internal static string GetCursorPosition()
        => "getCursorPosition();";

    internal static string SetCursorPosition(int lineNumber, int column)
        => $"setCursorPosition({lineNumber}, {column});";

    internal static string TriggerAction(string actionId)
        => $"triggerAction('{JsEscape.Escape(actionId)}');";
}

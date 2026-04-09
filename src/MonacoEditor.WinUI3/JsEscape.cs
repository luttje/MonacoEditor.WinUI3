namespace MonacoEditor.WinUI3;

/// <summary>
/// Escapes strings for safe embedding in JavaScript template literals and single-quoted strings.
/// </summary>
internal static class JsEscape
{
    /// <summary>
    /// Escapes <paramref name="value"/> so it can be embedded inside a JS template literal
    /// (<c>`…`</c>) or a single-quoted string (<c>'…'</c>).
    /// </summary>
    internal static string Escape(string value)
    {
        return value
            .Replace("\\", "\\\\")   // Must be first: backslash → \\
            .Replace("`", "\\`")     // Backtick → \`
            .Replace("'", "\\'")     // Single quote → \'
            .Replace("\"", "\\\"")   // Double quote → \"
            .Replace("$", "\\$")     // Dollar sign → \$ (prevent template interpolation)
            .Replace("\r\n", "\\n")  // CRLF → \n  (must precede lone \r / \n)
            .Replace("\r", "\\n")    // CR → \n
            .Replace("\n", "\\n");   // LF → \n
    }
}

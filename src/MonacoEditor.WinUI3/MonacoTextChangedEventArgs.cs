using System;

namespace MonacoEditor.WinUI3;

/// <summary>
/// Event arguments for the <see cref="MonacoEditorControl.TextChanged"/> event.
/// </summary>
public sealed class MonacoTextChangedEventArgs : EventArgs
{
    /// <summary>The new full text content of the editor.</summary>
    public string Text { get; }

    public MonacoTextChangedEventArgs(string text)
    {
        Text = text;
    }
}

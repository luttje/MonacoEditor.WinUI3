using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace MonacoEditor.WinUI3.Sample;

public sealed partial class MainWindow : Window, INotifyPropertyChanged
{
    private string _editorText = "// Type your code here...\nconsole.log('Hello from Monaco!');";

    public string EditorText
    {
        get => _editorText;
        set
        {
            if (_editorText != value)
            {
                _editorText = value;
                OnPropertyChanged();
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public MainWindow()
    {
        InitializeComponent();

        LanguageCombo.SelectionChanged += OnLanguageChanged;
        ThemeCombo.SelectionChanged += OnThemeChanged;
        ReadOnlyCheck.Checked += OnReadOnlyChanged;
        ReadOnlyCheck.Unchecked += OnReadOnlyChanged;

        // Force JavaScript language to be selected by default
        LanguageCombo.SelectedItem = LanguageCombo.Items.OfType<ComboBoxItem>()
            .FirstOrDefault(item => item.Content?.ToString() == "javascript");
    }

    private void OnEditorReady(object? sender, System.EventArgs e)
    {
        StatusText.Text = "Editor ready.";
    }

    private void OnEditorTextChanged(object? sender, MonacoTextChangedEventArgs e)
    {
        StatusText.Text = $"Content changed — {e.Text.Length} characters";
    }

    private void OnLanguageChanged(object sender, SelectionChangedEventArgs e)
    {
        if (sender is ComboBox combo && combo.SelectedItem is ComboBoxItem item)
        {
            Editor.EditorLanguage = item.Content?.ToString() ?? "plaintext";
        }
    }

    private void OnThemeChanged(object sender, SelectionChangedEventArgs e)
    {
        if (sender is ComboBox combo && combo.SelectedItem is ComboBoxItem item)
        {
            Editor.EditorTheme = item.Content?.ToString() ?? "vs";
        }
    }

    private void OnReadOnlyChanged(object sender, RoutedEventArgs e)
    {
        Editor.IsReadOnly = ReadOnlyCheck.IsChecked == true;
    }

    private async void OnSetTextClicked(object sender, RoutedEventArgs e)
    {
        EditorText = "// Text set from C# at " + System.DateTime.Now.ToString("HH:mm:ss") + "\n"
                   + "function greet(name) {\n"
                   + "    return `Hello, ${name}!`;\n"
                   + "}\n";
        Editor.EditorLanguage = "javascript";
    }

    private async void OnGetTextClicked(object sender, RoutedEventArgs e)
    {
        var text = await Editor.GetTextAsync();
        StatusText.Text = $"Retrieved {text.Length} characters from editor";
    }

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

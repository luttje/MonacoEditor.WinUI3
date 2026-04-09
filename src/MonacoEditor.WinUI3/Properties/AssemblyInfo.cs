using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

// Ensure the Generic.xaml theme dictionary is found
[assembly: System.Reflection.AssemblyMetadata("Microsoft.UI.Xaml.XamlResourceUri",
    "ms-appx:///MonacoEditor.WinUI3/Themes/Generic.xaml")]

// Allow the test project to access internal helpers directly (JsEscape, JsScripts, WebMessageParser)
[assembly: InternalsVisibleTo("MonacoEditor.WinUI3.Tests")]

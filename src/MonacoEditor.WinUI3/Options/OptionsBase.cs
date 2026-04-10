using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MonacoEditor.WinUI3;

/// <summary>
/// Base class for Monaco editor option objects, providing
/// <see cref="INotifyPropertyChanged"/> support so that mutations to bound option
/// objects are automatically pushed to the editor by <see cref="MonacoEditorControl"/>.
/// </summary>
public abstract class OptionsBase : INotifyPropertyChanged
{
    /// <inheritdoc/>
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// Sets the field to <paramref name="value"/> and raises
    /// <see cref="PropertyChanged"/> when the value actually changes.
    /// </summary>
    protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value))
            return false;

        field = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        return true;
    }

    /// <summary>Raises <see cref="PropertyChanged"/> for <paramref name="propertyName"/>.</summary>
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    /// <summary>
    /// Subscribes to a child options object's <see cref="PropertyChanged"/> event so that
    /// mutations to nested options bubble up through this instance.
    /// </summary>
    protected void SubscribeToChild(INotifyPropertyChanged? child)
    {
        if (child is not null)
            child.PropertyChanged += OnChildPropertyChanged;
    }

    /// <summary>Unsubscribes from a child options object's <see cref="PropertyChanged"/> event.</summary>
    protected void UnsubscribeFromChild(INotifyPropertyChanged? child)
    {
        if (child is not null)
            child.PropertyChanged -= OnChildPropertyChanged;
    }

    private void OnChildPropertyChanged(object? sender, PropertyChangedEventArgs e)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
}

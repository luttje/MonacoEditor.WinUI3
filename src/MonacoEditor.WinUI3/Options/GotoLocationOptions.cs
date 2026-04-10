namespace MonacoEditor.WinUI3;

/// <summary>
/// Configuration options for go-to-definition/references behaviour.
/// Corresponds to Monaco's <c>IGotoLocationOptions</c>.
/// Use <see cref="GotoLocationValues"/> constants for the multi-match properties.
/// </summary>
public sealed class GotoLocationOptions : OptionsBase
{
    private string? _multiple;
    private string? _multipleDefinitions;
    private string? _multipleTypeDefinitions;
    private string? _multipleDeclarations;
    private string? _multipleImplementations;
    private string? _multipleReferences;
    private string? _multipleTests;
    private string? _alternativeDefinitionCommand;
    private string? _alternativeTypeDefinitionCommand;
    private string? _alternativeDeclarationCommand;
    private string? _alternativeImplementationCommand;
    private string? _alternativeReferenceCommand;
    private string? _alternativeTestsCommand;

    /// <summary>
    /// Behaviour when multiple definitions are found (legacy, all-in-one).
    /// Use <see cref="GotoLocationValues"/> constants.
    /// </summary>
    public string? Multiple { get => _multiple; set => SetProperty(ref _multiple, value); }

    /// <summary>Use <see cref="GotoLocationValues"/> constants.</summary>
    public string? MultipleDefinitions { get => _multipleDefinitions; set => SetProperty(ref _multipleDefinitions, value); }

    /// <summary>Use <see cref="GotoLocationValues"/> constants.</summary>
    public string? MultipleTypeDefinitions { get => _multipleTypeDefinitions; set => SetProperty(ref _multipleTypeDefinitions, value); }

    /// <summary>Use <see cref="GotoLocationValues"/> constants.</summary>
    public string? MultipleDeclarations { get => _multipleDeclarations; set => SetProperty(ref _multipleDeclarations, value); }

    /// <summary>Use <see cref="GotoLocationValues"/> constants.</summary>
    public string? MultipleImplementations { get => _multipleImplementations; set => SetProperty(ref _multipleImplementations, value); }

    /// <summary>Use <see cref="GotoLocationValues"/> constants.</summary>
    public string? MultipleReferences { get => _multipleReferences; set => SetProperty(ref _multipleReferences, value); }

    /// <summary>Use <see cref="GotoLocationValues"/> constants.</summary>
    public string? MultipleTests { get => _multipleTests; set => SetProperty(ref _multipleTests, value); }

    /// <summary>Alternative command to trigger when only one result would open the definition.</summary>
    public string? AlternativeDefinitionCommand { get => _alternativeDefinitionCommand; set => SetProperty(ref _alternativeDefinitionCommand, value); }

    /// <summary>Alternative command to trigger when only one result would open the type definition.</summary>
    public string? AlternativeTypeDefinitionCommand { get => _alternativeTypeDefinitionCommand; set => SetProperty(ref _alternativeTypeDefinitionCommand, value); }

    /// <summary>Alternative command to trigger when only one result would open the declaration.</summary>
    public string? AlternativeDeclarationCommand { get => _alternativeDeclarationCommand; set => SetProperty(ref _alternativeDeclarationCommand, value); }

    /// <summary>Alternative command to trigger when only one result would open the implementation.</summary>
    public string? AlternativeImplementationCommand { get => _alternativeImplementationCommand; set => SetProperty(ref _alternativeImplementationCommand, value); }

    /// <summary>Alternative command to trigger when only one result would open the reference.</summary>
    public string? AlternativeReferenceCommand { get => _alternativeReferenceCommand; set => SetProperty(ref _alternativeReferenceCommand, value); }

    /// <summary>Alternative command to trigger when only one result would open the test.</summary>
    public string? AlternativeTestsCommand { get => _alternativeTestsCommand; set => SetProperty(ref _alternativeTestsCommand, value); }
}

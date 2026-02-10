namespace GqlPlus.Generating;

public class SchemaGeneratorTests
  : GenerateClassTestsBase
{
  private readonly IGenerator<IGqlpSchemaCategory> _categoryGenerator = GFor<IGqlpSchemaCategory>();
  private readonly IGenerator<IGqlpSchemaDirective> _directiveGenerator = GFor<IGqlpSchemaDirective>();
  private readonly IGenerator<IGqlpSchemaOption> _optionGenerator = GFor<IGqlpSchemaOption>();
  private readonly List<ITypeGenerator> _typeGenerators = [];

  private readonly SchemaGenerator _generator;

  public SchemaGeneratorTests()
    => _generator = new SchemaGenerator(
        _categoryGenerator,
        _directiveGenerator,
        _optionGenerator,
        _typeGenerators
      );

  [Theory, RepeatData]
  public void Generate_WithValidSchema_CallsGeneratorsInOrder(string typeName)
  {
    // Arrange
    GqlpGeneratorContext context = Context();
    IGqlpSchema schema = A.Error<IGqlpSchema>();
    IGqlpType type = A.Named<IGqlpType>(typeName);
    schema.Declarations.Returns([type]);

    ITypeGenerator typeGenerator = A.Of<ITypeGenerator>();
    typeGenerator.ForType(type).Returns(true);

    _typeGenerators.Add(typeGenerator);

    // Act
    _generator.Generate(schema, context);

    // Assert
    Received.InOrder(() => typeGenerator.GenerateType(type, context));
  }

  [Theory, RepeatData]
  public void Generate_WithNoMatchingGenerator_ThrowsInvalidOperationException(string typeName)
  {
    // Arrange
    GqlpGeneratorContext context = Context();
    IGqlpSchema schema = A.Error<IGqlpSchema>();
    IGqlpType type = A.Named<IGqlpType>(typeName);
    schema.Declarations.Returns([type]);

    // Act & Assert
    Should.Throw<InvalidOperationException>(() =>
        _generator.Generate(schema, context))
        .Message.ShouldContain("No Generator for");
  }
}

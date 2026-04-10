namespace GqlPlus.Generating;

public class SchemaGeneratorTests
  : GenerateClassTestsBase
{
  private readonly IGeneratorRepository _generators = A.Of<IGeneratorRepository>();
  private readonly IGenerator<IAstSchemaCategory> _categoryGenerator = GFor<IAstSchemaCategory>();
  private readonly IGenerator<IAstSchemaDirective> _directiveGenerator = GFor<IAstSchemaDirective>();
  private readonly IGenerator<IAstSchemaOption> _optionGenerator = GFor<IAstSchemaOption>();
  private readonly Dictionary<GqlpGeneratorType, IEnumerable<ITypeGenerator>> _typeGenerators = [];

  private readonly SchemaGenerator _generator;

  public SchemaGeneratorTests()
  {
    _generators.GeneratorFor<IAstSchemaCategory>().Returns(_categoryGenerator);
    _generators.GeneratorFor<IAstSchemaDirective>().Returns(_directiveGenerator);
    _generators.GeneratorFor<IAstSchemaOption>().Returns(_optionGenerator);
    _generators.TypeGenerators.Returns(_typeGenerators);
    _generator = new SchemaGenerator(_generators);
  }

  [Theory, RepeatData]
  public void Generate_WithValidSchema_CallsGeneratorsInOrder(string typeName)
  {
    // Arrange
    GqlpGeneratorContext context = Context();
    IAstSchema schema = A.Error<IAstSchema>();
    IAstType type = A.Named<IAstType>(typeName);
    schema.Declarations.Returns([type]);

    ITypeGenerator typeGenerator = A.Of<ITypeGenerator>();
    typeGenerator.ForType(type).Returns(true);

    _typeGenerators[GqlpGeneratorType.Model] = [typeGenerator];

    // Act
    _generator.Generate(schema, context);

    // Assert
    Received.InOrder(() => typeGenerator.GenerateType(type, context));
  }

  [Theory, RepeatData]
  public void Generate_WithNoMatchingGenerator_DoesNotThrow(string typeName)
  {
    // Arrange
    GqlpGeneratorContext context = Context();
    IAstSchema schema = A.Error<IAstSchema>();
    IAstType type = A.Named<IAstType>(typeName);
    schema.Declarations.Returns([type]);

    // Act & Assert
    Should.NotThrow(() => _generator.Generate(schema, context));
  }
}

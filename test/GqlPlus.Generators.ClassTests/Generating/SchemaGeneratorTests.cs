using System.Diagnostics.CodeAnalysis;
using GqlPlus.Structures;

namespace GqlPlus.Generating;

public class SchemaGeneratorTests
  : GenerateClassTestsBase
{
  private readonly IGeneratorRepository _generators = A.Of<IGeneratorRepository>();
  private readonly IGenerator<IAstSchemaCategory> _categoryGenerator = GFor<IAstSchemaCategory>();
  private readonly IGenerator<IAstSchemaDirective> _directiveGenerator = GFor<IAstSchemaDirective>();
  private readonly IGenerator<IAstSchemaOption> _optionGenerator = GFor<IAstSchemaOption>();

  private readonly SchemaGenerator _generator;

  public SchemaGeneratorTests()
  {
    GeneratorForReturns(_categoryGenerator);
    GeneratorForReturns(_directiveGenerator);
    GeneratorForReturns(_optionGenerator);
    _generator = new SchemaGenerator(_generators);
  }

  private void GeneratorForReturns<T>(IGenerator<T> result)
    where T : IAstError
    => _generators.GeneratorFor<T>().ReturnsForAnyArgs(result);

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
    _generators.TypeGenerators(GqlpGeneratorType.Model, Arg.Any<string>()).Returns([typeGenerator]);

    // Act
    _generator.Generate(schema, context);

    // Assert
    Received.InOrder(() => typeGenerator.GenerateType(type, context));
  }

  [Theory, RepeatData]
  public void Generate_WithOnlyInterfaceGenerator_DoesNotThrow(string typeName)
  {
    // Arrange
    GqlpGeneratorContext context = Context();
    IAstSchema schema = A.Error<IAstSchema>();
    IAstType type = A.Named<IAstType>(typeName);
    schema.Declarations.Returns([type]);

    ITypeGenerator typeGenerator = A.Of<ITypeGenerator>();
    typeGenerator.ForType(type).Returns(true);
    _generators.TypeGenerators(GqlpGeneratorType.Interface, Arg.Any<string>()).Returns([typeGenerator]);

    // Act & Assert
    Should.NotThrow(() => _generator.Generate(schema, context));
  }

  [Theory, RepeatData]
  public void Generate_WithNoMatchingGenerator_Throws(string typeName)
  {
    // Arrange
    GqlpGeneratorContext context = Context();
    IAstSchema schema = A.Error<IAstSchema>();
    IAstType type = A.Named<IAstType>(typeName);
    schema.Declarations.Returns([type]);

    // Act & Assert
    Should.Throw<InvalidOperationException>(() => _generator.Generate(schema, context));
  }

  [Theory, RepeatData]
  public void Generate_WithDecoderRegistration_GeneratesDecoderClass(string serviceType, string implType)
  {
    // Arrange
    GqlpGeneratorContext context = Context(GqlpBaseType.Class, GqlpGeneratorType.Dec);
    IAstSchema schema = A.Error<IAstSchema>();
    schema.Declarations.Returns([]);
    context.RegisterDecoder(serviceType, implType);

    // Act
    _generator.Generate(schema, context);

    // Assert
    context.CheckAll(
      r => r.ShouldContain($"internal static class {TestPrefix}_testPathDecoders"),
      r => r.ShouldContain($"IDecoderRepositoryBuilder Add{TestPrefix}_testPathDecoders"),
      r => r.ShouldContain($".AddDecoder<{serviceType}>({implType}.Factory);")
    );
  }

  [Theory, RepeatData]
  public void Generate_WithMultipleDecoderRegistrations_GeneratesAllDecoderEntries(string serviceType1, string implType1, string serviceType2, string implType2)
  {
    // Arrange
    GqlpGeneratorContext context = Context(GqlpBaseType.Class, GqlpGeneratorType.Dec);
    IAstSchema schema = A.Error<IAstSchema>();
    schema.Declarations.Returns([]);
    context.RegisterDecoder(serviceType1, implType1);
    context.RegisterDecoder(serviceType2, implType2);

    // Act
    _generator.Generate(schema, context);

    // Assert
    context.CheckAll(
      r => r.ShouldContain($".AddDecoder<{serviceType1}>({implType1}.Factory)"),
      r => r.ShouldContain($".AddDecoder<{serviceType2}>({implType2}.Factory);")
    );
  }

  [Theory, RepeatData]
  public void Generate_WithEncoderRegistration_GeneratesEncoderClass(string serviceType, string implType)
  {
    // Arrange
    GqlpGeneratorContext context = Context(GqlpBaseType.Class, GqlpGeneratorType.Enc);
    IAstSchema schema = A.Error<IAstSchema>();
    schema.Declarations.Returns([]);
    context.RegisterEncoder(serviceType, implType);

    // Act
    _generator.Generate(schema, context);

    // Assert
    context.CheckAll(
      r => r.ShouldContain($"internal static class {TestPrefix}_testPathEncoders"),
      r => r.ShouldContain($"IEncoderRepositoryBuilder Add{TestPrefix}_testPathEncoders"),
      r => r.ShouldContain($".AddEncoder<{serviceType}>({implType}.Factory);")
    );
  }

  [Theory, RepeatData]
  public void Generate_WithMultipleEncoderRegistrations_GeneratesAllEncoderEntries(string serviceType1, string implType1, string serviceType2, string implType2)
  {
    // Arrange
    GqlpGeneratorContext context = Context(GqlpBaseType.Class, GqlpGeneratorType.Enc);
    IAstSchema schema = A.Error<IAstSchema>();
    schema.Declarations.Returns([]);
    context.RegisterEncoder(serviceType1, implType1);
    context.RegisterEncoder(serviceType2, implType2);

    // Act
    _generator.Generate(schema, context);

    // Assert
    context.CheckAll(
      r => r.ShouldContain($".AddEncoder<{serviceType1}>({implType1}.Factory)"),
      r => r.ShouldContain($".AddEncoder<{serviceType2}>({implType2}.Factory);")
    );
  }
}

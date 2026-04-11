using GqlPlus.Ast.Schema;

namespace GqlPlus.Generating.Globals;

public class OptionGeneratorTests
  : GenerateClassTestsBase
{
  private readonly OptionGenerator _generator = new();

  [Theory, RepeatData]
  public void Generate_ReturnsExpected(string name)
  {
    // Arrange
    GqlpGeneratorContext context = Context(GqlpBaseType.Other, GqlpGeneratorType.Static);
    IAstSchemaOption option = A.Named<IAstSchemaOption>(name);

    // Act
    _generator.Generate(option, context);

    // Assert
    context.CheckForRequired(g => name);
  }
}

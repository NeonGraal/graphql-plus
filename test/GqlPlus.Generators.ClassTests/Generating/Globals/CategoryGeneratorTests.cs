namespace GqlPlus.Generating.Globals;

public class CategoryGeneratorTests
  : GeneratorClassTestBase
{
  private readonly CategoryGenerator _generator = new();

  [Theory, RepeatData]
  public void Generate_ReturnsExpected(string name)
  {
    // Arrange
    GqlpGeneratorContext context = Context(GqlpBaseType.Other, GqlpGeneratorType.Static);
    IGqlpSchemaCategory category = A.Named<IGqlpSchemaCategory>(name);

    // Act
    _generator.Generate(category, context);

    // Assert
    context.CheckForRequired(name);
  }
}

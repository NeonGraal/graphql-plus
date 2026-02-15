namespace GqlPlus.Generating.Globals;

public class DirectiveGeneratorTests
  : GenerateClassTestsBase
{
  private readonly DirectiveGenerator _generator = new();

  [Theory, RepeatData]
  public void Generate_ReturnsExpected(string name)
  {
    // Arrange
    GqlpGeneratorContext context = Context(GqlpBaseType.Other, GqlpGeneratorType.Static);
    IGqlpSchemaDirective directive = A.Named<IGqlpSchemaDirective>(name);

    // Act
    _generator.Generate(directive, context);

    // Assert
    context.CheckForRequired(name);
  }
}

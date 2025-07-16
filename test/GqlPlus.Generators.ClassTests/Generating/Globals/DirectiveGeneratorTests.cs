namespace GqlPlus.Generating.Globals;

public class DirectiveGeneratorTests
  : GeneratorClassTestBase
{
  private readonly DirectiveGenerator _generator = new();

  [Theory, RepeatData]
  public void Generate_ReturnsExpected(string name)
  {
    // Arrange
    IGqlpSchemaDirective directive = A.Named<IGqlpSchemaDirective>(name);

    // Act
    _generator.Generate(directive, Context);

    // Assert
    string result = Context.ToString();
    result.ShouldContain(name);
  }
}

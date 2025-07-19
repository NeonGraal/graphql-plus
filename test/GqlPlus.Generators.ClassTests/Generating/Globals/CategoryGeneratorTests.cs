namespace GqlPlus.Generating.Globals;

public class CategoryGeneratorTests
  : GeneratorClassTestBase
{
  private readonly CategoryGenerator _generator = new();

  [Theory, RepeatData]
  public void Generate_ReturnsExpected(string name)
  {
    // Arrange
    IGqlpSchemaCategory category = A.Named<IGqlpSchemaCategory>(name);

    // Act
    _generator.Generate(category, Context);

    // Assert
    string result = Context.ToString();
    result.ShouldContain(name);
  }
}

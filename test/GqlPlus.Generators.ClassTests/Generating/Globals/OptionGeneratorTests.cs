namespace GqlPlus.Generating.Globals;

public class OptionGeneratorTests
  : GeneratorClassTestBase
{
  private readonly OptionGenerator _generator = new();

  [Theory, RepeatData]
  public void Generate_ReturnsExpected(string name)
  {
    // Arrange
    IGqlpSchemaOption option = A.Named<IGqlpSchemaOption>(name);

    // Act
    _generator.Generate(option, Context);

    // Assert
    string result = Context.ToString();
    result.ShouldContain(name);
  }
}

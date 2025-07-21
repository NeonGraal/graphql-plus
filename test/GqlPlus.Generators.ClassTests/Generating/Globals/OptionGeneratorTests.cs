namespace GqlPlus.Generating.Globals;

public class OptionGeneratorTests
  : GeneratorClassTestBase
{
  private readonly OptionGenerator _generator = new();

  [Theory, RepeatData]
  public void Generate_ReturnsExpected(string name)
  {
    // Arrange
    GqlpGeneratorContext context = Context(GqlpBaseType.Other, GqlpGeneratorType.Static);
    IGqlpSchemaOption option = A.Named<IGqlpSchemaOption>(name);

    // Act
    _generator.Generate(option, context);

    // Assert
    string result = context.ToString();
    result.ShouldContain(name);
  }
}

namespace GqlPlus.Generating;

public class BuiltInGeneratorTests
  : GenerateClassTestsBase
{
  static public IEnumerable<TheoryDataRow<string>> DotnetTypes => GqlpGeneratorContext.DotNetTypes.Select(b => new TheoryDataRow<string>(b.Key));

  [Theory, MemberData(nameof(DotnetTypes))]
  public void TypeName_WithDotnetType_ReturnsWithoutPrefix(string basic)
  {
    // Arrange
    GqlpGeneratorContext context = Context();

    // Act
    string typeName = context.TypeName(basic, "I");

    // Assert
    typeName.ShouldBe(GqlpGeneratorContext.DotNetTypes[basic]);
  }
}

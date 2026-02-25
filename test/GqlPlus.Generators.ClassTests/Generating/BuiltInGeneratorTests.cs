namespace GqlPlus.Generating;

public class BuiltInGeneratorTests
  : GenerateClassTestsBase
{
  [Theory, ClassData(typeof(DotnetTypesData))]
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

public class DotnetTypesData()
  : TheoryData<string>(GqlpGeneratorContext.DotNetTypes.Keys);

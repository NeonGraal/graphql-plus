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

  [Theory, ClassData(typeof(EnumTypesData))]
  public void TypeName_WithEnumType_ReturnsWithoutPrefix(string enumType)
  {
    // Arrange
    GqlpGeneratorContext context = Context();

    // Act
    string typeName = context.TypeName(enumType, "I");

    // Assert
    typeName.ShouldBe(TestPrefix + enumType);
  }
}

public class EnumTypesData()
  : TheoryData<string>(BuiltIn.NullType);

public class DotnetTypesData()
  : TheoryData<string>(GqlpGeneratorContext.DotNetTypes.Keys);

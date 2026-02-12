namespace GqlPlus;

public class GqlpGeneratorOptionsTests
{
  [Theory, RepeatData]
  public void Constructor_GivenNamespace_ShouldSetPropertiesCorrectly(string nameSpace, string className, GqlpBaseType baseType, GqlpGeneratorType generatorType)
  {
    // Arrange
    string fullName = nameSpace + "." + className;

    // Act
    GqlpGeneratorOptions options = new(fullName, baseType, generatorType);

    // Assert
    options.ShouldSatisfyAllConditions(
      o => o.NameSpace.ShouldBe(nameSpace),
      o => o.BaseName.ShouldBe(className),
      o => o.BaseType.ShouldBe(baseType),
      o => o.GeneratorType.ShouldBe(generatorType));
  }

  [Theory, RepeatData]
  public void Constructor_GivenNoNamespace_ShouldSetPropertiesCorrectly(string className, GqlpBaseType baseType, GqlpGeneratorType generatorType)
  {
    // Act
    GqlpGeneratorOptions options = new(className, baseType, generatorType);

    // Assert
    options.ShouldSatisfyAllConditions(
      o => o.NameSpace.ShouldBeEmpty(),
      o => o.BaseName.ShouldBe(className),
      o => o.BaseType.ShouldBe(baseType),
      o => o.GeneratorType.ShouldBe(generatorType));
  }
}

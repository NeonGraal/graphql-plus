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
      o => o.GeneratorType.ShouldBe(generatorType),
      o => o.Warning.ShouldBeEmpty());
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
      o => o.GeneratorType.ShouldBe(generatorType),
      o => o.Warning.ShouldBeEmpty());
  }

  [Theory, RepeatData]
  public void Constructor_GivenWarning_ShouldSetPropertiesCorrectly(string warning)
  {
    // Act
    GqlpGeneratorOptions options = new(warning);

    // Assert
    options.ShouldSatisfyAllConditions(
      o => o.NameSpace.ShouldBeEmpty(),
      o => o.BaseName.ShouldBeEmpty(),
      o => o.BaseType.ShouldBe(GqlpBaseType.Other),
      o => o.GeneratorType.ShouldBe(GqlpGeneratorType.None),
      o => o.Warning.ShouldBe(warning));
  }
}

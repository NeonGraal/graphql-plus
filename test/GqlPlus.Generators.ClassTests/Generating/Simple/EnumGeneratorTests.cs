using System.Reflection.Emit;
using GqlPlus.Building.Schema.Simple;

namespace GqlPlus.Generating.Simple;

public class EnumGeneratorTests
  : GenerateSimpleTestsBase<IGqlpEnum>
{
  private readonly EnumGenerator _generator;

  public EnumGeneratorTests()
    => _generator = new EnumGenerator();

  internal override GenerateForType<IGqlpEnum> TypeGenerator => _generator;

  [Theory, RepeatData]
  public void TypeMembers_WithEnumItems_ReturnsAsNamePairs(string enumName, string labelName)
  {
    // Arrange
    GqlpGeneratorContext context = Context();
    IGqlpEnum enumType = A.Enum(enumName, [labelName]);

    MapPair<string> expected = new(labelName, "");

    // Act
    MapPair<string>[] result = [.. _generator.TypeMembers(enumType, context)];

    // Assert
    result.ShouldBe([expected]);
  }

  [Theory, RepeatData]
  public void TypeMembers_WithParentItems_ReturnsAsNamePairs(string enumName, string parentName, string labelName)
  {
    // Arrange
    GqlpGeneratorContext context = Context();
    IGqlpEnum enumType = A.Enum(enumName)
      .WithParent(parentName)
      .AsEnum;

    IGqlpEnum parentType = A.Enum(parentName, [labelName]);
    context.AddTypes([parentType]);

    MapPair<string> expected = new(labelName, $" = {parentName}.{labelName}");

    // Act
    MapPair<string>[] result = [.. _generator.TypeMembers(enumType, context)];

    // Assert
    result.ShouldBe([expected]);
  }

  [Theory, RepeatClassData(typeof(BaseGeneratorData))]
  public void GenerateType_WithEnumItems_GeneratesCorrectCode(GqlpBaseType baseType, GqlpGeneratorType generatorType, string enumName, string labelName)
  {
    // Arrange
    GqlpGeneratorContext context = Context(baseType, generatorType);
    IGqlpEnum enumType = A.Enum(enumName, [labelName]);

    // Act
    TypeGenerator.GenerateType(enumType, context);

    // Assert
    context.CheckForRequired(
      GeneratedCodeName(generatorType, enumName),
      GeneratedCodeLabel(generatorType, labelName));
  }

  [Theory, RepeatClassData(typeof(BaseGeneratorData))]
  public void GenerateType_WithEnumAlias_GeneratesCorrectCode(GqlpBaseType baseType, GqlpGeneratorType generatorType, string enumName, string labelName, string alias)
  {
    // Arrange
    GqlpGeneratorContext context = Context(baseType, generatorType);
    IGqlpEnumLabel label = A.Aliased<IGqlpEnumLabel>(labelName, [alias]);
    IGqlpEnum enumType = A.Enum(enumName)
      .WithLabels(label)
      .AsEnum;

    // Act
    TypeGenerator.GenerateType(enumType, context);

    // Assert
    context.CheckForRequired(
      GeneratedCodeName(generatorType, enumName),
      GeneratedCodeLabel(generatorType, labelName),
      GeneratedCodeLabel(generatorType, $"{alias} = {labelName}"));
  }

  [Theory, RepeatClassData(typeof(BaseGeneratorData))]
  public void GenerateType_WithParentItems_GeneratesCorrectCode(GqlpBaseType baseType, GqlpGeneratorType generatorType, string enumName, string parentName, string labelName)
  {
    // Arrange
    GqlpGeneratorContext context = Context(baseType, generatorType);
    IGqlpEnum enumType = A.Enum(enumName)
      .WithParent(parentName)
      .AsEnum;

    IGqlpEnum parentType = A.Enum(parentName, [labelName]);
    context.AddTypes([parentType]);

    // Act
    TypeGenerator.GenerateType(enumType, context);

    // Assert
    context.CheckForRequired(
      GeneratedCodeName(generatorType, enumName),
      GeneratedCodeParentLabel(generatorType, parentName, labelName));
  }

  [Theory, RepeatClassData(typeof(BaseGeneratorData))]
  public void GenerateType_WithParentAlias_GeneratesCorrectCode(GqlpBaseType baseType, GqlpGeneratorType generatorType, string enumName, string parentName, string labelName, string alias)
  {
    // Arrange
    GqlpGeneratorContext context = Context(baseType, generatorType);
    IGqlpEnum enumType = A.Enum(enumName)
      .WithParent(parentName)
      .AsEnum;

    IGqlpEnumLabel label = A.Aliased<IGqlpEnumLabel>(labelName, [alias]);
    IGqlpEnum parentType = A.Enum(parentName)
      .WithLabels(label)
      .AsEnum;

    context.AddTypes([parentType]);

    // Act
    TypeGenerator.GenerateType(enumType, context);

    // Assert
    string result = context.ToString();
    result.ShouldSatisfyAllConditions(
      CheckGeneratedCodeName(generatorType, enumName),
      CheckGeneratedCodeParentLabel(generatorType, parentName, labelName),
      CheckGeneratedCodeLabel(generatorType, $"{alias} = {parentName}.{labelName}"));
  }

  private static string GeneratedCodeLabel(GqlpGeneratorType generatorType, string label)
    => generatorType == GqlpGeneratorType.Enum ? label + "," : "";

  private static Action<string> CheckGeneratedCodeLabel(GqlpGeneratorType generatorType, string label)
    => ResultEmptyUnlessEnum(generatorType, result => result.ShouldContain(label + ","));

  private static string GeneratedCodeParentLabel(GqlpGeneratorType generatorType, string parent, string name)
    => generatorType == GqlpGeneratorType.Enum ? $"{name} = {parent}.{name}," : "";

  private static Action<string> CheckGeneratedCodeParentLabel(GqlpGeneratorType generatorType, string parent, string name)
    => ResultEmptyUnlessEnum(generatorType, result => result.ShouldContain($"{name} = {parent}.{name},"));

  protected override string GeneratedCodeName(GqlpGeneratorType generatorType, string name)
    => generatorType == GqlpGeneratorType.Enum ? "public enum " + TestPrefix + name : "";

  protected override string GeneratedCodeParent(GqlpGeneratorType generatorType, string parent)
    => "";

  protected override Action<string> CheckGeneratedCodeName(GqlpGeneratorType generatorType, string name)
    => ResultEmptyUnlessEnum(generatorType, result => result.ShouldContain("public enum " + TestPrefix + name));

  private static Action<string> ResultEmptyUnlessEnum(GqlpGeneratorType generatorType, Action<string> check)
    => generatorType == GqlpGeneratorType.Enum ? check
      : result => result.ShouldBeEmpty();
}

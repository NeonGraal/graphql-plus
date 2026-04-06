using GqlPlus.Building.Schema.Simple;

namespace GqlPlus.Generating.Simple;

public class EnumGeneratorTests
  : GenerateSimpleTestsBase<IGqlpEnum>
{
  private readonly EnumGenerator _generator;

  public EnumGeneratorTests()
    => _generator = new EnumGenerator();

  internal override GenerateForType<IGqlpEnum> TypeGenerator => _generator;

  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Interface;

  [Theory, RepeatData]
  public void TypeMembers_WithEnumItems_ReturnsAsNamePairs(string enumName, string labelName)
  {
    // Arrange
    GqlpGeneratorContext context = Context();
    IGqlpEnum enumType = A.Enum(enumName, [labelName]);

    MapPair<string> expected = new(labelName, "");

    // Act
    MapPair<string>[] result = [.. _generator.EnumMembers(enumType, context)];

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
    context.AddTypes(parentType);

    MapPair<string> expected = new(labelName, $" = {TestPrefix}{parentName}.{labelName}");

    // Act
    MapPair<string>[] result = [.. _generator.EnumMembers(enumType, context)];

    // Assert
    result.ShouldBe([expected]);
  }

  [Theory, RepeatData]
  public void GenerateType_WithEnumItems_GeneratesCorrectCode(string enumName, string labelName)
  {
    // Arrange
    GqlpGeneratorContext context = Context(GqlpBaseType.Interface, GqlpGeneratorType.Interface);
    IGqlpEnum enumType = A.Enum(enumName, [labelName]);

    // Act
    TypeGenerator.GenerateType(enumType, context);

    // Assert
    context.CheckFor(
      ForGeneratedCodeName(enumName),
      ForGeneratedEnum(labelName + ","));
  }

  [Theory, RepeatData]
  public void GenerateType_WithEnumAlias_GeneratesCorrectCode(string enumName, string labelName, string alias)
  {
    // Arrange
    GqlpGeneratorContext context = Context(GqlpBaseType.Interface, GqlpGeneratorType.Interface);
    IGqlpEnumLabel label = A.Aliased<IGqlpEnumLabel>(labelName, [alias]);
    IGqlpEnum enumType = A.Enum(enumName)
      .WithLabels(label)
      .AsEnum;

    // Act
    TypeGenerator.GenerateType(enumType, context);

    // Assert
    context.CheckFor(
      ForGeneratedCodeName(enumName),
      ForGeneratedEnum(labelName),
      ForGeneratedEnum($"{alias} = {labelName}"));
  }

  [Theory, RepeatData]
  public void GenerateType_WithParentItems_GeneratesCorrectCode(string enumName, string parentName, string labelName)
  {
    // Arrange
    GqlpGeneratorContext context = Context(GqlpBaseType.Interface, GqlpGeneratorType.Interface);
    IGqlpEnum enumType = A.Enum(enumName)
      .WithParent(parentName)
      .AsEnum;

    IGqlpEnum parentType = A.Enum(parentName, [labelName]);
    context.AddTypes(parentType);

    // Act
    TypeGenerator.GenerateType(enumType, context);

    // Assert
    context.CheckFor(
      ForGeneratedCodeName(enumName),
      ForGeneratedEnum($"{labelName} = {TestPrefix}{parentName}.{labelName},"));
  }

  [Theory, RepeatData]
  public void GenerateType_WithParentAlias_GeneratesCorrectCode(string enumName, string parentName, string labelName, string alias)
  {
    // Arrange
    GqlpGeneratorContext context = Context(GqlpBaseType.Interface, GqlpGeneratorType.Interface);
    IGqlpEnum enumType = A.Enum(enumName)
      .WithParent(parentName)
      .AsEnum;

    IGqlpEnumLabel label = A.Aliased<IGqlpEnumLabel>(labelName, [alias]);
    IGqlpEnum parentType = A.Enum(parentName)
      .WithLabels(label)
      .AsEnum;

    context.AddTypes(parentType);

    // Act
    TypeGenerator.GenerateType(enumType, context);

    // Assert
    context.CheckFor(
      ForGeneratedEnum("public enum " + TestPrefix + enumName),
      ForGeneratedEnum($"{labelName} = {TestPrefix}{parentName}.{labelName},"),
      ForGeneratedEnum($"{alias} = {TestPrefix}{parentName}.{labelName}"));
  }

  internal override ForType ForGeneratedCodeName(string name)
    => ForGeneratedEnum("public enum " + TestPrefix + name);

  internal override ForType ForGeneratedCodeParent(string parent)
    => generatorType => r => { };

  protected override void MakeItems(SimpleBuilder<IGqlpEnum> builder, params string[] items)
    => ((EnumBuilder)builder).WithLabels(items);
  protected override SimpleBuilder<IGqlpEnum> MakeSimple(string name)
    => new EnumBuilder(name);
}

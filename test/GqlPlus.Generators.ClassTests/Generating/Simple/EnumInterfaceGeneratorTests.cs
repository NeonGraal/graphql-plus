using GqlPlus.Building.Schema.Simple;

namespace GqlPlus.Generating.Simple;

public class EnumInterfaceGeneratorTests
  : GenerateSimpleTestsBase<IAstEnum, EnumLabelInput>
{
  private readonly EnumGenerator _generator;

  public EnumInterfaceGeneratorTests()
    => _generator = new EnumGenerator();

  internal override GenerateForType<IAstEnum> TypeGenerator => _generator;

  internal override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Interface;
  internal override GqlpBaseType BaseType => GqlpBaseType.Interface;

  [Theory, RepeatData]
  public void TypeMembers_WithEnumItems_ReturnsAsNamePairs(string enumName, string labelName)
  {
    // Arrange
    GqlpGeneratorContext context = Context();
    IAstEnum enumType = A.Enum(enumName, [labelName]);

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
    IAstEnum enumType = A.Enum(enumName)
      .WithParent(parentName)
      .AsEnum;

    IAstEnum parentType = A.Enum(parentName, [labelName]);
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
    IAstEnum enumType = A.Enum(enumName, [labelName]);

    // Act
    TypeGenerator.GenerateType(enumType, context);

    // Assert
    context.CheckFor(
      ForGeneratedCodeName(enumName),
      ForGeneratedInterface(labelName + ","));
  }

  [Theory, RepeatData]
  public void GenerateType_WithEnumAlias_GeneratesCorrectCode(string enumName, string labelName, string alias)
  {
    // Arrange
    GqlpGeneratorContext context = Context(GqlpBaseType.Interface, GqlpGeneratorType.Interface);
    IAstEnumLabel label = A.Aliased<IAstEnumLabel>(labelName, [alias]);
    IAstEnum enumType = A.Enum(enumName)
      .WithLabels(label)
      .AsEnum;

    // Act
    TypeGenerator.GenerateType(enumType, context);

    // Assert
    context.CheckFor(
      ForGeneratedCodeName(enumName),
      ForGeneratedInterface(labelName),
      ForGeneratedInterface($"{alias} = {labelName}"));
  }

  [Theory, RepeatData]
  public void GenerateType_WithParentItems_GeneratesCorrectCode(string enumName, string parentName, string labelName)
  {
    // Arrange
    GqlpGeneratorContext context = Context(GqlpBaseType.Interface, GqlpGeneratorType.Interface);
    IAstEnum enumType = A.Enum(enumName)
      .WithParent(parentName)
      .AsEnum;

    IAstEnum parentType = A.Enum(parentName, [labelName]);
    context.AddTypes(parentType);

    // Act
    TypeGenerator.GenerateType(enumType, context);

    // Assert
    context.CheckFor(
      ForGeneratedCodeName(enumName),
      ForGeneratedInterface($"{labelName} = {TestPrefix}{parentName}.{labelName},"));
  }

  [Theory, RepeatData]
  public void GenerateType_WithParentAlias_GeneratesCorrectCode(string enumName, string parentName, string labelName, string alias)
  {
    // Arrange
    GqlpGeneratorContext context = Context(GqlpBaseType.Interface, GqlpGeneratorType.Interface);
    IAstEnum enumType = A.Enum(enumName)
      .WithParent(parentName)
      .AsEnum;

    IAstEnumLabel label = A.Aliased<IAstEnumLabel>(labelName, [alias]);
    IAstEnum parentType = A.Enum(parentName)
      .WithLabels(label)
      .AsEnum;

    context.AddTypes(parentType);

    // Act
    TypeGenerator.GenerateType(enumType, context);

    // Assert
    context.CheckFor(
      ForGeneratedInterface("public enum " + TestPrefix + enumName),
      ForGeneratedInterface($"{labelName} = {TestPrefix}{parentName}.{labelName},"),
      ForGeneratedInterface($"{alias} = {TestPrefix}{parentName}.{labelName}"));
  }

  internal override ForType ForGeneratedCodeName(string name)
    => ForGeneratedInterface("public enum " + TestPrefix + name);

  internal override ForType ForGeneratedCodeParent(string parent)
    => _ => r => r.ShouldNotContain(": I" + parent);

  protected override void MakeItems(SimpleBuilder<IAstEnum> builder, params EnumLabelInput[] items)
    => ((EnumBuilder)builder).WithLabels([.. items.Select(i => i.Label)]);
  protected override SimpleBuilder<IAstEnum> MakeSimple(string name)
    => new EnumBuilder(name);

  internal override ForType ForGeneratedItem(string name, EnumLabelInput item)
    => ForGeneratedBoth(item.Label);
}

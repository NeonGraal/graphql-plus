namespace GqlPlus.Generating.Simple;

public class EnumGeneratorTests
  : TypeGeneratorClassTestBase<IGqlpEnum, IGqlpTypeRef>
{
  private readonly EnumGenerator _generator;

  public EnumGeneratorTests()
    => _generator = new EnumGenerator();

  public override string ExpectedTypePrefix => "Enum";
  internal override GenerateForType<IGqlpEnum> TypeGenerator => _generator;

  [Theory, RepeatData]
  public void TypeMembers_WithEnumItems_ReturnsAsNamePairs(string enumName, string labelName)
  {
    // Arrange
    GqlpGeneratorContext context = Context();
    IGqlpEnum enumType = A.Named<IGqlpEnum>(enumName);
    IGqlpEnumLabel label = A.Named<IGqlpEnumLabel>(labelName);
    enumType.Items.Returns([label]);
    enumType.Parent.Returns((IGqlpTypeRef?)null);

    // Act
    MapPair<string>[] result = [.. _generator.TypeMembers(enumType, context)];

    // Assert
    result.Length.ShouldBe(1);
    result[0].Key.ShouldBe(labelName);
    result[0].Value.ShouldBe("");
  }

  [Theory, RepeatData]
  public void TypeMembers_WithParentItems_ReturnsAsNamePairs(string enumName, string parentName, string labelName)
  {
    // Arrange
    GqlpGeneratorContext context = Context();
    IGqlpEnum enumType = A.Named<IGqlpEnum>(enumName);
    IGqlpTypeRef parentTypeRef = A.Named<IGqlpTypeRef>(parentName);
    enumType.Parent.Returns(parentTypeRef);

    IGqlpEnum parentType = A.Named<IGqlpEnum>(parentName);
    IGqlpEnumLabel label = A.Named<IGqlpEnumLabel>(labelName);
    parentType.Items.Returns([label]);

    context.AddTypes([parentType]);

    // Act
    MapPair<string>[] result = [.. _generator.TypeMembers(enumType, context)];

    // Assert
    result.Length.ShouldBe(1);
    result[0].Key.ShouldBe(labelName);
    result[0].Value.ShouldBe($" = {parentName}.{labelName}");
  }

  [Theory, RepeatData]
  public void GenerateType_WithEnumItems_GeneratesCorrectCode(string enumName, string labelName)
  {
    // Arrange
    GqlpGeneratorContext context = Context(GqlpBaseType.Other, GqlpGeneratorType.Enum);
    IGqlpEnum enumType = A.Parented<IGqlpEnum, IGqlpTypeRef>(enumName);
    IGqlpEnumLabel label = A.Named<IGqlpEnumLabel>(labelName);
    enumType.Items.Returns([label]);
    enumType.Parent.Returns((IGqlpTypeRef?)null);

    // Act
    TypeGenerator.GenerateType(enumType, context);

    // Assert
    string result = context.ToString();
    result.ShouldSatisfyAllConditions(
      CheckGeneratedCodeName(enumName),
      CheckGeneratedCodeLabel(labelName));
  }

  [Theory, RepeatData]
  public void GenerateType_WithEnumAlias_GeneratesCorrectCode(string enumName, string labelName, string alias)
  {
    // Arrange
    GqlpGeneratorContext context = Context(GqlpBaseType.Other, GqlpGeneratorType.Enum);
    IGqlpEnum enumType = A.Parented<IGqlpEnum, IGqlpTypeRef>(enumName);
    IGqlpEnumLabel label = A.Aliased<IGqlpEnumLabel>(labelName, [alias]);
    enumType.Items.Returns([label]);
    enumType.Parent.Returns((IGqlpTypeRef?)null);

    // Act
    TypeGenerator.GenerateType(enumType, context);

    // Assert
    string result = context.ToString();
    result.ShouldSatisfyAllConditions(
      CheckGeneratedCodeName(enumName),
      CheckGeneratedCodeLabel(labelName),
      CheckGeneratedCodeLabel($"{alias} = {labelName}"));
  }

  [Theory, RepeatData]
  public void GenerateType_WithParentItems_GeneratesCorrectCode(string enumName, string parentName, string labelName)
  {
    // Arrange
    GqlpGeneratorContext context = Context(GqlpBaseType.Other, GqlpGeneratorType.Enum);
    IGqlpEnum enumType = A.Parented<IGqlpEnum, IGqlpTypeRef>(enumName);
    IGqlpTypeRef parentTypeRef = A.Named<IGqlpTypeRef>(parentName);
    enumType.Parent.Returns(parentTypeRef);

    IGqlpEnum parentType = A.Named<IGqlpEnum>(parentName);
    IGqlpEnumLabel label = A.Named<IGqlpEnumLabel>(labelName);
    parentType.Items.Returns([label]);

    context.AddTypes([parentType]);

    // Act
    TypeGenerator.GenerateType(enumType, context);

    // Assert
    string result = context.ToString();
    result.ShouldSatisfyAllConditions(
      CheckGeneratedCodeName(enumName),
      CheckGeneratedCodeParentLabel(parentName, labelName));
  }

  [Theory, RepeatData]
  public void GenerateType_WithParentAlias_GeneratesCorrectCode(string enumName, string parentName, string labelName, string alias)
  {
    // Arrange
    GqlpGeneratorContext context = Context(GqlpBaseType.Other, GqlpGeneratorType.Enum);
    IGqlpEnum enumType = A.Parented<IGqlpEnum, IGqlpTypeRef>(enumName);
    IGqlpTypeRef parentTypeRef = A.Named<IGqlpTypeRef>(parentName);
    enumType.Parent.Returns(parentTypeRef);

    IGqlpEnum parentType = A.Named<IGqlpEnum>(parentName);
    IGqlpEnumLabel label = A.Aliased<IGqlpEnumLabel>(labelName, [alias]);
    parentType.Items.Returns([label]);

    context.AddTypes([parentType]);

    // Act
    TypeGenerator.GenerateType(enumType, context);

    // Assert
    string result = context.ToString();
    result.ShouldSatisfyAllConditions(
      CheckGeneratedCodeName(enumName),
      CheckGeneratedCodeParentLabel(parentName, labelName),
      CheckGeneratedCodeLabel($"{alias} = {parentName}.{labelName}"));
  }

  internal override GqlpGeneratorContext BaseContext()
    => Context(GqlpBaseType.Other, GqlpGeneratorType.Enum);

  protected override Action<string> CheckGeneratedCodeName(string name)
    => result => result.ShouldContain("public enum " + name);

  protected override Action<string> CheckGeneratedCodeParent(string parent)
    => result => { };

  private static Action<string> CheckGeneratedCodeLabel(string name)
    => result => result.ShouldContain(name + ",");

  private static Action<string> CheckGeneratedCodeParentLabel(string parent, string name)
    => result => result.ShouldContain($"{name} = {parent}.{name},");
}

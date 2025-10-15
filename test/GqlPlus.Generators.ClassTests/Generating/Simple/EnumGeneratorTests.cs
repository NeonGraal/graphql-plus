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

  [Theory, RepeatMemberData(nameof(BaseGeneratorData))]
  public void GenerateType_WithEnumItems_GeneratesCorrectCode(GqlpBaseType baseType, GqlpGeneratorType generatorType, string enumName, string labelName)
  {
    // Arrange
    GqlpGeneratorContext context = Context(baseType, generatorType);
    IGqlpEnum enumType = A.Parented<IGqlpEnum, IGqlpTypeRef>(enumName);
    IGqlpEnumLabel label = A.Named<IGqlpEnumLabel>(labelName);
    enumType.Items.Returns([label]);
    enumType.Parent.Returns((IGqlpTypeRef?)null);

    // Act
    TypeGenerator.GenerateType(enumType, context);

    // Assert
    string result = context.ToString();
    result.ShouldSatisfyAllConditions(
      CheckGeneratedCodeName(generatorType, enumName),
      CheckGeneratedCodeLabel(generatorType, labelName));
  }

  [Theory, RepeatMemberData(nameof(BaseGeneratorData))]
  public void GenerateType_WithEnumAlias_GeneratesCorrectCode(GqlpBaseType baseType, GqlpGeneratorType generatorType, string enumName, string labelName, string alias)
  {
    // Arrange
    GqlpGeneratorContext context = Context(baseType, generatorType);
    IGqlpEnum enumType = A.Parented<IGqlpEnum, IGqlpTypeRef>(enumName);
    IGqlpEnumLabel label = A.Aliased<IGqlpEnumLabel>(labelName, [alias]);
    enumType.Items.Returns([label]);
    enumType.Parent.Returns((IGqlpTypeRef?)null);

    // Act
    TypeGenerator.GenerateType(enumType, context);

    // Assert
    string result = context.ToString();
    result.ShouldSatisfyAllConditions(
      CheckGeneratedCodeName(generatorType, enumName),
      CheckGeneratedCodeLabel(generatorType, labelName),
      CheckGeneratedCodeLabel(generatorType, $"{alias} = {labelName}"));
  }

  [Theory, RepeatMemberData(nameof(BaseGeneratorData))]
  public void GenerateType_WithParentItems_GeneratesCorrectCode(GqlpBaseType baseType, GqlpGeneratorType generatorType, string enumName, string parentName, string labelName)
  {
    // Arrange
    GqlpGeneratorContext context = Context(baseType, generatorType);
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
      CheckGeneratedCodeName(generatorType, enumName),
      CheckGeneratedCodeParentLabel(generatorType, parentName, labelName));
  }

  [Theory, RepeatMemberData(nameof(BaseGeneratorData))]
  public void GenerateType_WithParentAlias_GeneratesCorrectCode(GqlpBaseType baseType, GqlpGeneratorType generatorType, string enumName, string parentName, string labelName, string alias)
  {
    // Arrange
    GqlpGeneratorContext context = Context(baseType, generatorType);
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
      CheckGeneratedCodeName(generatorType, enumName),
      CheckGeneratedCodeParentLabel(generatorType, parentName, labelName),
      CheckGeneratedCodeLabel(generatorType, $"{alias} = {parentName}.{labelName}"));
  }

  private static Action<string> CheckGeneratedCodeLabel(GqlpGeneratorType generatorType, string label)
    => ResultEmptyUnlessEnum(generatorType, result => result.ShouldContain(label + ","));

  private static Action<string> CheckGeneratedCodeParentLabel(GqlpGeneratorType generatorType, string parent, string name)
    => ResultEmptyUnlessEnum(generatorType, result => result.ShouldContain($"{name} = {parent}.{name},"));

  protected override Action<string> CheckGeneratedCodeName(GqlpGeneratorType generatorType, string name)
    => ResultEmptyUnlessEnum(generatorType, result => result.ShouldContain("public enum test" + name));

  protected override Action<string> CheckGeneratedCodeParent(GqlpGeneratorType generatorType, string parent)
    => result => { };

  private static Action<string> ResultEmptyUnlessEnum(GqlpGeneratorType generatorType, Action<string> check)
    => generatorType == GqlpGeneratorType.Enum ? check
      : result => result.ShouldBeEmpty();
}

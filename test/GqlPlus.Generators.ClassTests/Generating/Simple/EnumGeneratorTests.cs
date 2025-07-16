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
    IGqlpEnum enumType = A.Named<IGqlpEnum>(enumName);
    IGqlpEnumLabel label = A.Named<IGqlpEnumLabel>(labelName);
    enumType.Items.Returns([label]);
    enumType.Parent.Returns((IGqlpTypeRef?)null);

    // Act
    MapPair<string>[] result = [.. _generator.TypeMembers(enumType, Context)];

    // Assert
    result.Length.ShouldBe(1);
    result[0].Key.ShouldBe(labelName);
    result[0].Value.ShouldBe("");
  }

  protected override Action<string> CheckGeneratedCodeName(string name)
    => result => result.ShouldContain("public enum " + name);

  protected override Action<string> CheckGeneratedCodeParent(string parent)
    => result => { };
}

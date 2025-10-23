using GqlPlus.Building.Schema.Simple;

namespace GqlPlus.Modelling.Simple;

public class EnumModellerTests
  : TypeModellerTests<IGqlpEnum, TypeEnumModel>
{
  public EnumModellerTests()
    : base(TypeKindModel.Enum)
  { }

  protected override IModeller<IGqlpEnum, TypeEnumModel> Modeller { get; } = new EnumModeller();

  [Theory, RepeatData]
  public void ToModel_WithValidEnum_ReturnsExpectedTypeEnumModel(
    string name,
    string labelName,
    string contents,
    string[] aliases)
  {
    // Arrange
    IGqlpEnumLabel label = A.Aliased<IGqlpEnumLabel>(labelName, aliases, contents);
    IGqlpEnum ast = A.Enum(name).WithLabels(label).AsEnum;

    // Act
    TypeEnumModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Items.ShouldHaveSingleItem()
          .ShouldSatisfyAllConditions(
            m => m.Name.ShouldBe(labelName),
            m => m.Aliases.ShouldBe(aliases),
            m => m.Description.ShouldBe(contents)));
  }
}

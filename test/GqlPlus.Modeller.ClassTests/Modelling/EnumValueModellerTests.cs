namespace GqlPlus.Modelling;

public class EnumValueModellerTests
  : ModellerClassTestBase<IGqlpEnumValue, EnumValueModel>
{

  private readonly EnumValueModeller _modeller = new();

  protected override IModeller<IGqlpEnumValue, EnumValueModel> Modeller => _modeller;

  [Theory, RepeatData]
  public void ToModel_WithTypeAndLabel_ReturnsExpected(string type)
  {
    // Arrange
    IGqlpEnumValue ast = A.EnumValue(type, TestLabel);

    // Act
    EnumValueModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(type),
        r => r.Label.ShouldBe(TestLabel));
  }
}

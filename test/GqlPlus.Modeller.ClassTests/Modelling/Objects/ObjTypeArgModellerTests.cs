namespace GqlPlus.Modelling.Objects;

public class ObjTypeArgModellerTests
  : ModellerClassTestBase<IGqlpObjTypeArg, ObjTypeArgModel>
{
  private readonly IModeller<IGqlpEnumValue, EnumValueModel> _enumValue;

  public ObjTypeArgModellerTests()
  {
    _enumValue = MFor<IGqlpEnumValue, EnumValueModel>();

    Modeller = new ObjTypeArgModeller(_enumValue);
  }

  protected override IModeller<IGqlpObjTypeArg, ObjTypeArgModel> Modeller { get; }

  [Theory, RepeatData]
  public void ToModel_WithValidArg_ReturnsExpectedOutputArgModel(string name)
  {
    // Arrange
    IGqlpObjTypeArg ast = A.ObjTypeArg(name, true);

    // Act
    ObjTypeArgModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.IsTypeParam.ShouldBeTrue()
      );
  }

  [Theory, RepeatData]
  public void ToModel_WithValidEnumArg_ReturnsExpectedOutputArgModel(string enumType, string enumLabel)
  {
    // Arrange
    IGqlpObjTypeArg ast = A.ObjTypeArg(enumType);
    IGqlpEnumValue enumValue = A.EnumValue(enumType, enumLabel);
    ast.EnumValue.Returns(enumValue);

    EnumValueModel enumModel = new(enumType, enumLabel, "");
    ToModelReturns(_enumValue, enumModel);

    // Act
    ObjTypeArgModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(enumType),
        r => r.EnumValue.ShouldBe(enumModel),
        r => r.IsTypeParam.ShouldBeFalse()
      );
  }
}

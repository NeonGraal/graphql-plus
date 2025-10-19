namespace GqlPlus.Modelling.Objects;

public class TypeArgModellerTests
  : ModellerClassTestBase<IGqlpTypeArg, TypeArgModel>
{
  private readonly IModeller<IGqlpEnumValue, EnumValueModel> _enumValue;

  public TypeArgModellerTests()
  {
    _enumValue = MFor<IGqlpEnumValue, EnumValueModel>();

    Modeller = new TypeArgModeller(_enumValue);
  }

  protected override IModeller<IGqlpTypeArg, TypeArgModel> Modeller { get; }

  [Theory, RepeatData]
  public void ToModel_WithValidArg_ReturnsExpectedOutputArgModel(string name)
  {
    // Arrange
    IGqlpTypeArg ast = A.TypeArg(name, true);

    // Act
    TypeArgModel result = Modeller.ToModel(ast, TypeKinds);

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
    IGqlpTypeArg ast = A.TypeArg(enumType);
    IGqlpEnumValue enumValue = A.EnumValue(enumType, enumLabel);
    ast.EnumValue.Returns(enumValue);

    EnumValueModel enumModel = new(enumType, enumLabel, "");
    ToModelReturns(_enumValue, enumModel);

    // Act
    TypeArgModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(enumType),
        r => r.EnumValue.ShouldBe(enumModel),
        r => r.IsTypeParam.ShouldBeFalse()
      );
  }
}

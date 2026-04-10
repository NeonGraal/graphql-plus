using GqlPlus.Building.Schema.Objects;

namespace GqlPlus.Modelling.Objects;

public class TypeArgModellerTests
  : ModellerClassTestBase<IAstTypeArg, TypeArgModel>
{
  private readonly IModeller<IAstEnumValue, EnumValueModel> _enumValue;

  public TypeArgModellerTests()
  {
    _enumValue = MFor<IAstEnumValue, EnumValueModel>();

    Modeller = new TypeArgModeller(_enumValue);
  }

  protected override IModeller<IAstTypeArg, TypeArgModel> Modeller { get; }

  [Theory, RepeatData]
  public void ToModel_WithValidArg_ReturnsExpectedOutputArgModel(string name)
  {
    // Arrange
    IAstTypeArg ast = A.TypeArg(name).IsTypeParam().AsTypeArg;

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
    IAstTypeArg ast = A.TypeArg(enumType).AsTypeArg;
    IAstEnumValue enumValue = A.EnumValue(enumType, enumLabel);
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

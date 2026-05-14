using GqlPlus.Building;

namespace GqlPlus.Modelling;

public class ConstantModellerTests
  : ModellerClassTestBase<IAstConstant, ConstantModel>
{
  private readonly IModeller<IAstFieldKey, SimpleModel> _fieldKeyModeller;

  protected override IModeller<IAstConstant, ConstantModel> Modeller { get; }

  public ConstantModellerTests()
  {
    _fieldKeyModeller = MFor<IAstFieldKey, SimpleModel>();
    IModellerRepository modellers = A.Of<IModellerRepository>();
    ModellerForReturns(modellers, _fieldKeyModeller);
    Modeller = new ConstantModeller(modellers);
  }

  [Theory, RepeatData]
  public void ToModel_WithFields_ReturnsExpectedConstantModel(string key, string value)
  {
    // Arrange
    IAstConstant ast = A.Constant().WithField(key, value).AsConstant;

    _fieldKeyModeller.ToModel(Arg.Any<IAstFieldKey>(), TypeKinds)
        .Returns(SimpleModel.Str(value));

    // Act
    ConstantModel result = Modeller.ToModel<ConstantModel>(ast, TypeKinds);

    // Assert
    result.ShouldBeOfType<ConstantModel>();
  }

  [Theory, RepeatData]
  public void ToModel_WithValues_ReturnsExpectedConstantModel(string[] values)
  {
    // Arrange
    IAstConstant ast = A.Constant(values);

    // Act
    ConstantModel result = Modeller.ToModel<ConstantModel>(ast, TypeKinds);

    // Assert
    result.ShouldBeOfType<ConstantModel>();
  }

  [Theory, RepeatData]
  public void ToModel_WithNullValue_ReturnsDefaultConstantModel(string value)
  {
    // Arrange
    IAstConstant ast = A.Constant(value);

    // Act
    ConstantModel result = Modeller.ToModel<ConstantModel>(ast, TypeKinds);

    // Assert
    result.ShouldBeOfType<ConstantModel>();
  }
}

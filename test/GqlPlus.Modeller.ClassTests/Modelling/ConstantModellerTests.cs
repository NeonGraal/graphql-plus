namespace GqlPlus.Modelling;

public class ConstantModellerTests
  : ModellerClassTestBase<IGqlpConstant, ConstantModel>
{
  private readonly IModeller<IGqlpFieldKey, SimpleModel> _fieldKeyModeller;

  protected override IModeller<IGqlpConstant, ConstantModel> Modeller { get; }

  public ConstantModellerTests()
  {
    _fieldKeyModeller = MFor<IGqlpFieldKey, SimpleModel>();
    Modeller = new ConstantModeller(_fieldKeyModeller);
  }

  [Theory, RepeatData]
  public void ToModel_WithFields_ReturnsExpectedConstantModel(string key, string value)
  {
    // Arrange
    IGqlpConstant valueConstant = A.Constant(value);
    IGqlpConstant ast = A.Constant(key, valueConstant);

    _fieldKeyModeller.ToModel(Arg.Any<IGqlpFieldKey>(), TypeKinds)
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
    IGqlpConstant ast = A.Constant(values);

    // Act
    ConstantModel result = Modeller.ToModel<ConstantModel>(ast, TypeKinds);

    // Assert
    result.ShouldBeOfType<ConstantModel>();
  }

  [Theory, RepeatData]
  public void ToModel_WithNullValue_ReturnsDefaultConstantModel(string value)
  {
    // Arrange
    IGqlpConstant ast = A.Constant(value);

    // Act
    ConstantModel result = Modeller.ToModel<ConstantModel>(ast, TypeKinds);

    // Assert
    result.ShouldBeOfType<ConstantModel>();
  }
}

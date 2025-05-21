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
    IGqlpConstant ast = For<IGqlpConstant>();

    IGqlpConstant fieldConstant = CFor(value);
    IGqlpFields<IGqlpConstant> astFields = FieldsFor(key, fieldConstant);
    ast.Fields.Returns(astFields);

    _fieldKeyModeller.ToModel(Arg.Any<IGqlpFieldKey>(), TypeKinds)
        .Returns(SimpleModel.Str("", value));

    // Act
    ConstantModel result = Modeller.ToModel<ConstantModel>(ast, TypeKinds);

    // Assert
    result.ShouldBeOfType<ConstantModel>();
  }

  [Theory, RepeatData]
  public void ToModel_WithValues_ReturnsExpectedConstantModel(string[] values)
  {
    // Arrange
    IGqlpConstant ast = For<IGqlpConstant>();
    ast.Values.Returns(values.Select(CFor));

    // Act
    ConstantModel result = Modeller.ToModel<ConstantModel>(ast, TypeKinds);

    // Assert
    result.ShouldBeOfType<ConstantModel>();
  }

  [Theory, RepeatData]
  public void ToModel_WithNullValue_ReturnsDefaultConstantModel(string value)
  {
    // Arrange
    IGqlpConstant ast = CFor(value);

    // Act
    ConstantModel result = Modeller.ToModel<ConstantModel>(ast, TypeKinds);

    // Assert
    result.ShouldBeOfType<ConstantModel>();
  }
}

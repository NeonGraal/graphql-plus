namespace GqlPlus.Modelling.Objects;

public class InputFieldModellerTests
  : ModellerClassTestBase<IGqlpInputField, InputFieldModel>
{
  private readonly IModeller<IGqlpInputBase, InputBaseModel> _objBase = MFor<IGqlpInputBase, InputBaseModel>();

  public InputFieldModellerTests()
  {
    IModifierModeller modifier = For<IModifierModeller>();
    IModeller<IGqlpConstant, ConstantModel> constant = MFor<IGqlpConstant, ConstantModel>();

    Modeller = new InputFieldModeller(modifier, _objBase, constant);
  }

  protected override IModeller<IGqlpInputField, InputFieldModel> Modeller { get; }

  [Theory, RepeatData]
  public void FieldModel_WithValidField_ReturnsExpectedInputFieldModel(string name, string contents, string typeName)
  {
    // Arrange
    IGqlpInputField ast = NFor<IGqlpInputField>(name);
    ast.Description.Returns(contents);
    IGqlpInputBase type = For<IGqlpInputBase>();
    type.Input.Returns(typeName);
    ast.BaseType.Returns(type);
    InputBaseModel inputType = new(typeName, "");
    _objBase.ToModel(type, TypeKinds).Returns(inputType);

    // Act
    InputFieldModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Description.ShouldBe(contents),
        r => r.Type.ShouldBe(inputType)
      );
  }
}

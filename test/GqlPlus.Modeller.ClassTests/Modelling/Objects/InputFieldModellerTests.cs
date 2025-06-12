namespace GqlPlus.Modelling.Objects;

public class InputFieldModellerTests
  : ModellerObjectBaseTestBase<IGqlpInputField, InputFieldModel, IGqlpInputBase, InputBaseModel>
{
  public InputFieldModellerTests()
  {
    IModifierModeller modifier = A.Of<IModifierModeller>();
    IModeller<IGqlpConstant, ConstantModel> constant = MFor<IGqlpConstant, ConstantModel>();

    Modeller = new InputFieldModeller(modifier, ObjBase, constant);
  }

  protected override IModeller<IGqlpInputField, InputFieldModel> Modeller { get; }

  [Theory, RepeatData]
  public void FieldModel_WithValidField_ReturnsExpectedInputFieldModel(string name, string contents, string typeName)
  {
    // Arrange
    IGqlpInputField ast = A.InputField(name, typeName, contents);

    InputBaseModel inputType = new(typeName, "");
    ToModelReturns(ObjBase, inputType);

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

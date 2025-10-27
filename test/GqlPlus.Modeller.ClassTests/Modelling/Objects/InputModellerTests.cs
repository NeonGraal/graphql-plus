namespace GqlPlus.Modelling.Objects;

public class InputModellerTests
  : ModellerObjectBaseTestBase<IGqlpObject<IGqlpInputField>, TypeInputModel, ObjBaseModel>
{
  public InputModellerTests()
  {
    IModeller<IGqlpTypeParam, TypeParamModel> typeParam = MFor<IGqlpTypeParam, TypeParamModel>();
    IModeller<IGqlpAlternate, AlternateModel> alternate = MFor<IGqlpAlternate, AlternateModel>();
    IModeller<IGqlpInputField, InputFieldModel> objField = MFor<IGqlpInputField, InputFieldModel>();

    Modeller = new InputModeller(new(typeParam, alternate, objField, ObjBase));
  }

  protected override IModeller<IGqlpObject<IGqlpInputField>, TypeInputModel> Modeller { get; }

  [Theory, RepeatData]
  public void ToModel_WithValidObject_ReturnsExpectedTypeInputModel(string name, string[] aliases, string content)
  {
    // Arrange
    IGqlpObject<IGqlpInputField> ast = A.Aliased<IGqlpObject<IGqlpInputField>>(name, aliases, content);

    // Act
    TypeInputModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Description.ShouldBe(content),
        r => r.Aliases.ShouldBe(aliases));
  }
}

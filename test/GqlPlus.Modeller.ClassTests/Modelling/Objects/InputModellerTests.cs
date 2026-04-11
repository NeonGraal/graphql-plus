namespace GqlPlus.Modelling.Objects;

public class InputModellerTests
  : ModellerObjectBaseTestBase<IAstObject<IAstInputField>, TypeInputModel, ObjBaseModel>
{
  public InputModellerTests()
  {
    IModeller<IAstTypeParam, TypeParamModel> typeParam = MFor<IAstTypeParam, TypeParamModel>();
    IModeller<IAstAlternate, AlternateModel> alternate = MFor<IAstAlternate, AlternateModel>();
    IModeller<IAstInputField, InputFieldModel> objField = MFor<IAstInputField, InputFieldModel>();

    Modeller = new InputModeller(new(typeParam, alternate, objField, ObjBase));
  }

  protected override IModeller<IAstObject<IAstInputField>, TypeInputModel> Modeller { get; }

  [Theory, RepeatData]
  public void ToModel_WithValidObject_ReturnsExpectedTypeInputModel(string name, string[] aliases, string content)
  {
    // Arrange
    IAstObject<IAstInputField> ast = A.Aliased<IAstObject<IAstInputField>>(name, aliases, content);

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

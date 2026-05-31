namespace GqlPlus.Modelling;

public class InputModellerTests
  : ModellerObjectBaseTestBase<IAstObject<IAstInputField>, TypeInputModel, ObjBaseModel>
{
  public InputModellerTests()
  {
    IModeller<IAstTypeParam, TypeParamModel> typeParam = MFor<IAstTypeParam, TypeParamModel>();
    IModeller<IAstAlternate, AlternateModel> alternate = MFor<IAstAlternate, AlternateModel>();
    IModeller<IAstInputField, InputFieldModel> objField = MFor<IAstInputField, InputFieldModel>();

    IModellerRepository modellers = A.Of<IModellerRepository>();
    ModellerForReturns(modellers, typeParam);
    ModellerForReturns(modellers, alternate);
    ModellerForReturns(modellers, objField);
    ModellerForReturns(modellers, ObjBase);
    Modeller = new InputModeller(modellers);
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

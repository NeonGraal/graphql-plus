using GqlPlus.Ast.Schema;

namespace GqlPlus.Modelling.Objects;

public class InputModellerTests
  : ModellerObjectBaseTestBase<IAstObject<IAstInputField>, TypeInputModel, ObjBaseModel>
{
  public InputModellerTests()
  {
    IModeller<IAstTypeParam, TypeParamModel> typeParam = MFor<IAstTypeParam, TypeParamModel>();
    IModeller<IAstAlternate, AlternateModel> alternate = MFor<IAstAlternate, AlternateModel>();
    IModeller<IAstInputField, InputFieldModel> objField = MFor<IAstInputField, InputFieldModel>();

    IModellerRepository modellers = A.Of<IModellerRepository>();
    modellers.ModellerFor<IAstTypeParam, TypeParamModel>().Returns(typeParam);
    modellers.ModellerFor<IAstAlternate, AlternateModel>().Returns(alternate);
    modellers.ModellerFor<IAstInputField, InputFieldModel>().Returns(objField);
    modellers.ModellerFor<IAstObjBase, ObjBaseModel>().Returns(ObjBase);
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

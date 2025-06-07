namespace GqlPlus.Modelling.Objects;

public class InputModellerTests
  : ModellerObjectBaseTestBase<IGqlpInputObject, TypeInputModel, IGqlpInputBase, InputBaseModel>
{
  public InputModellerTests()
  {
    IModeller<IGqlpTypeParam, TypeParamModel> typeParam = MFor<IGqlpTypeParam, TypeParamModel>();
    IModeller<IGqlpInputAlternate, InputAlternateModel> objAlt = MFor<IGqlpInputAlternate, InputAlternateModel>();
    IModeller<IGqlpInputField, InputFieldModel> objField = MFor<IGqlpInputField, InputFieldModel>();

    Modeller = new InputModeller(new(typeParam, objAlt, objField, ObjBase));
  }

  protected override IModeller<IGqlpInputObject, TypeInputModel> Modeller { get; }

  [Theory, RepeatData]
  public void ToModel_WithValidObject_ReturnsExpectedTypeInputModel(string name, string[] aliases, string content)
  {
    // Arrange
    IGqlpInputObject ast = A.Named<IGqlpInputObject>(name, content);
    ast.Aliases.Returns(aliases);

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

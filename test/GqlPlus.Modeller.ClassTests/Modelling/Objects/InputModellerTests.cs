namespace GqlPlus.Modelling.Objects;

public class InputModellerTests
  : ModellerClassTestBase<IGqlpInputObject, TypeInputModel>
{
  public InputModellerTests()
  {
    IModeller<IGqlpInputAlternate, InputAlternateModel> objAlt = MFor<IGqlpInputAlternate, InputAlternateModel>();
    IModeller<IGqlpInputField, InputFieldModel> objField = MFor<IGqlpInputField, InputFieldModel>();
    IModeller<IGqlpInputBase, InputBaseModel> objBase = MFor<IGqlpInputBase, InputBaseModel>();

    Modeller = new InputModeller(objAlt, objField, objBase);
  }

  protected override IModeller<IGqlpInputObject, TypeInputModel> Modeller { get; }

  [Theory, RepeatData]
  public void ToModel_WithValidObject_ReturnsExpectedTypeInputModel(string name, string[] aliases, string content)
  {
    // Arrange
    IGqlpInputObject ast = For<IGqlpInputObject>();
    ast.Name.Returns(name);
    ast.Description.Returns(content);
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

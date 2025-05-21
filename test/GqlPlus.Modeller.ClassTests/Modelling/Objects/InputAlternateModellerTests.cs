namespace GqlPlus.Modelling.Objects;

public class InputAlternateModellerTests
  : ModellerClassTestBase<IGqlpInputAlternate, InputAlternateModel>
{
  public InputAlternateModellerTests()
  {
    IModeller<IGqlpInputArg, InputArgModel> objArg = MFor<IGqlpInputArg, InputArgModel>();
    IModeller<IGqlpModifier, CollectionModel> collection = MFor<IGqlpModifier, CollectionModel>();
    IModeller<IGqlpDualAlternate, DualAlternateModel> dual = MFor<IGqlpDualAlternate, DualAlternateModel>();

    Modeller = new InputAlternateModeller(objArg, collection, dual);
  }

  protected override IModeller<IGqlpInputAlternate, InputAlternateModel> Modeller { get; }

  [Theory, RepeatData]
  public void AlternateModel_WithValidAlternate_ReturnsExpectedInputAlternateModel(string name, string contents)
  {
    // Arrange
    IGqlpInputAlternate ast = For<IGqlpInputAlternate>();
    ast.Input.Returns(name);
    ast.Description.Returns(contents);

    // Act
    InputAlternateModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Input.ShouldBe(name),
        r => r.Description.ShouldBe(contents)
      );
  }
}

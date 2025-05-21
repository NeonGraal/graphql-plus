namespace GqlPlus.Modelling.Objects;

public class DualAlternateModellerTests
  : ModellerClassTestBase<IGqlpDualAlternate, DualAlternateModel>
{
  public DualAlternateModellerTests()
  {
    IModeller<IGqlpDualArg, DualArgModel> objArg = MFor<IGqlpDualArg, DualArgModel>();
    IModeller<IGqlpModifier, CollectionModel> collection = MFor<IGqlpModifier, CollectionModel>();

    Modeller = new DualAlternateModeller(objArg, collection);
  }

  protected override IModeller<IGqlpDualAlternate, DualAlternateModel> Modeller { get; }

  [Theory, RepeatData]
  public void AlternateModel_WithValidAlternate_ReturnsExpectedDualAlternateModel(string name, string contents)
  {
    // Arrange
    IGqlpDualAlternate ast = For<IGqlpDualAlternate>();
    ast.Dual.Returns(name);
    ast.Description.Returns(contents);

    // Act
    DualAlternateModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Dual.ShouldBe(name),
        r => r.Description.ShouldBe(contents)
      );
  }
}

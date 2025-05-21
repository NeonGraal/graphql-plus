namespace GqlPlus.Modelling.Objects;

public class OutputAlternateModellerTests
  : ModellerClassTestBase<IGqlpOutputAlternate, OutputAlternateModel>
{
  public OutputAlternateModellerTests()
  {
    IModeller<IGqlpOutputArg, OutputArgModel> objArg = MFor<IGqlpOutputArg, OutputArgModel>();
    IModeller<IGqlpModifier, CollectionModel> collection = MFor<IGqlpModifier, CollectionModel>();
    IModeller<IGqlpDualAlternate, DualAlternateModel> dual = MFor<IGqlpDualAlternate, DualAlternateModel>();

    Modeller = new OutputAlternateModeller(objArg, collection, dual);
  }

  protected override IModeller<IGqlpOutputAlternate, OutputAlternateModel> Modeller { get; }

  [Theory, RepeatData]
  public void AlternateModel_WithValidAlternate_ReturnsExpectedOutputAlternateModel(string name, string contents)
  {
    // Arrange
    IGqlpOutputAlternate ast = For<IGqlpOutputAlternate>();
    ast.Output.Returns(name);
    ast.Description.Returns(contents);

    // Act
    OutputAlternateModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Output.ShouldBe(name),
        r => r.Description.ShouldBe(contents)
      );
  }
}

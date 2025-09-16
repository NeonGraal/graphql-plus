namespace GqlPlus.Modelling.Objects;

public class OutputAlternateModellerTests
  : ModellerObjectBaseTestBase<IGqlpOutputAlternate, ObjAlternateModel, IGqlpOutputBase, OutputBaseModel>
{
  public OutputAlternateModellerTests()
  {
    IModeller<IGqlpModifier, CollectionModel> collection = MFor<IGqlpModifier, CollectionModel>();

    Modeller = new OutputAlternateModeller(collection, ObjBase);
  }

  protected override IModeller<IGqlpOutputAlternate, ObjAlternateModel> Modeller { get; }

  [Theory, RepeatData]
  public void AlternateModel_WithValidAlternate_ReturnsExpectedOutputAlternateModel(string name, string contents)
  {
    // Arrange
    IGqlpOutputAlternate ast = A.Named<IGqlpOutputAlternate>(name, contents);

    OutputBaseModel outputType = new(name, contents);
    ToModelReturns(ObjBase, ast, outputType);

    // Act
    ObjAlternateModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .Type.ShouldBe(outputType);
  }
}

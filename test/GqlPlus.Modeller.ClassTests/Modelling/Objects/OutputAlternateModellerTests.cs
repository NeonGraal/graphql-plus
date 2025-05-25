namespace GqlPlus.Modelling.Objects;

public class OutputAlternateModellerTests
  : ModellerObjectBaseTestBase<IGqlpOutputAlternate, OutputAlternateModel, IGqlpOutputBase, OutputBaseModel>
{
  public OutputAlternateModellerTests()
  {
    IModeller<IGqlpModifier, CollectionModel> collection = MFor<IGqlpModifier, CollectionModel>();

    Modeller = new OutputAlternateModeller(collection, ObjBase);
  }

  protected override IModeller<IGqlpOutputAlternate, OutputAlternateModel> Modeller { get; }

  [Theory, RepeatData]
  public void AlternateModel_WithValidAlternate_ReturnsExpectedOutputAlternateModel(string name, string contents)
  {
    // Arrange
    IGqlpOutputAlternate ast = For<IGqlpOutputAlternate>();
    ast.Output.Returns(name);
    ast.Description.Returns(contents);
    OutputBaseModel outputType = new(name, contents);
    ObjBase.ToModel(ast, TypeKinds).Returns(outputType);

    // Act
    OutputAlternateModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .BaseType.ShouldBe(outputType);
  }
}

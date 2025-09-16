namespace GqlPlus.Modelling.Objects;

public class InputAlternateModellerTests
  : ModellerObjectBaseTestBase<IGqlpInputAlternate, ObjAlternateModel, IGqlpInputBase, InputBaseModel>
{
  public InputAlternateModellerTests()
  {
    IModeller<IGqlpModifier, CollectionModel> collection = MFor<IGqlpModifier, CollectionModel>();

    Modeller = new InputAlternateModeller(collection, ObjBase);
  }

  protected override IModeller<IGqlpInputAlternate, ObjAlternateModel> Modeller { get; }

  [Theory, RepeatData]
  public void AlternateModel_WithValidAlternate_ReturnsExpectedInputAlternateModel(string name, string contents)
  {
    // Arrange
    IGqlpInputAlternate ast = A.Named<IGqlpInputAlternate>(name, contents);
    InputBaseModel inputType = new(name, contents);
    ObjBase.ToModel(ast, TypeKinds).Returns(inputType);

    // Act
    ObjAlternateModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .Type.ShouldBe(inputType);
  }
}

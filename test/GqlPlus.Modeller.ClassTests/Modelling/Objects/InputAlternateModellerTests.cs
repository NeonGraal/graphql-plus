namespace GqlPlus.Modelling.Objects;

public class InputAlternateModellerTests
  : ModellerObjectBaseTestBase<IGqlpInputAlternate, InputAlternateModel, IGqlpInputBase, InputBaseModel>
{
  public InputAlternateModellerTests()
  {
    IModeller<IGqlpModifier, CollectionModel> collection = MFor<IGqlpModifier, CollectionModel>();

    Modeller = new InputAlternateModeller(collection, ObjBase);
  }

  protected override IModeller<IGqlpInputAlternate, InputAlternateModel> Modeller { get; }

  [Theory, RepeatData]
  public void AlternateModel_WithValidAlternate_ReturnsExpectedInputAlternateModel(string name, string contents)
  {
    // Arrange
    IGqlpInputAlternate ast = A.Named<IGqlpInputAlternate>(name, contents);
    InputBaseModel inputType = new(name, contents);
    ObjBase.ToModel(ast, TypeKinds).Returns(inputType);

    // Act
    InputAlternateModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .BaseType.ShouldBe(inputType);
  }
}

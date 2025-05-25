using NSubstitute;

namespace GqlPlus.Modelling.Objects;

public class DualAlternateModellerTests
  : ModellerObjectBaseTestBase<IGqlpDualAlternate, DualAlternateModel, IGqlpDualBase, DualBaseModel>
{
  public DualAlternateModellerTests()
  {
    IModeller<IGqlpModifier, CollectionModel> collection = MFor<IGqlpModifier, CollectionModel>();

    Modeller = new DualAlternateModeller(collection, ObjBase);
  }

  protected override IModeller<IGqlpDualAlternate, DualAlternateModel> Modeller { get; }

  [Theory, RepeatData]
  public void AlternateModel_WithValidAlternate_ReturnsExpectedDualAlternateModel(string name, string contents)
  {
    // Arrange
    IGqlpDualAlternate ast = For<IGqlpDualAlternate>();
    ast.Dual.Returns(name);
    ast.Description.Returns(contents);
    DualBaseModel dualType = new(name, contents);
    ObjBase.ToModel(ast, TypeKinds).Returns(dualType);

    // Act
    DualAlternateModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .BaseType.ShouldBe(dualType);
  }
}

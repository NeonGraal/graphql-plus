using GqlPlus.Building;
using GqlPlus.Building.Schema;

namespace GqlPlus.Modelling.Objects;

public class AlternateModellerTests
  : ModellerObjectBaseTestBase<IGqlpAlternate, AlternateModel, ObjBaseModel>
{
  private readonly IModeller<IGqlpModifier, CollectionModel> _collection = MFor<IGqlpModifier, CollectionModel>();

  public AlternateModellerTests()
    => Modeller = new AlternateModeller(_collection, ObjBase);

  protected override IModeller<IGqlpAlternate, AlternateModel> Modeller { get; }

  [Theory, RepeatData]
  public void AlternateModel_WithValidAlternate_ReturnsExpectedAlternateModel(string name, string contents)
  {
    // Arrange
    IGqlpAlternate ast = A.Alternate(name)
      .WithDescr(contents)
      .WithModifier(ModifierKind.List)
      .AsAlternate;

    ObjBaseModel dualType = new(name, contents);
    ToModelReturns(ObjBase, dualType);
    CollectionModel[] collections = [new(ModifierKind.List)];
    ToModelsReturns(_collection, collections);

    // Act
    AlternateModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
      r => r.Type.ShouldBe(dualType),
      r => r.Collections.ShouldBeEquivalentTo(collections));
  }
}

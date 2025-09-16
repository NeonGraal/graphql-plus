namespace GqlPlus.Modelling.Objects;

public class DualAlternateModellerTests
  : ModellerObjectBaseTestBase<IGqlpDualAlternate, ObjAlternateModel, IGqlpDualBase, DualBaseModel>
{
  private readonly IModeller<IGqlpModifier, CollectionModel> _collection = MFor<IGqlpModifier, CollectionModel>();

  public DualAlternateModellerTests()
    => Modeller = new DualAlternateModeller(_collection, ObjBase);

  protected override IModeller<IGqlpDualAlternate, ObjAlternateModel> Modeller { get; }

  [Theory, RepeatData]
  public void AlternateModel_WithValidAlternate_ReturnsExpectedDualAlternateModel(string name, string contents)
  {
    // Arrange
    IGqlpDualAlternate ast = A.Named<IGqlpDualAlternate>(name, contents);
    IGqlpModifier modifier = A.Modifier(ModifierKind.List);
    ast.Modifiers.Returns([modifier]);

    DualBaseModel dualType = new(name, contents);
    ToModelReturns(ObjBase, dualType);
    CollectionModel[] collections = [new(ModifierKind.List)];
    ToModelsReturns(_collection, collections);

    // Act
    ObjAlternateModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
      r => r.Type.ShouldBe(dualType),
      r => r.Collections.ShouldBeEquivalentTo(collections));
  }
}

namespace GqlPlus.Modelling.Objects;

public class ObjAlternateModellerTests
  : ModellerObjectBaseTestBase<IGqlpObjAlternate, ObjAlternateModel, IGqlpObjBase, ObjBaseModel>
{
  private readonly IModeller<IGqlpModifier, CollectionModel> _collection = MFor<IGqlpModifier, CollectionModel>();

  public ObjAlternateModellerTests()
    => Modeller = new ObjAlternateModeller<IGqlpObjBase, IGqlpObjAlternate>(_collection, ObjBase);

  protected override IModeller<IGqlpObjAlternate, ObjAlternateModel> Modeller { get; }

  [Theory, RepeatData]
  public void AlternateModel_WithValidAlternate_ReturnsExpectedObjAlternateModel(string name, string contents)
  {
    // Arrange
    IGqlpObjAlternate ast = A.Named<IGqlpObjAlternate>(name, contents);
    IGqlpModifier modifier = A.Modifier(ModifierKind.List);
    ast.Modifiers.Returns([modifier]);

    ObjBaseModel dualType = new(name, contents);
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

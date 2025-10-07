namespace GqlPlus.Modelling.Objects;

public class ObjAlternateModellerTests
  : ModellerObjectBaseTestBase<IGqlpObjAlt, ObjAlternateModel, ObjBaseModel>
{
  private readonly IModeller<IGqlpModifier, CollectionModel> _collection = MFor<IGqlpModifier, CollectionModel>();

  public ObjAlternateModellerTests()
    => Modeller = new ObjAlternateModeller(_collection, ObjBase);

  protected override IModeller<IGqlpObjAlt, ObjAlternateModel> Modeller { get; }

  [Theory, RepeatData]
  public void AlternateModel_WithValidAlternate_ReturnsExpectedObjAlternateModel(string name, string contents)
  {
    // Arrange
    IGqlpObjAlt ast = A.Named<IGqlpObjAlt>(name, contents);
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

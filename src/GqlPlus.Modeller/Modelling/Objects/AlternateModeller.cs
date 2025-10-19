namespace GqlPlus.Modelling.Objects;

internal class AlternateModeller(
  IModeller<IGqlpModifier, CollectionModel> collection,
  IModeller<IGqlpObjBase, ObjBaseModel> objBase
) : ModellerBase<IGqlpAlternate, AlternateModel>
{
  protected override AlternateModel ToModel(IGqlpAlternate ast, IMap<TypeKindModel> typeKinds)
  {
    CollectionModel[] collections = collection.ToModels(ast.Modifiers, typeKinds);
    ObjBaseModel baseModel = objBase.ToModel(ast, typeKinds);
    AlternateModel result = new(baseModel) {
      Collections = collections
    };
    return result;
  }
}

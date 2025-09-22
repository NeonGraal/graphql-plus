namespace GqlPlus.Modelling.Objects;

internal class ObjAlternateModeller(
  IModeller<IGqlpModifier, CollectionModel> collection,
  IModeller<IGqlpObjBase, ObjBaseModel> objBase
) : ModellerBase<IGqlpObjAlt, ObjAlternateModel>
{
  protected override ObjAlternateModel ToModel(IGqlpObjAlt ast, IMap<TypeKindModel> typeKinds)
  {
    CollectionModel[] collections = collection.ToModels(ast.Modifiers, typeKinds);
    ObjBaseModel baseModel = objBase.ToModel(ast, typeKinds);
    ObjAlternateModel result = new(baseModel) {
      Collections = collections
    };
    return result;
  }
}

namespace GqlPlus.Modelling.Objects;

internal class ObjAlternateModeller<TObjBaseAst, TObjAltAst>(
  IModeller<IGqlpModifier, CollectionModel> collection,
  IModeller<TObjBaseAst, ObjBaseModel> objBase
) : ModellerBase<TObjAltAst, ObjAlternateModel>
  where TObjBaseAst : IGqlpObjBase
  where TObjAltAst : IGqlpObjAlternate, TObjBaseAst
{
  protected override ObjAlternateModel ToModel(TObjAltAst ast, IMap<TypeKindModel> typeKinds)
  {
    CollectionModel[] collections = collection.ToModels(ast.Modifiers, typeKinds);
    ObjBaseModel baseModel = objBase.ToModel(ast, typeKinds);
    ObjAlternateModel result = new(baseModel) {
      Collections = collections
    };
    return result;
  }
}

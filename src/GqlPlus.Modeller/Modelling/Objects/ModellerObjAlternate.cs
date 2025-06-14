namespace GqlPlus.Modelling.Objects;

internal abstract class ModellerObjAlternate<TObjBaseAst, TObjAltAst, TObjBase, TObjAlt>(
  IModeller<IGqlpModifier, CollectionModel> collection,
  IModeller<TObjBaseAst, TObjBase> objBase
) : ModellerBase<TObjAltAst, TObjAlt>
  where TObjBaseAst : IGqlpObjBase
  where TObjAltAst : IGqlpObjAlternate, TObjBaseAst
  where TObjBase : IObjBaseModel
  where TObjAlt : ObjAlternateModel<TObjBase>
{
  protected override TObjAlt ToModel(TObjAltAst ast, IMap<TypeKindModel> typeKinds)
  {
    CollectionModel[] collections = collection.ToModels(ast.Modifiers, typeKinds);
    return AlternateModel(objBase.ToModel(ast, typeKinds)) with {
      Collections = collections,
    };
  }

  protected abstract TObjAlt AlternateModel(TObjBase type);
}

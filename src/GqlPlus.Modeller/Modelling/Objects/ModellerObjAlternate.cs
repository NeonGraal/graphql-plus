namespace GqlPlus.Modelling.Objects;

internal abstract class ModellerObjAlternate<TObjBaseAst, TObjAltAst, TObjBase, TObjAlt>(
  IModeller<TObjBaseAst, TObjBase> objBase,
  IModeller<IGqlpModifier, CollectionModel> collection
) : ModellerBase<TObjAltAst, TObjAlt>
  where TObjBaseAst : IGqlpObjBase<TObjBaseAst>
  where TObjAltAst : IGqlpObjAlternate<TObjBaseAst>
  where TObjBase : IObjBaseModel
  where TObjAlt : ObjAlternateModel<TObjBase>
{
  protected override TObjAlt ToModel(TObjAltAst ast, IMap<TypeKindModel> typeKinds)
    => AlternateModel(ast, objBase.ToModel(ast.Type, typeKinds), typeKinds) with {
      Collections = collection.ToModels(ast.Modifiers, typeKinds),
    };

  protected abstract TObjAlt AlternateModel(TObjAltAst ast, TObjBase type, IMap<TypeKindModel> typeKinds);
}

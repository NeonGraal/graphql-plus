namespace GqlPlus.Modelling.Objects;

internal abstract class ModellerObjAlternate<TObjArgAst, TObjAltAst, TObjArg, TObjAlt>(
  IModeller<TObjArgAst, TObjArg> objArg,
  IModeller<IGqlpModifier, CollectionModel> collection
) : ModellerObjBase<TObjAltAst, TObjArgAst, TObjAlt, TObjArg>(objArg)
  where TObjArgAst : IGqlpObjArg
  where TObjAltAst : IGqlpObjAlternate, IGqlpObjBase<TObjArgAst>
  where TObjArg : IObjTypeArgModel
  where TObjAlt : ObjAlternateModel<TObjArg>
{
  protected override TObjAlt ToModel(TObjAltAst ast, IMap<TypeKindModel> typeKinds)
    => AlternateModel(ast, typeKinds) with {
      IsTypeParam = ast.IsTypeParam,
      Args = ModelArgs(ast, typeKinds),
      Collections = collection.ToModels(ast.Modifiers, typeKinds),
    };

  protected abstract TObjAlt AlternateModel(TObjAltAst ast, IMap<TypeKindModel> typeKinds);
}

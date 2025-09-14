namespace GqlPlus.Modelling.Objects;

internal abstract class ModellerObjBase<TObjBaseAst, TObjArgAst, TObjBase>(
    IModeller<TObjArgAst, ObjTypeArgModel> objArg
) : ModellerBase<TObjBaseAst, TObjBase>
  where TObjBaseAst : IGqlpObjBase<TObjArgAst>
  where TObjArgAst : IGqlpObjArg
  where TObjBase : IObjBaseModel
{
  internal ObjTypeArgModel[] ModelArgs(TObjBaseAst ast, IMap<TypeKindModel> typeKinds)
    => [.. ast.BaseArgs.Select(a => objArg.ToModel(a, typeKinds))];
}

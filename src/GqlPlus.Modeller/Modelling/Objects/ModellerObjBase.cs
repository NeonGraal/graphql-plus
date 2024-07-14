namespace GqlPlus.Modelling.Objects;

internal abstract class ModellerObjBase<TObjBaseAst, TObjArgAst, TObjBase, TObjArg>(
    IModeller<TObjArgAst, TObjArg> objArg
) : ModellerBase<TObjBaseAst, TObjBase>
  where TObjBaseAst : IGqlpObjBase<TObjArgAst>
  where TObjArgAst : IGqlpObjArg
  where TObjBase : IObjBaseModel
  where TObjArg : IModelBase
{
  internal TObjArg[] ModelArgs(TObjBaseAst ast, IMap<TypeKindModel> typeKinds)
    => [.. ast.BaseArgs.Select(a => objArg.ToModel(a, typeKinds))];
}

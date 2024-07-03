namespace GqlPlus.Modelling.Objects;

internal abstract class ModellerObjBase<TObjBaseAst, TObjArgAst, TObjBase, TObjArg>(
    IModeller<TObjArgAst, TObjArg> objArgument
) : ModellerBase<TObjBaseAst, TObjBase>
  where TObjBaseAst : IGqlpObjBase<TObjArgAst>
  where TObjArgAst : IGqlpObjArgument
  where TObjBase : IObjBaseModel
  where TObjArg : IModelBase
{
  internal TObjArg[] ModelArguments(TObjBaseAst ast, IMap<TypeKindModel> typeKinds)
    => [.. ast.BaseArguments.Select(a => objArgument.ToModel(a, typeKinds))];
}

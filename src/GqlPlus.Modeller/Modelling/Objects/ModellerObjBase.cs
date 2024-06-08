namespace GqlPlus.Modelling.Objects;

internal abstract class ModellerObjBase<TObjBaseAst, TObjBase>
  : ModellerObjBase<TObjBaseAst, TObjBase, TObjBase>
  where TObjBaseAst : IGqlpObjectBase<TObjBaseAst>
  where TObjBase : IObjBaseModel
{
  internal override TObjBase NewArgument(TObjBaseAst ast, IMap<TypeKindModel> typeKinds)
    => ToModel(ast, typeKinds);
}

internal abstract class ModellerObjBase<TObjBaseAst, TObjBase, TArg>
  : ModellerBase<TObjBaseAst, TObjBase>
  where TObjBaseAst : IGqlpObjectBase<TObjBaseAst>
  where TObjBase : IObjBaseModel
  where TArg : IRendering
{
  internal TArg[] ModelArguments(TObjBaseAst ast, IMap<TypeKindModel> typeKinds)
    => [.. ast.TypeArguments.Select(a => NewArgument(a, typeKinds))];

  internal abstract TArg NewArgument(TObjBaseAst ast, IMap<TypeKindModel> typeKinds);
}

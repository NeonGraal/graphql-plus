namespace GqlPlus.Modelling.Objects;

internal class ObjBaseModeller<TObjBaseAst>(
    IModeller<IGqlpObjArg, ObjTypeArgModel> objArg
) : ModellerBase<TObjBaseAst, ObjBaseModel>
  where TObjBaseAst : IGqlpObjBase
{
  internal ObjTypeArgModel[] ModelArgs(TObjBaseAst ast, IMap<TypeKindModel> typeKinds)
    => [.. ast.Args.Select(a => objArg.ToModel(a, typeKinds))];

  protected override ObjBaseModel ToModel(TObjBaseAst ast, IMap<TypeKindModel> typeKinds)
  => new(ast.Name, ast.Description) {
    IsTypeParam = ast.IsTypeParam,
    Args = ModelArgs(ast, typeKinds),
  };
}

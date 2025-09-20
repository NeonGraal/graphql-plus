namespace GqlPlus.Modelling.Objects;

internal class ObjBaseModeller(
    IModeller<IGqlpObjArg, ObjTypeArgModel> objArg
) : ModellerBase<IGqlpObjBase, ObjBaseModel>
{
  internal ObjTypeArgModel[] ModelArgs(IGqlpObjBase ast, IMap<TypeKindModel> typeKinds)
    => [.. ast.Args.Select(a => objArg.ToModel(a, typeKinds))];

  protected override ObjBaseModel ToModel(IGqlpObjBase ast, IMap<TypeKindModel> typeKinds)
  => new(ast.Name, ast.Description) {
    IsTypeParam = ast.IsTypeParam,
    Args = ModelArgs(ast, typeKinds),
  };
}

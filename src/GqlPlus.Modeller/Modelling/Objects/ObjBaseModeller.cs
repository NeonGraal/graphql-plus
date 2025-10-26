namespace GqlPlus.Modelling.Objects;

internal class ObjBaseModeller(
    IModeller<IGqlpTypeArg, TypeArgModel> objArg
) : ModellerBase<IGqlpObjBase, ObjBaseModel>
{
  internal TypeArgModel[] ModelArgs(IGqlpObjBase ast, IMap<TypeKindModel> typeKinds)
    => [.. ast.Args.Select(a => objArg.ToModel(a, typeKinds))];

  protected override ObjBaseModel ToModel(IGqlpObjBase ast, IMap<TypeKindModel> typeKinds)
  => new(ast.Name, ast.Description) {
    IsTypeParam = ast.IsTypeParam,
    Args = ModelArgs(ast, typeKinds),
  };
}

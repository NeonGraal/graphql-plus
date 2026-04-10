namespace GqlPlus.Modelling.Objects;

internal class ObjBaseModeller(
    IModeller<IAstTypeArg, TypeArgModel> objArg
) : ModellerBase<IAstObjBase, ObjBaseModel>
{
  internal TypeArgModel[] ModelArgs(IAstObjBase ast, IMap<TypeKindModel> typeKinds)
    => [.. ast.Args.Select(a => objArg.ToModel(a, typeKinds))];

  protected override ObjBaseModel ToModel(IAstObjBase ast, IMap<TypeKindModel> typeKinds)
  => new(ast.Name, ast.Description) {
    IsTypeParam = ast.IsTypeParam,
    Args = ModelArgs(ast, typeKinds),
  };
}

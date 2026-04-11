namespace GqlPlus.Modelling.Objects;

internal class ObjBaseModeller(
  IModellerRepository modellers
) : ModellerBase<IAstObjBase, ObjBaseModel>
{
  private readonly IModeller<IAstTypeArg, TypeArgModel> _objArg = modellers.ModellerFor<IAstTypeArg, TypeArgModel>();

  internal TypeArgModel[] ModelArgs(IAstObjBase ast, IMap<TypeKindModel> typeKinds)
    => [.. ast.Args.Select(a => _objArg.ToModel(a, typeKinds))];

  protected override ObjBaseModel ToModel(IAstObjBase ast, IMap<TypeKindModel> typeKinds)
  => new(ast.Name, ast.Description) {
    IsTypeParam = ast.IsTypeParam,
    Args = ModelArgs(ast, typeKinds),
  };
}

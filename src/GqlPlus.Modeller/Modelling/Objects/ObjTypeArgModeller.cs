namespace GqlPlus.Modelling.Objects;

internal class ObjTypeArgModeller
  : ModellerBase<IGqlpObjTypeArg, ObjTypeArgModel>
{
  protected override ObjTypeArgModel ToModel(IGqlpObjTypeArg ast, IMap<TypeKindModel> typeKinds)
    => string.IsNullOrWhiteSpace(ast.EnumLabel)
    ? typeKinds.TryGetValue(ast.Name, out TypeKindModel typeKind)
      ? new(typeKind, ast.Name, ast.Description) {
        IsTypeParam = ast.IsTypeParam,
      }
      : new(typeKind, ast.Name, ast.Description) {
        IsTypeParam = ast.IsTypeParam,
      }
    : new(TypeKindModel.Enum, ast.Name, ast.Description) { EnumLabel = ast.EnumLabel };

}

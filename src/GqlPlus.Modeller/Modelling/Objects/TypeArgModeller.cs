namespace GqlPlus.Modelling.Objects;

internal class TypeArgModeller(
  IModellerRepository modellers
) : ModellerBase<IAstTypeArg, TypeArgModel>
{
  private readonly IModeller<IAstEnumValue, EnumValueModel> _enumValue = modellers.ModellerFor<IAstEnumValue, EnumValueModel>();

  protected override TypeArgModel ToModel(IAstTypeArg ast, IMap<TypeKindModel> typeKinds)
  {
    if (ast.EnumValue is null) {
      typeKinds.TryGetValue(ast.Name, out TypeKindModel typeKind);
      return new(typeKind, ast.Name, ast.Description) {
        IsTypeParam = ast.IsTypeParam,
      };
    }

    typeKinds.TryGetValue(ast.EnumValue.EnumType, out TypeKindModel enumKind);
    return new(enumKind, ast.EnumValue.EnumType, ast.Description) {
      EnumValue = _enumValue.ToModel(ast.EnumValue, typeKinds),
    };
  }
}

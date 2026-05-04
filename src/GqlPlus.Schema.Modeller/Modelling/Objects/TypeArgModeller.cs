namespace GqlPlus.Modelling.Objects;

internal class TypeArgModeller(
  IModellerRepository modellers
) : ModellerBase<IAstTypeArg, TypeArgModel>
{
  private readonly IModeller<IAstEnumValue, EnumValueModel> _enumValue = modellers.ModellerFor<IAstEnumValue, EnumValueModel>();

  protected override TypeArgModel ToModel(IAstTypeArg ast, IMap<TypeKindModel> typeKinds)
  {
    if (ast.EnumValue is null) {
      TypeKindModel typeKind = typeKinds.GetValueOr(ast.Name);
      return new(typeKind, ast.Name, ast.Description) {
        IsTypeParam = ast.IsTypeParam,
      };
    }

    TypeKindModel enumKind = typeKinds.GetValueOr(ast.EnumValue.EnumType);
    return new(enumKind, ast.EnumValue.EnumType, ast.Description) {
      EnumValue = _enumValue.ToModel(ast.EnumValue, typeKinds),
    };
  }

  internal static TypeArgModeller Factory(IModellerRepository r) => new(r);
}

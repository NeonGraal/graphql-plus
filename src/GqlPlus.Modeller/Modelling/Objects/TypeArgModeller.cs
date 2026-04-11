using GqlPlus.Ast;
using GqlPlus.Ast.Schema;

namespace GqlPlus.Modelling.Objects;

internal class TypeArgModeller(
  IModeller<IAstEnumValue, EnumValueModel> enumValue
) : ModellerBase<IAstTypeArg, TypeArgModel>
{
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
      EnumValue = enumValue.ToModel(ast.EnumValue, typeKinds),
    };
  }
}

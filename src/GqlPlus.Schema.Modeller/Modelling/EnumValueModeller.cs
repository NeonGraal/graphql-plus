namespace GqlPlus.Modelling;

internal class EnumValueModeller
  : ModellerBase<IAstEnumValue, EnumValueModel>
{
  protected override EnumValueModel ToModel(IAstEnumValue ast, IMap<TypeKindModel> typeKinds)
    => new(ast.EnumType, ast.EnumLabel, "");

  internal static EnumValueModeller Factory(IModellerRepository _) => new();
}

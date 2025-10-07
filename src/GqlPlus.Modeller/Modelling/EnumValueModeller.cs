namespace GqlPlus.Modelling;

internal class EnumValueModeller
  : ModellerBase<IGqlpEnumValue, EnumValueModel>
{
  protected override EnumValueModel ToModel(IGqlpEnumValue ast, IMap<TypeKindModel> typeKinds)
    => new(ast.EnumType, ast.EnumLabel, "");
}

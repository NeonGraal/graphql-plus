namespace GqlPlus.Modelling.Globals;

internal class SettingModeller(
  IModeller<IGqlpConstant, ConstantModel> constant
) : ModellerBase<IGqlpSchemaSetting, SettingModel>
{
  protected override SettingModel ToModel(IGqlpSchemaSetting ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, constant.ToModel(ast.Value, typeKinds), ast.Description);
}

namespace GqlPlus.Modelling.Globals;

internal class SettingModeller(
  IModeller<IAstConstant, ConstantModel> constant
) : ModellerBase<IAstSchemaSetting, SettingModel>
{
  protected override SettingModel ToModel(IAstSchemaSetting ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, constant.ToModel(ast.Value, typeKinds), ast.Description);
}

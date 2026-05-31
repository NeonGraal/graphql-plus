namespace GqlPlus.Modelling;

internal class SettingModeller(
  IModellerRepository modellers
) : ModellerBase<IAstSchemaSetting, SettingModel>
{
  private readonly Modeller<IAstConstant, ConstantModel> _constant = modellers.ModellerFor<IAstConstant, ConstantModel>();

  protected override SettingModel ToModel(IAstSchemaSetting ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, _constant.ToModel(ast.Value, typeKinds), ast.Description);

  internal static SettingModeller Factory(IModellerRepository r) => new(r);
}

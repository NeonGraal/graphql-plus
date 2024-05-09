using GqlPlus.Abstractions.Schema;
using GqlPlus.Rendering;

namespace GqlPlus.Modelling;
public record class SettingModel(
  string Name,
  ConstantModel Value
) : DescribedModel(Name)
{
  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("value", Value.Render(context))
    ;
}

internal class SettingModeller(
  IModeller<IGqlpConstant, ConstantModel> constant
) : ModellerBase<IGqlpSchemaSetting, SettingModel>
{
  protected override SettingModel ToModel(IGqlpSchemaSetting ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, constant.ToModel(ast.Value, typeKinds)) {
      Description = ast.Description,
    };
}

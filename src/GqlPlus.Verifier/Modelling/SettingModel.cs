using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;
internal record class SettingModel(string Name)
  : ModelNamed(Name)
{
  // TODO: public ConstantModel Value { get; set; }

  protected override string Tag => "Setting";

  internal override RenderStructure Render()
    => base.Render()
      // .Add("value", Value.Render())
      ;
}

internal static class SettingHelper
{
  internal static SettingModel ToModel(this OptionSettingAst setting)
    => new(setting.Name) {
      Description = setting.Description,
    };
}

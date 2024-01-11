using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Model;
internal record class SettingModel(string Name)
  : ModelNamed(Name)
{
  // public ConstantModel Value { get; set; }

  protected override string Tag => "Setting";
}

internal static class SettingHelper
{
  internal static SettingModel ToModel(this OptionSettingAst setting)
    => new(setting.Name) {
      Description = setting.Description,
    };
}

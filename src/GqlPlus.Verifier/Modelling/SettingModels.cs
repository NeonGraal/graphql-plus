using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;
public record class SettingModel(string Name, ConstantModel Value)
  : DescribedModel<NamedModel>(new NamedModel(Name))
{
  internal override RenderStructure Render()
    => base.Render()
      .Add("value", Value.Render())
    ;
}

internal class SettingModeller(
  IModeller<ConstantAst, ConstantModel> constant
) : ModellerBase<OptionSettingAst, SettingModel>
{
  internal override SettingModel ToModel(OptionSettingAst ast)
    => new(ast.Name, constant.ToModel(ast.Value)) {
      Description = ast.Description,
    };
}

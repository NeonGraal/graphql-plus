using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;
public record class SettingModel(
  string Name,
  ConstantModel Value
) : DescribedModel<NamedModel>(new NamedModel(Name))
{
  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("value", Value.Render(context))
    ;
}

internal class SettingModeller(
  IModeller<ConstantAst, ConstantModel> constant
) : ModellerBase<OptionSettingAst, SettingModel>
{
  internal override SettingModel ToModel(OptionSettingAst ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, constant.ToModel(ast.Value, typeKinds)) {
      Description = ast.Description,
    };
}

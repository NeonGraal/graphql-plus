﻿using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;
internal record class SettingModel(string Name, ConstantModel Value)
  : ModelDescribed(new ModelNamed(Name))
{
  internal override RenderStructure Render()
    => base.Render()
      .Add("value", Value.Render())
    ;
}

internal class SettingModeller(
  IModeller<ConstantAst> constant
) : ModellerBase<OptionSettingAst, SettingModel>
{
  internal override SettingModel ToModel(OptionSettingAst ast)
    => new(ast.Name, constant.ToModel<ConstantModel>(ast.Value)!) {
      Description = ast.Description,
    };
}

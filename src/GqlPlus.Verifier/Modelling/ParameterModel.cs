﻿using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal record class ParameterModel
// Todo: (RefModel<InputBaseModel> Type)
  : IRendering
{
  public ModifierModel[] Collections { get; set; } = [];
  public ConstantModel? Default { get; set; }

  public RenderStructure Render()
    => new RenderStructure("_Parameter")
      // .Add("type", Type.Render())
      .Add("collections", new("", Collections.Render(), true))
      .Add("description", RenderValue.Str(""))
      .Add("default", Default?.Render())
      ;
}

internal class ParameterModeller(
  IModeller<ConstantAst> constant,
  IModeller<ModifierAst> modifier
) : ModellerBase<ParameterAst, ParameterModel>
{
  internal override ParameterModel ToModel(ParameterAst ast)
    => new() {
      // Type = parameter.Type.ToModel(),
      Collections = [.. ast.Modifiers.Select(modifier.ToModel<ModifierModel>)],
      Default = constant.ToModel<ConstantModel>(ast.Default),
    };
}

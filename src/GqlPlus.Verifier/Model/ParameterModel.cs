using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Model;

internal record class ParameterModel
// TODO: (RefModel<InputBaseModel> Type)
  : IRendering
{
  public ModifierModel[] Collections { get; set; } = [];
  // TODO: public ConstantModel? Default { get; set; }

  public RenderValue Render()
    => new RenderValue("_Parameter")
      // .Add("type", Type.Render())
      .Add("collections", new("", Collections.Render(), true))
      .Add("description", RenderValue.Str(""))
      // .Add("default", Default.Render())
      ;
}

internal static class ParameterHelper
{
  internal static ParameterModel ToModel(this ParameterAst parameter)
    => new() {
      // Type = parameter.Type.ToModel(),
      Collections = [.. parameter.Modifiers.Select(m => m.ToModel())]
      // Default = parameter.Default.ToModel(),
    };
}

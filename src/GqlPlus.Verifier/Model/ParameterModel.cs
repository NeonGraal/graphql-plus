using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Model;

internal record class ParameterModel
  : IRendering
{
  public string? Description { get; set; }

  public RenderValue Render()
    => new RenderValue("_Parameter")
      .Add("description", RenderValue.Str(Description));
}

internal static class ParameterHelper
{
  internal static ParameterModel ToModel(this ParameterAst parameter)
    => new() {
      Description = parameter.Description,
    };
}

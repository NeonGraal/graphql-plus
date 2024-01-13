using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Model;

internal class ConstantModel : Structured<SimpleModel, ConstantModel>, IRendering
{
  internal ConstantModel(SimpleModel value)
    : base(value) { }

  internal ConstantModel(IEnumerable<ConstantModel> values)
    : base(values) { }

  internal ConstantModel(Dictionary<SimpleModel, ConstantModel> values)
    : base(values) { }

  public RenderStructure Render()
    => Map.Count > 0 ? new RenderStructure("_ConstantMap", Map.ToDictionary(
        p => p.Key.Render().Value!,
        p => p.Value.Render()))
    : List.Count > 0 ? new RenderStructure("_ConstantList", List.Select(c => c.Render()))
    : Value is not null ? Value.Render()
    : new("");
}

internal static class ConstantHelper
{
  internal static ConstantModel ToModel(this ConstantAst constant)
    => constant.Fields.Count > 0 ? new(constant.Fields.ToModel())
    : constant.Values.Length > 0 ? new(constant.Values.Select(v => v.ToModel()))
    : constant.Value is not null ? new(constant.Value.ToModel())
    : new(new SimpleModel());

  internal static Dictionary<SimpleModel, ConstantModel> ToModel(this AstObject<ConstantAst> constant)
    => constant.ToDictionary(
      p => p.Key.ToModel(),
      p => p.Value.ToModel());
}

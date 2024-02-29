using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal class ConstantModel : Structured<SimpleModel, ConstantModel>, IRendering
{
  internal ConstantModel(SimpleModel value)
    : base(value) { }

  internal ConstantModel(IEnumerable<ConstantModel> values)
    : base(values) { }

  internal ConstantModel(Dictionary<SimpleModel, ConstantModel> values)
    : base(values) { }

  public RenderStructure Render()
    => Map.Count > 0 ? new RenderStructure(Map.ToDictionary(
        p => p.Key.Render().Value!,
        p => p.Value.Render()), "_ConstantMap")
    : List.Count > 0 ? new RenderStructure(List.Select(c => c.Render()), "_ConstantList")
    : Value is not null ? Value.Render()
    : new("");
}

internal class ConstantModeller(IModeller<FieldKeyAst> value)
  : ModellerBase<ConstantAst, ConstantModel>
{
  internal override ConstantModel ToModel(ConstantAst ast)
    => ast.Fields.Count > 0 ? new(ToModel(ast.Fields))
    : ast.Values.Length > 0 ? new(ast.Values.Select(ToModel))
    : ast.Value is not null ? new(value.ToModel<SimpleModel>(ast.Value))
    : new(new SimpleModel());

  private Dictionary<SimpleModel, ConstantModel> ToModel(AstObject<ConstantAst> constant)
    => constant.ToDictionary(
      p => value.ToModel<SimpleModel>(p.Key),
      p => ToModel(p.Value));
}

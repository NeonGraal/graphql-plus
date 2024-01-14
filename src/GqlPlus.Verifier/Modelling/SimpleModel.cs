using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal record class SimpleModel
  : IRendering
{
  internal bool? Boolean { get; }
  internal decimal? Number { get; }
  internal string? String { get; }
  internal string? EnumType { get; }
  internal string? Value { get; }

  internal string EnumValue => $"{EnumType}.{Value}";

  internal SimpleModel(bool value)
    => Boolean = value;
  internal SimpleModel(decimal value)
    => Number = value;
  internal SimpleModel(string value)
    => String = value;
  internal SimpleModel(string type, string value)
    => (EnumType, Value) = (type, value);
  internal SimpleModel() { }

  public RenderStructure Render()
    => Boolean is not null ? new("", Boolean)
      : Number is not null ? new("", Number)
      : String is not null ? new("", String)
      : EnumType is not null ? new(EnumType, Value)
      : new("Basic", "null");
}

internal class SimpleModeller
  : ModellerBase<FieldKeyAst, SimpleModel>, IModeller<FieldKeyAst>
{
  internal override SimpleModel ToModel(FieldKeyAst ast)
    => ast.Number.HasValue ? new(ast.Number.Value)
    : ast.String is not null ? new(ast.String)
    : "Boolean".Equals(ast.Type, StringComparison.OrdinalIgnoreCase) ? new("true".Equals(ast.Value, StringComparison.OrdinalIgnoreCase))
    : ast.Type is not null ? new(ast.Type, ast.Value ?? "")
    : new();
}

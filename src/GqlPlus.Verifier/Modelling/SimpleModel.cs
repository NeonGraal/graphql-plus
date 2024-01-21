using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal record class SimpleModel
  : IRendering
{
  internal bool? Boolean { get; private init; }
  internal TypeRefModel<SimpleKindModel>? TypeRef { get; private init; }
  internal decimal? Number { get; private init; }
  internal string? String { get; private init; }
  internal string? Value { get; private init; }

  internal string EnumValue => $"{TypeRef?.Name}.{Value}";

  internal static TypeRefModel<SimpleKindModel>? TypeFor(string? type)
    => string.IsNullOrWhiteSpace(type) ? null : new(SimpleKindModel.Scalar, type);

  internal static SimpleModel Bool(bool value)
    => new() { Boolean = value };
  internal static SimpleModel Num(string type, decimal value)
    => new() { TypeRef = TypeFor(type), Number = value };
  internal static SimpleModel Str(string type, string value)
    => new() { TypeRef = TypeFor(type), String = value };
  internal static SimpleModel Enum(string type, string value)
    => new() { TypeRef = TypeFor(type), Value = value };

  public RenderStructure Render()
    => Boolean is not null ? new("", Boolean)
      : Number is not null ? new(TypeRef?.Name ?? "", Number)
      : String is not null ? new(TypeRef?.Name ?? "", String)
      : Value is not null ? new(TypeRef?.Name ?? "", Value)
      : new("Basic", "null");
}

internal class SimpleModeller
  : ModellerBase<FieldKeyAst, SimpleModel>, IModeller<FieldKeyAst>
{
  internal override SimpleModel ToModel(FieldKeyAst ast)
    => ast.Number.HasValue ? SimpleModel.Num("", ast.Number.Value)
    : ast.String is not null ? SimpleModel.Str("", ast.String)
    : "Boolean".Equals(ast.Type, StringComparison.OrdinalIgnoreCase) ? SimpleModel.Bool("true".Equals(ast.Value, StringComparison.OrdinalIgnoreCase))
    : ast.Type is not null ? SimpleModel.Enum(ast.Type, ast.Value ?? "")
    : new();
}

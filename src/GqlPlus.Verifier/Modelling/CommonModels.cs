using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal class ConstantModel
  : Structured<SimpleModel, ConstantModel>, IRendering
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
    => Boolean is not null ? new(Boolean)
      : Number is not null ? new(Number, TypeRef?.Name ?? "")
      : String is not null ? new(String, TypeRef?.Name ?? "")
      : Value is not null ? new(Value, TypeRef?.Name ?? "")
      : new("null", "Basic");
}

internal record class CollectionModel(ModifierKind Kind)
  : ModelBase
{
  public string Key { get; set; } = "";
  public bool KeyOptional { get; set; }

  internal override RenderStructure Render()
    => base.Render()
        .Add("kind", $"{Kind}")
        .Add(Kind == ModifierKind.Dict, s => s
          .Add("key", Key)
          .Add("opt", KeyOptional, true)
        );
}

internal record class ModifierModel(ModifierKind Kind)
  : CollectionModel(Kind)
{ }

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

internal class SimpleModeller
  : ModellerBase<FieldKeyAst, SimpleModel>, IModeller<FieldKeyAst>
{
  internal override SimpleModel ToModel(FieldKeyAst ast)
    => ast.Number.HasValue ? SimpleModel.Num("", ast.Number.Value)
    : ast.Text is not null ? SimpleModel.Str("", ast.Text)
    : "Boolean".Equals(ast.Type, StringComparison.OrdinalIgnoreCase) ? SimpleModel.Bool("true".Equals(ast.Value, StringComparison.OrdinalIgnoreCase))
    : ast.Type is not null ? SimpleModel.Enum(ast.Type, ast.Value ?? "")
    : new();
}

internal class ModifierModeller
  : ModellerBase<ModifierAst, ModifierModel>
{
  internal override ModifierModel ToModel(ModifierAst ast)
    => new(ast.Kind) {
      Key = ast.Key ?? "",
      KeyOptional = ast.KeyOptional,
    };

  public override T? TryModel<T>(ModifierAst? ast)
    where T : default
  {
    if (typeof(T).Equals(typeof(CollectionModel))) {
      if (ast is not null && ast.Kind != ModifierKind.Optional) {
        return (T?)(object)ToModel(ast);
      }

      return default;
    } else {
      return base.TryModel<T>(ast);
    }
  }
}

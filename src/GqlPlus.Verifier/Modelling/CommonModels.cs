using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public class ConstantModel
  : Structured<SimpleModel, ConstantModel>, IRendering
{
  internal ConstantModel(SimpleModel value)
    : base(value) { }

  internal ConstantModel(IEnumerable<ConstantModel> values)
    : base(values) { }

  internal ConstantModel(Dictionary<SimpleModel, ConstantModel> values)
    : base(values) { }

  public RenderStructure Render(IRenderContext context)
    => Map.Count > 0 ? new RenderStructure(Map.ToDictionary(
        p => p.Key.Render(context).Value!,
        p => p.Value.Render(context)), "_ConstantMap")
    : List.Count > 0 ? List.Render(context, "_ConstantList")
    : Value is not null ? Value.Render(context)
    : new("");
}

public record class SimpleModel
  : IRendering
{
  internal bool? Boolean { get; private init; }
  internal TypeRefModel<SimpleKindModel>? TypeRef { get; private init; }
  internal decimal? Number { get; private init; }
  internal string? String { get; private init; }
  internal string? Value { get; private init; }

  internal string EnumValue => $"{TypeRef?.Name}.{Value}";

  internal static TypeRefModel<SimpleKindModel>? TypeFor(string? type)
    => string.IsNullOrWhiteSpace(type) ? null : new(SimpleKindModel.Domain, type);

  internal static SimpleModel Bool(bool value)
    => new() { Boolean = value };
  internal static SimpleModel Num(string type, decimal value)
    => new() { TypeRef = TypeFor(type), Number = value };
  internal static SimpleModel Str(string type, string value)
    => new() { TypeRef = TypeFor(type), String = value };
  internal static SimpleModel Enum(string type, string value)
    => new() { TypeRef = TypeFor(type), Value = value };

  public RenderStructure Render(IRenderContext context)
    => Boolean is not null ? new(Boolean)
      : Number is not null ? new(Number, TypeRef?.Name ?? "")
      : String is not null ? new(RenderValue.Str(String), TypeRef?.Name ?? "")
      : Value is not null ? new(Value, TypeRef?.Name ?? "")
      : new("null", "Basic");
}

public record class CollectionModel(
  ModifierKind Kind
) : ModelBase
{
  public string Key { get; set; } = "";
  public bool KeyOptional { get; set; }

  protected override string Tag => Kind == ModifierKind.Dict
    ? "_ModifierDictionary"
    : base.Tag;

  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
        .Add("kind", $"{Kind}")
        .Add(Kind == ModifierKind.Dict, s => s
          .Add("by", Key)
          .Add("optional", KeyOptional, true)
        );
}

public record class ModifierModel(ModifierKind Kind)
  : CollectionModel(Kind)
{ }

internal class ConstantModeller(
  IModeller<FieldKeyAst, SimpleModel> value
) : ModellerBase<ConstantAst, ConstantModel>
{
  protected override ConstantModel ToModel(ConstantAst ast, IMap<TypeKindModel> typeKinds)
    => ast.Fields.Count > 0 ? new(ToModel(ast.Fields, typeKinds))
    : ast.Values.Length > 0 ? new(ast.Values.Select(v => ToModel(v, typeKinds)))
    : ast.Value is not null ? new(value.ToModel(ast.Value, typeKinds))
    : new(new SimpleModel());

  private Dictionary<SimpleModel, ConstantModel> ToModel(AstObject<ConstantAst> constant, IMap<TypeKindModel> typeKinds)
    => constant.ToDictionary(
      p => value.ToModel(p.Key, typeKinds),
      p => ToModel(p.Value, typeKinds));
}

internal class SimpleModeller
  : ModellerBase<FieldKeyAst, SimpleModel>
{
  protected override SimpleModel ToModel(FieldKeyAst ast, IMap<TypeKindModel> typeKinds)
    => ast.Number.HasValue ? SimpleModel.Num("", ast.Number.Value)
    : ast.Text is not null ? SimpleModel.Str("", ast.Text)
    : "Boolean".Equals(ast.Type, StringComparison.OrdinalIgnoreCase) ? SimpleModel.Bool("true".Equals(ast.Value, StringComparison.OrdinalIgnoreCase))
    : ast.Type is not null ? SimpleModel.Enum(ast.Type, ast.Value ?? "")
    : new();
}

public interface IModifierModeller
  : IModeller<ModifierAst, ModifierModel>, IModeller<ModifierAst, CollectionModel>
{ }

internal class ModifierModeller
  : ModellerBase<ModifierAst, ModifierModel>, IModifierModeller
{
  protected override ModifierModel ToModel(ModifierAst ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Kind) {
      Key = ast.Key ?? "",
      KeyOptional = ast.KeyOptional,
    };

  protected override T? TryModel<T>(ModifierAst? ast, IMap<TypeKindModel> typeKinds)
    where T : default
  {
    if (typeof(T).Equals(typeof(CollectionModel))) {
      if (ast is not null && ast.Kind != ModifierKind.Optional) {
        return (T?)(object)ToModel(ast, typeKinds);
      }

      return default;
    } else {
      return base.TryModel<T>(ast, typeKinds);
    }
  }

  CollectionModel? IModeller<ModifierAst, CollectionModel>.TryModel(ModifierAst? ast, IMap<TypeKindModel> typeKinds)
    => TryModel<CollectionModel>(ast, typeKinds);
  CollectionModel IModeller<ModifierAst, CollectionModel>.ToModel(ModifierAst? ast, IMap<TypeKindModel> typeKinds)
    => ToModel<CollectionModel>(ast, typeKinds);
  IEnumerable<CollectionModel?> IModeller<ModifierAst, CollectionModel>.TryModels(IEnumerable<ModifierAst>? asts, IMap<TypeKindModel> typeKinds)
    => TryModels<CollectionModel>(asts, typeKinds);
  CollectionModel[] IModeller<ModifierAst, CollectionModel>.ToModels(IEnumerable<ModifierAst>? asts, IMap<TypeKindModel> typeKinds)
    => ToModels<CollectionModel>(asts, typeKinds);
}

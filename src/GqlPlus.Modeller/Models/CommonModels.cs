namespace GqlPlus.Models;

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
  ModifierKind ModifierKind
) : ModelBase
{
  // Todo: Make key a proper SimpleType
  public string? Key { get; set; } = "";
  public bool IsOptional { get; set; }

  internal override string Tag =>
    ModifierKind switch {
      ModifierKind.Dict => "_ModifierDictionary",
      ModifierKind.Param => "_ModifierTypeParameter",
      _ => base.Tag,
    };

  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
        .Add("modifierKind", ModifierKind)
        .Add(ModifierKind is ModifierKind.Dict or ModifierKind.Param,
          s => s
            .Add("by", Key
              ?? throw new InvalidOperationException($"{ModifierKind} Modifier must have a Key specified"))
            .Add("optional", IsOptional, true));
}

public record class ModifierModel(
  ModifierKind Kind
) : CollectionModel(Kind)
{ }

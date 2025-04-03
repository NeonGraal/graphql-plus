namespace GqlPlus.Models;

public class ConstantModel
  : Structured<SimpleModel, ConstantModel>
  , IModelBase
{
  public string Tag => "_Constant";

  internal ConstantModel(SimpleModel value)
    : base(value) { }

  internal ConstantModel(IEnumerable<ConstantModel> values)
    : base(values) { }

  internal ConstantModel(Dictionary<SimpleModel, ConstantModel> values)
    : base(values) { }
}

public record class SimpleModel
  : IModelBase
{
  public string Tag => "_Simple";

  internal bool? Boolean { get; private init; }
  internal TypeRefModel<SimpleKindModel>? TypeRef { get; private init; }
  internal decimal? Number { get; private init; }
  internal string? String { get; private init; }
  internal string? Value { get; private init; }

  internal string EnumValue => $"{TypeRef?.Name}.{Value}";

  internal static TypeRefModel<SimpleKindModel>? TypeFor(string? type)
    => string.IsNullOrWhiteSpace(type) ? null : new(SimpleKindModel.Domain, type!, "");

  internal static SimpleModel Bool(bool value)
    => new() { Boolean = value };
  internal static SimpleModel Num(string type, decimal value)
    => new() { TypeRef = TypeFor(type), Number = value };
  internal static SimpleModel Str(string type, string value)
    => new() { TypeRef = TypeFor(type), String = value };
  internal static SimpleModel Enum(string type, string value)
    => new() { TypeRef = TypeFor(type), Value = value };
}

public record class CollectionModel(
  ModifierKind ModifierKind
) : ModelBase
{
  // Todo: Make key a proper SimpleType
  public string? Key { get; set; } = "";
  public SimpleKindModel? KeyType { get; init; }
  public bool IsOptional { get; set; }

  internal override string Tag =>
    ModifierKind switch {
      ModifierKind.Dict => "_ModifierDictionary",
      ModifierKind.Param => "_ModifierTypeParam",
      _ => base.Tag,
    };
}

public record class ModifierModel(
  ModifierKind Kind
) : CollectionModel(Kind)
{ }

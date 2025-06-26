
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

public class SimpleModel
  : BaseValue
  , IModelBase
{
  public SimpleModel(bool? value)
    : base(value, "") { }

  public SimpleModel(string? value)
    : base(value, "") { }

  public SimpleModel(decimal? value)
    : base(value, "") { }

  public override string Tag => "_Simple";

  internal TypeRefModel<SimpleKindModel>? TypeRef { get; private init; }
  internal string? Value { get; private init; }

  internal string EnumValue => $"{TypeRef?.TypeName}.{Value}";

  internal static TypeRefModel<SimpleKindModel>? TypeFor(string? type)
    => string.IsNullOrWhiteSpace(type) ? null : new(SimpleKindModel.Domain, type!, "");

  internal static SimpleModel Bool(bool value)
    => new(value);
  internal static SimpleModel Num(string type, decimal value)
    => new(value) { TypeRef = TypeFor(type) };
  internal static SimpleModel Str(string type, string value)
    => new(value) { TypeRef = TypeFor(type) };
  internal static SimpleModel Enum(string type, string value)
    => new("") { TypeRef = TypeFor(type), Value = value };
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

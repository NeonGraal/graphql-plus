namespace GqlPlus.Models;

public class ConstantModel
  : ComplexValue<SimpleModel, ConstantModel>
  , IEquatable<ConstantModel>
  , IModelBase
{
  public override string Tag => "_Constant";

  public ConstantModel(SimpleModel value)
    : base(value) { }

  public ConstantModel(IEnumerable<ConstantModel> values)
    : base(values) { }

  public ConstantModel(Dictionary<SimpleModel, ConstantModel> values)
    : base(values) { }

  public bool Equals(ConstantModel? other)
    => Equals(other as ComplexValue<SimpleModel, ConstantModel>);
  public override bool Equals(object obj)
    => Equals(obj as ConstantModel);
  public override int GetHashCode()
    => base.GetHashCode();
}

public class SimpleModel
  : ScalarValue
  , IEquatable<SimpleModel>
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
  public string? TypeName => string.IsNullOrWhiteSpace(TypeRef?.Name) ? EnumValue?.Name : TypeRef?.Name;

  public EnumValueModel? EnumValue { get; private init; }

  internal static TypeRefModel<SimpleKindModel>? DomainFor(string? type, DomainKindModel kind)
    => string.IsNullOrWhiteSpace(type) ? null : new DomainRefModel(type!, kind, "");

  internal static SimpleModel Bool(bool value)
    => new(value);
  internal static SimpleModel Num(decimal value)
    => new(value);
  internal static SimpleModel Str(string value)
    => new(value);
  internal static SimpleModel Enum(EnumValueModel value)
    => new("") { EnumValue = value };

  internal static SimpleModel BoolDom(string domain, bool value)
    => new(value) { TypeRef = DomainFor(domain, DomainKindModel.Boolean) };
  internal static SimpleModel NumDom(string domain, decimal value)
    => new(value) { TypeRef = DomainFor(domain, DomainKindModel.Number) };
  internal static SimpleModel StrDom(string domain, string value)
    => new(value) { TypeRef = DomainFor(domain, DomainKindModel.String) };
  internal static SimpleModel EnumDom(string domain, string type, string value)
    => new("") { TypeRef = DomainFor(domain, DomainKindModel.Enum), EnumValue = new(type, value, "") };

  public override bool Equals(object obj)
    => Equals(obj as SimpleModel);
  public bool Equals(SimpleModel? other)
    => TypeRef.NullEqual(other?.TypeRef) &&
      (Equals(other as ScalarValue)
        || EnumValue is not null && EnumValue.Equals(other?.EnumValue));
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(),
      TypeRef.NullHashCode(),
      EnumValue.NullHashCode());
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

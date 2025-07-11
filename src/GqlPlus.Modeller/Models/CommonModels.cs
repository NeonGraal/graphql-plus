using GqlPlus.Ast;

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
  public string? TypeName => TypeRef?.Name;

  public string? Value { get; private init; }
  internal string EnumValue => $"{TypeRef?.Name}.{Value}";

  internal static TypeRefModel<SimpleKindModel>? TypeFor(string? type)
    => string.IsNullOrWhiteSpace(type) ? null : new(SimpleKindModel.Domain, type!, "");

  internal static SimpleModel Bool(string type, bool value)
    => new(value) { TypeRef = TypeFor(type) };
  internal static SimpleModel Num(string type, decimal value)
    => new(value) { TypeRef = TypeFor(type) };
  internal static SimpleModel Str(string type, string value)
    => new(value) { TypeRef = TypeFor(type) };
  internal static SimpleModel Enum(string type, string value)
    => new("") { TypeRef = TypeFor(type), Value = value };

  public override bool Equals(object obj)
    => Equals(obj as SimpleModel);
  public bool Equals(SimpleModel? other)
    => TypeRef.NullEqual(other?.TypeRef) &&
      (Equals(other as ScalarValue)
        || !string.IsNullOrWhiteSpace(Value)
         && Value.NullEqual(other?.Value));
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(),
      TypeRef?.GetHashCode() ?? 0,
      Value?.GetHashCode() ?? 0);
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

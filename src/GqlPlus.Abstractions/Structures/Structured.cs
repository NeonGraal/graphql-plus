using GqlPlus.Abstractions;

namespace GqlPlus.Structures;

public class Structured
  : ComplexValue<StructureValue, Structured>
  , IEquatable<Structured>
{
  public bool IsEmpty
    => List.Count == 0
    && Map.Count == 0
    && (Value?.IsEmpty ?? true);

  public bool Flow { get; }

  public static Structured Empty(string? tag = null) => new(default(string), tag);

  public Structured(bool? value, string? tag = null)
    : base(new StructureValue(value, tag)) => Tag = tag.IfWhiteSpace();
  public Structured(string? value, string? tag = null)
    : base(new StructureValue(value, tag)) => Tag = tag.IfWhiteSpace();
  public Structured(decimal? value, string? tag = null)
    : base(new StructureValue(value, tag)) => Tag = tag.IfWhiteSpace();
  public Structured(StructureValue? value)
    : base(value) => Tag = (value?.Tag).IfWhiteSpace();
  public Structured(IEnumerable<Structured> list, string? tag = null, bool flow = false)
    : base(list) => (Tag, Flow) = (tag.IfWhiteSpace(), flow);
  public Structured(IDictionary<StructureValue, Structured> map, string? tag = null, bool flow = false)
    : base(map) => (Tag, Flow) = (tag.IfWhiteSpace(), flow);

  public static implicit operator Structured(StructureValue value)
    => new(value);
  public static implicit operator Structured(bool value)
    => new(value);
  public static implicit operator Structured(string value)
    => new(value);
  public static implicit operator Structured(decimal value)
    => new(value);

  public Structured Add(string key, Structured? value)
  {
    if (value is null || value.IsEmpty) {
      return this;
    }

    Map.Add(new(key), value);
    return this;
  }

  public Structured AddBool(string key, bool value)
    => value ? Add(key, value) : this;

  public Structured IncludeEncoded<TValue>(TValue? value, IEncoder<TValue> encoder)
  {
    if (value is null) {
      return this;
    }

    encoder.ThrowIfNull();

    foreach (KeyValuePair<StructureValue, Structured> item in encoder.Encode(value).Map) {
      Map.Add(item.Key, item.Value);
    }

    return this;
  }

  public Structured AddEnum<TValue>(string key, TValue value, string? tag = null)
    where TValue : Enum
    => Add(key, new(value.ToString(), tag.IfWhiteSpace(typeof(TValue).TypeTag())));

  public Structured AddEncoded<TValue>(string key, TValue? value, IEncoder<TValue> encoder)
    => value is null ? this
    : Add(key, encoder.ThrowIfNull().Encode(value));

  public Structured AddList<TValue>(string key, IEnumerable<TValue> values, IEncoder<TValue> encoder, string? tag = null, bool flow = false)
    => Add(key, new(values.Select(encoder.ThrowIfNull().Encode), tag, flow));

  public Structured AddMap<TValue>(string key, IMap<TValue> values, IEncoder<TValue> encoder, string dictTag, bool flow = false, string keyTag = "_Identifier")
    => Add(key, new(values.ToDictionary(
        p => new StructureValue(p.Key, keyTag),
        p => encoder.Encode(p.Value)), "_Map" + dictTag, flow));

  public Structured AddIf(bool optional, Func<Structured, Structured>? onTrue = null, Func<Structured, Structured>? onFalse = null)
    => optional
      ? onTrue is not null ? onTrue(this) : this
      : onFalse is not null ? onFalse(this) : this;

  public Structured AddSet<TEnum>(string key, TEnum set, string? tag = null, bool flow = true)
    where TEnum : Enum
  {
    string[]? flags = set.FlagNames();

    if (flags is not null) {
      Dict result = [];

      foreach (string flag in flags) {
        result.Add(new(flag), new("_"));
      }

      return Add(key, new(result, $"_Set({tag.IfWhiteSpace(typeof(TEnum).TypeTag())})", flow: flow));
    }

    return this;
  }

  public override bool Equals(object? obj) => obj is Structured structured && base.Equals(obj);
  public override int GetHashCode() => HashCode.Combine(base.GetHashCode());
  public bool Equals(Structured? other) => Equals(other as ComplexValue<StructureValue, Structured>);
}

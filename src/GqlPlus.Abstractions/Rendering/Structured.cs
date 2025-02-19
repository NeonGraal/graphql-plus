using System.Reflection;

namespace GqlPlus.Rendering;

public class Structured
  : Structured<StructureValue, Structured>
{
  public bool IsEmpty
    => List.Count == 0
    && Map.Count == 0
    && (Value?.IsEmpty ?? true);

  public bool Flow { get; }
  public string Tag { get; } = string.Empty;

  public static Structured New(string tag, bool flow = false)
    => new(tag, flow);
  public static Structured ForAll(IEnumerable<string> values, string tag = "", bool flow = false)
    => new(values.Select(v => new Structured(v)), tag, flow);

  private Structured(string tag, bool flow)
    : base() => (Tag, Flow) = (tag, flow);
  public Structured(bool? value, string tag = "")
    : base(new StructureValue(value)) => Tag = tag;
  public Structured(string? value, string tag = "")
    : base(new StructureValue(value)) => Tag = tag;
  public Structured(decimal? value, string tag = "")
    : base(new StructureValue(value)) => Tag = tag;
  public Structured(StructureValue value, string tag = "")
    : base(value) => Tag = tag;
  public Structured(IEnumerable<Structured> list, string tag = "", bool flow = false)
    : base(list) => (Tag, Flow) = (tag, flow);
  public Structured(IDictionary<StructureValue, Structured> map, string tag, bool flow = false)
    : base(map) => (Tag, Flow) = (tag, flow);

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

  public Structured AddBool(string key, bool value, bool blankIfDefault)
    => value || !blankIfDefault
    ? Add(key, value)
    : this;

  public Structured IncludeRendered<TValue>(TValue? value, IRenderer<TValue> renderer)
  {
    if (value is null) {
      return this;
    }

    ArgumentNullException.ThrowIfNull(renderer);

    foreach ((StructureValue key, Structured item) in renderer.Render(value).Map) {
      Map.Add(key, item);
    }

    return this;
  }

  public Structured AddEnum<TValue>(string key, TValue value, string? tag = null)
    where TValue : Enum
    => Add(key, new(value.ToString(), tag ?? typeof(TValue).TypeTag()));

  public Structured AddRendered<TValue>(string key, TValue? value, IRenderer<TValue> renderer)
    => value is null ? this
    : Add(key, renderer.ThrowIfNull().Render(value));

  public Structured AddList<TValue>(string key, IEnumerable<TValue> values, IRenderer<TValue> renderer, string tag = "", bool flow = false)
    => Add(key, new(values.Select(renderer.ThrowIfNull().Render), tag, flow));

  public Structured AddMap<TValue>(string key, IMap<TValue> values, IRenderer<TValue> renderer, string dictTag, bool flow = false, string keyTag = "_Identifier")
    => Add(key, new(values.ToDictionary(
        p => new StructureValue(p.Key, keyTag),
        p => renderer.Render(p.Value)), "_Map" + dictTag, flow));

  public Structured AddIf(bool optional, Func<Structured, Structured>? onTrue = null, Func<Structured, Structured>? onFalse = null)
    => optional
      ? (onTrue is not null ? onTrue(this) : this)
      : (onFalse is not null ? onFalse(this) : this);

  public Structured AddSet<TEnum>(string key, TEnum set, string? tag = null, bool flow = true)
    where TEnum : Enum
  {
    Type type = typeof(TEnum);

    if (type.GetCustomAttributes<FlagsAttribute>().Any()) {
      int flags = (int)(object)set;
      IDict result = NewDict;

      foreach (object? value in Enum.GetValues(type)) {
        int flag = (int)value;
        if (int.PopCount(flag) == 1 && (flags & flag) == flag) {
          result.Add(new(Enum.GetName(type, value)), new("_"));
        }
      }

      return Add(key, new(result, $"_Set({tag ?? type.TypeTag()})", flow: flow));
    }

    return this;
  }
}

#pragma warning disable CA1034 // Nested types should not be visible
public class Structured<TValue, TObject>
  where TValue : notnull
  where TObject : Structured<TValue, TObject>
{
  internal sealed class Dict
    : Dictionary<TValue, TObject>, IDict
  {
    internal Dict() : base() { }
    internal Dict(IDictionary<TValue, TObject> dictionary)
      : base(dictionary) { }
  }

  public interface IDict
    : IDictionary<TValue, TObject>
  { }

  public IDict NewDict => new Dict();

  public TValue? Value { get; }
  public IList<TObject> List { get; } = [];
  public IDict Map { get; } = new Dict();

  public Structured() { }
  public Structured(TValue value)
    => Value = value;
  public Structured(IEnumerable<TObject> values)
    => List = [.. values];
  public Structured(IDictionary<TValue, TObject> values)
    => Map = new Dict(values);
}

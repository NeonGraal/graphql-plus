using System.Reflection;

namespace GqlPlus.Verifier.Rendering;

internal class RenderStructure
  : Structured<RenderValue, RenderStructure>
{
  public bool IsEmpty
    => List.Count == 0
    && Map.Count == 0
    && (Value?.IsEmpty ?? true);

  public bool Flow { get; }
  public string Tag { get; private init; } = string.Empty;

  public static RenderStructure New(string tag)
    => new() { Tag = tag };
  public static RenderStructure For<T>(T value, string? tag = null)
    where T : struct
  {
    Type type = typeof(T);
    return type.IsEnum ? new(value.ToString(), tag ?? type.TypeTag()) : new();
  }

  private RenderStructure()
    : base() { }
  public RenderStructure(bool? value, string tag = "")
    : base(new RenderValue(value)) => Tag = tag;
  public RenderStructure(string? value, string tag = "")
    : base(new RenderValue(value)) => Tag = tag;
  public RenderStructure(decimal? value, string tag = "")
    : base(new RenderValue(value)) => Tag = tag;
  public RenderStructure(RenderValue value, string tag = "")
    : base(value) => Tag = tag;
  public RenderStructure(IEnumerable<RenderStructure> list, bool flow = false)
    : base(list) => (Tag, Flow) = ("", flow);
  public RenderStructure(IEnumerable<RenderStructure> list, string tag)
    : base(list) => (Tag, Flow) = (tag, false);
  public RenderStructure(Dictionary<RenderValue, RenderStructure> map, string tag, bool flow = false)
    : base(map) => (Tag, Flow) = (tag, flow);

  public static implicit operator RenderStructure(RenderValue value)
    => new(value);
  public static implicit operator RenderStructure(bool value)
    => new(value);
  public static implicit operator RenderStructure(string value)
    => new(value);
  public static implicit operator RenderStructure(decimal value)
    => new(value);

  public RenderStructure Add(string key, RenderStructure? value)
  {
    if (value is null || value.IsEmpty) {
      return this;
    }

    Map.Add(new(key), value);
    return this;
  }

  public RenderStructure Add(string key, bool value, bool blankIfDefault)
    => value || !blankIfDefault
    ? Add(key, value)
    : this;

  public RenderStructure Add<T>(T value)
    where T : IRendering
  {
    foreach (var (key, item) in value.Render().Map) {
      Map.Add(key, item);
    }

    return this;
  }

  public RenderStructure Add<T>(string key, T value, string? tag = null)
    where T : Enum
    => Add(key, new(value.ToString(), tag ?? typeof(T).TypeTag()));

  public RenderStructure Add(bool optional, Func<RenderStructure, RenderStructure> add)
    => optional ? add(this) : this;

  public RenderStructure AddSet<TEnum>(string key, TEnum set, string? tag = null, bool flow = true)
    where TEnum : Enum
  {
    var type = typeof(TEnum);

    if (type.GetCustomAttributes(typeof(FlagsAttribute)).Any()) {
      var flags = (int)(object)set;
      var result = new Dict();

      foreach (var value in Enum.GetValues(type)) {
        var flag = (int)value;
        if (int.PopCount(flag) == 1 && (flags & flag) == flag) {
          result.Add(new(Enum.GetName(type, value)), new("_"));
        }
      }

      return Add(key, new(result, $"_Set({tag ?? type.TypeTag()})", flow));
    }

    return this;
  }

  public string ToYaml()
    => RenderYaml.Serializer.Serialize(this);
}

using System.Reflection;

namespace GqlPlus.Rendering;

public class RenderStructure
  : Structured<RenderValue, RenderStructure>
{
  public bool IsEmpty
    => List.Count == 0
    && Map.Count == 0
    && (Value?.IsEmpty ?? true);

  public bool Flow { get; }
  public string Tag { get; } = string.Empty;

  public static RenderStructure New(string tag, bool flow = false)
    => new(tag, flow);
  public static RenderStructure ForAll(IEnumerable<string> values, string tag = "")
    => new(values.Select(v => new RenderStructure(v)), tag);

  private RenderStructure(string tag, bool flow)
    : base() => (Tag, Flow) = (tag, flow);
  public RenderStructure(bool? value, string tag = "")
    : base(new RenderValue(value)) => Tag = tag;
  public RenderStructure(string? value, string tag = "")
    : base(new RenderValue(value)) => Tag = tag;
  public RenderStructure(decimal? value, string tag = "")
    : base(new RenderValue(value)) => Tag = tag;
  public RenderStructure(RenderValue value, string tag = "")
    : base(value) => Tag = tag;
  public RenderStructure(IEnumerable<RenderStructure> list, string tag = "", bool flow = false)
    : base(list) => (Tag, Flow) = (tag, flow);
  public RenderStructure(IDictionary<RenderValue, RenderStructure> map, string tag, bool flow = false)
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

  public RenderStructure Add<TValue>(TValue? value, IRenderer<TValue> renderer, IRenderContext context)
    where TValue : IModelBase
  {
    if (value is null) {
      return this;
    }

    ArgumentNullException.ThrowIfNull(renderer);

    foreach ((RenderValue key, RenderStructure item) in renderer.Render(value, context).Map) {
      Map.Add(key, item);
    }

    return this;
  }

  public RenderStructure Add<TValue>(string key, TValue value, string? tag = null)
    where TValue : Enum
    => Add(key, new(value.ToString(), tag ?? typeof(TValue).TypeTag()));

  public RenderStructure Add<TValue>(string key, TValue? value, IRenderer<TValue> renderer, IRenderContext context)
    where TValue : IModelBase
    => value is null ? this
    : Add(key, renderer.ThrowIfNull().Render(value, context));

  public RenderStructure Add(bool optional, Func<RenderStructure, RenderStructure>? onTrue = null, Func<RenderStructure, RenderStructure>? onFalse = null)
    => optional
      ? (onTrue is not null ? onTrue(this) : this)
      : (onFalse is not null ? onFalse(this) : this);

  public RenderStructure AddSet<TEnum>(string key, TEnum set, string? tag = null, bool flow = true)
    where TEnum : Enum
  {
    Type type = typeof(TEnum);

    if (type.GetCustomAttributes(typeof(FlagsAttribute)).Any()) {
      int flags = (int)(object)set;
      IDict result = NewDict;

      foreach (object? value in Enum.GetValues(type)) {
        int flag = (int)value;
        if (int.PopCount(flag) == 1 && (flags & flag) == flag) {
          result.Add(new(Enum.GetName(type, value)), new("_"));
        }
      }

      return Add(key, new(result, $"_Set({tag ?? type.TypeTag()})", flow));
    }

    return this;
  }
}

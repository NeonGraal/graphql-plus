namespace GqlPlus.Verifier.Rendering;

internal class RenderStructure : Structured<RenderValue, RenderStructure>
{
  public bool IsEmpty
    => List.Count == 0
    && Map.Count == 0
    && (Value?.IsEmpty ?? true);

  public bool Flow { get; }
  public string Tag { get; } = string.Empty;

  public RenderStructure(string tag)
    : base() => Tag = tag;
  public RenderStructure(string tag, bool? value)
    : base(new RenderValue(value)) => Tag = tag;
  public RenderStructure(string tag, string? value)
    : base(new RenderValue(value)) => Tag = tag;
  public RenderStructure(string tag, decimal? value)
    : base(new RenderValue(value)) => Tag = tag;
  public RenderStructure(string tag, RenderValue value)
    : base(value) => Tag = tag;
  public RenderStructure(string tag, IEnumerable<RenderStructure> list, bool flow = false)
    : base(list) => (Tag, Flow) = (tag, flow);
  public RenderStructure(string tag, Dictionary<RenderValue, RenderStructure> map, bool flow = false)
    : base(map) => (Tag, Flow) = (tag, flow);

  public static implicit operator RenderStructure(RenderValue value)
    => new("", value);

  public RenderStructure Add(string key, RenderStructure? value)
  {
    if (value is null || value.IsEmpty) {
      return this;
    }

    Map.Add(new(key), value);
    return this;
  }

  public RenderStructure Add<T>(T value)
    where T : IRendering
  {
    foreach (var (key, item) in value.Render().Map) {
      Map.Add(key, item);
    }

    return this;
  }

  public string ToYaml()
    => RenderYaml.Serializer.Serialize(this);
}

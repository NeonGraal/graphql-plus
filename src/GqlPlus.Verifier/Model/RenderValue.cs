namespace GqlPlus.Verifier.Model;

public record class RenderValue(string Tag)
{
  private readonly List<RenderValue> _list = [];
  private readonly Map<RenderValue> _map = [];

  public bool IsEmpty => _list.Count == 0 && _map.Count == 0 && Boolean is null && string.IsNullOrEmpty(Identifier) && string.IsNullOrEmpty(String) && Decimal is null;
  public bool? Boolean { get; set; }
  public string? Identifier { get; set; }
  public string? String { get; set; }
  public decimal? Decimal { get; set; }
  public IReadOnlyList<RenderValue> List => _list;
  public bool Flow { get; }
  public IReadOnlyMap<RenderValue> Map => _map;

  public RenderValue(string tag, bool? value)
    : this(tag) => Boolean = value;
  public RenderValue(string tag, string? value)
    : this(tag) => Identifier = value;
  public RenderValue(string tag, decimal? value)
    : this(tag) => Decimal = value;
  public RenderValue(string tag, IEnumerable<RenderValue> list, bool flow = false)
    : this(tag) => (_list, Flow) = (list.ToList(), flow);
  public RenderValue(string tag, IReadOnlyMap<RenderValue> map)
    : this(tag) => _map = new(map);

  public static RenderValue Str(string? value)
    => new RenderValue("") with { String = value };

  public RenderValue Add(RenderValue value)
  {
    if (value.IsEmpty) {
      return this;
    }

    _list.Add(value);
    return this;
  }

  public RenderValue Add(string key, RenderValue value)
  {
    if (value.IsEmpty) {
      return this;
    }

    _map.Add(key, value);
    return this;
  }

  public string ToYaml()
    => RenderYaml.Serializer.Serialize(this);
}

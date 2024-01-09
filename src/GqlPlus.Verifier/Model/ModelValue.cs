namespace GqlPlus.Verifier.Model;

public record class ModelValue(string Tag)
{
  private readonly List<ModelValue> _list = [];
  private readonly Map<ModelValue> _map = [];

  public bool IsEmpty => _list.Count == 0 && _map.Count == 0 && Boolean is null && string.IsNullOrEmpty(Identifier) && string.IsNullOrEmpty(String) && Decimal is null;
  public bool? Boolean { get; set; }
  public string? Identifier { get; set; }
  public string? String { get; set; }
  public decimal? Decimal { get; set; }
  public IReadOnlyList<ModelValue> List => _list;
  public bool Flow { get; }
  public IReadOnlyMap<ModelValue> Map => _map;

  public ModelValue(string tag, bool? value)
    : this(tag) => Boolean = value;
  public ModelValue(string tag, string? value)
    : this(tag) => Identifier = value;
  public ModelValue(string tag, decimal? value)
    : this(tag) => Decimal = value;
  public ModelValue(string tag, IEnumerable<ModelValue> list, bool flow = false)
    : this(tag) => (_list, Flow) = (list.ToList(), flow);
  public ModelValue(string tag, IReadOnlyMap<ModelValue> map)
    : this(tag) => _map = new(map);

  public static ModelValue Str(string value)
    => new ModelValue("") with { String = value };

  public ModelValue Add(ModelValue value)
  {
    if (value.IsEmpty) {
      return this;
    }

    _list.Add(value);
    return this;
  }

  public ModelValue Add(string key, ModelValue value)
  {
    if (value.IsEmpty) {
      return this;
    }

    _map.Add(key, value);
    return this;
  }
}


namespace GqlPlus;

public sealed class GqlpList(IEnumerable<IGqlpValue> items, string? tag = null, bool flow = false)
  : GqlpValue(tag)
{
  public IReadOnlyList<IGqlpValue> Items { get; } = [.. items];
  public bool Flow { get; } = flow;

  protected override bool ValueEquals(GqlpValue other)
    => other is GqlpList list && Items.SequenceEqual(list.Items);

  protected override int ValueHash()
    => Items.Aggregate(Items.Count, (h, i) => Combine(h, i.GetHashCode()));

  public override bool IsEmpty() => Items.Count == 0;

  public override string ToString()
    => Tag.Suffixed("!") + Items.Surround("[ ", " ]", i => $"{i}", ", ");
}

public sealed class GqlpMap(IEnumerable<KeyValuePair<IGqlpScalar, IGqlpValue>> entries, string? tag = null, bool flow = false)
  : GqlpValue(tag)
{
  public IReadOnlyDictionary<IGqlpScalar, IGqlpValue> Entries { get; }
    = entries.ToDictionary(e => e.Key, e => e.Value);
  public bool Flow { get; } = flow;

  protected override bool ValueEquals(GqlpValue other)
    => other is GqlpMap map
      && Entries.Count == map.Entries.Count
      && Entries.All(e => map.Entries.TryGetValue(e.Key, out IGqlpValue? v) && e.Value.Equals(v));

  protected override int ValueHash()
    => Entries.Aggregate(Entries.Count, (h, e) => h ^ Combine(e.Key.GetHashCode(), e.Value.GetHashCode()));

  public override bool IsEmpty() => Entries.Count == 0;

  public override string ToString()
    => Tag.Suffixed("!") + Entries.Surround("{ ", " }", i => $"{i.Key}: {i.Value}", ", ");
}

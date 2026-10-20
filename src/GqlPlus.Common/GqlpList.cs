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
}

public sealed class GqlpMap(IEnumerable<KeyValuePair<string, IGqlpValue>> entries, string? tag = null, bool flow = false)
  : GqlpValue(tag)
{
  public IReadOnlyDictionary<string, IGqlpValue> Entries { get; }
    = entries.ToDictionary(e => e.Key, e => e.Value, StringComparer.Ordinal);
  public bool Flow { get; } = flow;

  protected override bool ValueEquals(GqlpValue other)
    => other is GqlpMap map
      && Entries.Count == map.Entries.Count
      && Entries.All(e => map.Entries.TryGetValue(e.Key, out IGqlpValue? v) && e.Value.Equals(v));

  protected override int ValueHash()
    => Entries.Aggregate(Entries.Count, (h, e) => h ^ Combine(StringComparer.Ordinal.GetHashCode(e.Key), e.Value.GetHashCode()));
}

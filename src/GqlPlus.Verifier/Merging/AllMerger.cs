namespace GqlPlus.Verifier.Merging;

internal class AllMerger<TItem>(
  IEnumerable<IMergeAll<TItem>> all
) : IMerge<TItem>
{
  public virtual bool CanMerge(IEnumerable<TItem> items)
  {
    var list = items.ToArray();
    if (list.Length > 1) {
      if (list.Select(i => i?.GetType()).Distinct().Count() == 1) {
        var each = all.Select(scalar => (scalar, scalar.CanMerge(items))).ToList();
        return each.All(item => item.Item2);
      }
    } else if (list.Length > 0) {
      return true;
    }

    return false;
  }

  public virtual IEnumerable<TItem> Merge(IEnumerable<TItem> items)
    => items is null
      ? Enumerable.Empty<TItem>()
      : all.SelectMany(scalar => scalar.Merge(items));
}

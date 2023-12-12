namespace GqlPlus.Verifier.Merging;

public abstract class DistinctsMerger<TItem>
  : IMerge<TItem>
{
  public virtual bool CanMerge(TItem[] items)
  {
    foreach (var group in items.GroupBy(ItemGroupKey)) {
      var distinct = group.Select(ItemMatchKey).Distinct().ToList();
      if (distinct.Count > 1) {
        return false;
      }
    }

    return items.Length > 0;
  }

  protected abstract string ItemGroupKey(TItem item);
  protected abstract string ItemMatchKey(TItem item);

  public virtual TItem Merge(TItem[] items) => throw new NotImplementedException();
}

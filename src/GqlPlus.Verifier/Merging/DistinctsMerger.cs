namespace GqlPlus.Verifier.Merging;

public abstract class DistinctsMerger<TItem>
  : IMerge<TItem>
{
  public virtual bool CanMerge(TItem[] items)
  {
    var distinct = items.Select(ItemMatchKey).Distinct().ToList();
    return distinct.Count == 1;
  }

  public abstract TItem Merge(TItem[] items);
  public TItem[] MergeAll(TItem[] items) => throw new NotImplementedException();

  protected virtual string ItemMatchKey(TItem item) => "";
}

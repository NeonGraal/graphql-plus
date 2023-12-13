namespace GqlPlus.Verifier.Merging;

public abstract class DistinctsMerger<TItem>
  : IMerge<TItem>
{
  public virtual bool CanMerge(TItem[] items)
  {
    var distinct = items.Select(ItemMatchKey).Distinct().ToList();
    return distinct.Count == 1;
  }

  protected abstract string ItemMatchKey(TItem item);

  public virtual TItem Merge(TItem[] items) => throw new NotImplementedException();
}

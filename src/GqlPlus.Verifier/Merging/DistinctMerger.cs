namespace GqlPlus.Verifier.Merging;

public abstract class DistinctMerger<TItem>
  : IMerge<TItem>
{
  public virtual bool CanMerge(TItem[] items)
  {
    var distinct = items.Select(ItemGroupKey).Distinct().ToList();
    return distinct.Count == 1;
  }

  protected abstract string ItemGroupKey(TItem item);

  public virtual TItem Merge(TItem[] items) => throw new NotImplementedException();
}

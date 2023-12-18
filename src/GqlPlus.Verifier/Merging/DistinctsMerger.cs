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

  // Todo: Implement Merge
  public virtual TItem Merge(TItem[] items)
    => items.Length switch {
      0 => throw new InvalidOperationException(),
      1 => items[0],
      _ => throw new NotImplementedException(),
    };
}

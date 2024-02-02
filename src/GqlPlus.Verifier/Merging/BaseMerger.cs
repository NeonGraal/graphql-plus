namespace GqlPlus.Verifier.Merging;

internal class BaseMerger<TItem>
  : IMerge<TItem>
{
  public virtual bool CanMerge(IEnumerable<TItem> items)
    => items.Any();

  public virtual IEnumerable<TItem> Merge(IEnumerable<TItem> items)
    => items ?? Enumerable.Empty<TItem>();
}

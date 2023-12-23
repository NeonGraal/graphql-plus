namespace GqlPlus.Verifier.Merging;

public class BaseMerger<TItem>
  : IMerge<TItem>
{
  public virtual bool CanMerge(TItem[] items)
    => items.Length > 0;

  public virtual TItem[] Merge(TItem[] items)
    => items is null ? [] : items;
}

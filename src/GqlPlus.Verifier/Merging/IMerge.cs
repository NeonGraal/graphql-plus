namespace GqlPlus.Verifier.Merging;

public interface IMerge<TItem>
{
  bool CanMerge(TItem[] items);
  TItem Merge(TItem[] items);
}

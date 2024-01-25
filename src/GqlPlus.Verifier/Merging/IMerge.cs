namespace GqlPlus.Verifier.Merging;

public interface IMerge<TItem>
{
  bool CanMerge(IEnumerable<TItem> items);
  IEnumerable<TItem> Merge(IEnumerable<TItem> items);
}

public interface IMergeAll<T> : IMerge<T> { }

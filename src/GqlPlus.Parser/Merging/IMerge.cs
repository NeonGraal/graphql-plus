using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Merging;

public interface IMerge<TItem>
  where TItem : IGqlpError
{
  IMessages CanMerge(IEnumerable<TItem> items);
  IEnumerable<TItem> Merge(IEnumerable<TItem> items);
}

internal interface IMergeAll<TItem>
  : IMerge<TItem>
  where TItem : IGqlpType
{ }

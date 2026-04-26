using GqlPlus.Ast.Schema;

namespace GqlPlus.Merging;

public interface IMerge<TItem>
  where TItem : IAstError
{
  IMessages CanMerge(IEnumerable<TItem> items);
  IEnumerable<TItem> Merge(IEnumerable<TItem> items);
}

public interface IMergeAll<TItem>
  : IMerge<TItem>
  where TItem : IAstType
{ }

using GqlPlus.Ast.Schema;

namespace GqlPlus.Merging;

public interface IMerge<TItem>
  where TItem : IGqlpError
{
  ITokenMessages CanMerge(IEnumerable<TItem> items);
  IEnumerable<TItem> Merge(IEnumerable<TItem> items);
}

public interface IMergeAll<TItem>
  : IMerge<TItem>
  where TItem : AstType
{ }

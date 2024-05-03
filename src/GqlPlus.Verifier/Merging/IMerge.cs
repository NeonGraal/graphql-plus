using GqlPlus.Ast;
using GqlPlus.Ast.Schema;
using GqlPlus.Token;

namespace GqlPlus.Merging;

public interface IMerge<TItem>
  where TItem : AstBase
{
  ITokenMessages CanMerge(IEnumerable<TItem> items);
  IEnumerable<TItem> Merge(IEnumerable<TItem> items);
}

public interface IMergeAll<TItem>
  : IMerge<TItem>
  where TItem : AstType
{ }

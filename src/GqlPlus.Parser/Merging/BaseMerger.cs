using GqlPlus.Ast;
using GqlPlus.Token;

namespace GqlPlus.Merging;

internal abstract class BaseMerger<TItem>
  : IMerge<TItem>
  where TItem : IGqlpError
{
  public virtual IMessages CanMerge(IEnumerable<TItem> items)
    => items.Any() ? Messages.New : new Messages(
      new TokenMessage(AstNulls.At, $"No items to merge for {GetType().ExpandTypeName()}")
      );

  public abstract IEnumerable<TItem> Merge(IEnumerable<TItem> items);
}

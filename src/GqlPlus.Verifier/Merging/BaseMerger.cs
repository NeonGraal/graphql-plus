using GqlPlus.Ast;

namespace GqlPlus.Merging;

internal class BaseMerger<TItem>
  : IMerge<TItem>
  where TItem : AstBase
{
  public virtual ITokenMessages CanMerge(IEnumerable<TItem> items)
    => items.Any() ? [] : new TokenMessages(
      new TokenMessage(AstNulls.At, $"No items to merge for {GetType().ExpandTypeName()}")
      );

  public virtual IEnumerable<TItem> Merge(IEnumerable<TItem> items)
    => items ?? Enumerable.Empty<TItem>();
}

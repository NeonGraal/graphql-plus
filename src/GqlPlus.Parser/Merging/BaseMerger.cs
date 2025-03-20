using GqlPlus.Ast;
using GqlPlus.Token;

namespace GqlPlus.Merging;

internal class BaseMerger<TItem>
  : IMerge<TItem>
  where TItem : IGqlpError
{
  public virtual ITokenMessages CanMerge(IEnumerable<TItem> items)
    => items.Any() ? TokenMessages.New : Messages(
      new TokenMessage(AstNulls.At, $"No items to merge for {GetType().ExpandTypeName()}")
      );

  public virtual IEnumerable<TItem> Merge(IEnumerable<TItem> items)
    => items ?? [];

  internal static ITokenMessages Messages(params ITokenMessage[] messages)
    => new TokenMessages(messages);
}

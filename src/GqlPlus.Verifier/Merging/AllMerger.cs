using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Merging;

internal class AllMerger<TItem>(
  IEnumerable<IMergeAll<TItem>> all
) : IMerge<TItem>
  where TItem : AstBase
{
  public virtual ITokenMessages CanMerge(IEnumerable<TItem> items)
  {
    var result = new TokenMessages();
    var list = items.ToArray();
    if (list.Length > 1) {
      var each = all.Select(scalar => (scalar, scalar.CanMerge(items))).ToList();
      result.Add(each.SelectMany(item => item.Item2));
    } else if (list.Length < 1) {
      result.Add(new TokenMessage(AstNulls.At, $"No items to merge for {GetType().ExpandTypeName()}"));
    }

    return result;
  }

  public virtual IEnumerable<TItem> Merge(IEnumerable<TItem> items)
    => items is null ? []
      : all.SelectMany(scalar => scalar.Merge(items));
}

using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Merging;

internal abstract class AllMerger<TItem>(
  ILoggerFactory logger,
  IEnumerable<IMergeAll<TItem>> all
) : DistinctMerger<TItem>(logger)
  where TItem : AstType
{

  public virtual ITokenMessages OldCanMerge(IEnumerable<TItem> items)
  {
    var result = new TokenMessages();
    var groups = items.GroupBy(x => x.Name).ToArray();
    if (groups.Length < 1) {
      result.Add(new TokenMessage(AstNulls.At, $"No items to merge for {GetType().ExpandTypeName()}"));
    } else {
      foreach (var group in groups) {
        var distinct = group.Select(g => g.Label).Distinct().ToArray();
        if (distinct.Length == 1) {
          var each = all.Select(scalar => (scalar, scalar.CanMerge(group))).ToList();
          result.Add(each.SelectMany(item => item.Item2));
        } else {
          result.Add(group.Last().Error($""));
        }
      }
    }

    return result;
  }

  public virtual IEnumerable<TItem> OldMerge(IEnumerable<TItem> items)
    => items is null ? []
      : all.SelectMany(scalar => scalar.Merge(items));
  protected override ITokenMessages CanMergeGroup(IGrouping<string, TItem> group)
  {
    var result = base.CanMergeGroup(group);
    if (!result.Any()) {
      var each = all.Select(scalar => (scalar, scalar.CanMerge(group))).ToList();
      result.Add(each.SelectMany(item => item.Item2));
    }

    return result;
  }

  protected override string ItemGroupKey(TItem item) => item.Name;

  protected override TItem MergeGroup(IEnumerable<TItem> group)
    => all.SelectMany(scalar => scalar.Merge(group)).First();
}

using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal abstract class AstAliasedMerger<TItem>(
  ILoggerFactory logger
) : DistinctMerger<TItem>(logger)
  where TItem : AstAliased
{
  protected override string ItemGroupKey(TItem item) => item.Name;

  public override bool CanMerge(IEnumerable<TItem> items)
    => base.CanMerge(items) && items
      .SelectMany(item => item.Aliases.Select(alias => (alias, item)))
      .GroupBy(pair => pair.alias)
      .All(CanMergeAliases);

  private bool CanMergeAliases(IGrouping<string, (string alias, TItem item)> group)
    => group.Select(pair => ItemGroupKey(pair.item))
      .Distinct().Count() == 1;

  protected override bool CanMergeGroup(IGrouping<string, TItem> group)
    => base.CanMergeGroup(group)
      && group.CanMerge(item => item.Description);

  protected override TItem MergeGroup(IEnumerable<TItem> group)
  {
    var list = group.ToArray();
    var description = list.MergeDescriptions();
    var aliases = list.SelectMany(item => item.Aliases).Distinct().ToArray();

    return list.First() with {
      Description = description,
      Aliases = aliases,
    };
  }
}

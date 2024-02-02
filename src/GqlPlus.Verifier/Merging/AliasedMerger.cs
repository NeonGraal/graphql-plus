using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal abstract class AliasedMerger<TItem>
  : DistinctMerger<TItem>
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
    var description = group.MergeDescriptions();
    var aliases = group.SelectMany(item => item.Aliases).Distinct().ToArray();

    return group.First() with {
      Description = description,
      Aliases = aliases,
    };
  }
}

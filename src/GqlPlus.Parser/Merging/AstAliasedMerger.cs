using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Result;

namespace GqlPlus.Merging;

internal abstract class AstAliasedMerger<TItem>(
  ILoggerFactory logger
) : DistinctMerger<TItem>(logger)
  where TItem : IGqlpAliased
{
  protected override string ItemGroupKey(TItem item) => item.Name;

  public override ITokenMessages CanMerge(IEnumerable<TItem> items)
    => base.CanMerge(items)
      .Add(items
      .SelectMany(item => item.Aliases.Select(alias => (alias, item)))
      .GroupBy(pair => pair.alias)
      .SelectMany(CanMergeAliases));

  private ITokenMessages CanMergeAliases(IGrouping<string, (string alias, TItem item)> group)
  {
    IEnumerable<string> distinct = group
      .Select(pair => ItemGroupKey(pair.item))
      .Distinct();
    return distinct.Count() == 1 ? Messages()
      : group.Last().item
        .MakeError($"Aliases of {typeof(TItem).TidyTypeName()} for {group.Key} is not singular [{distinct.Debug()}]");
  }

  protected override ITokenMessages CanMergeGroup(IGrouping<string, TItem> group)
    => base.CanMergeGroup(group)
      .Add(group.CanMergeString(item => item.Description));

  protected override TItem MergeGroup(IEnumerable<TItem> group)
  {
    TItem[] list = group.ToArray();
    string description = list.MergeDescriptions();
    string[] aliases = list.SelectMany(item => item.Aliases).Distinct().ToArray();

    TItem result = list.First();
    result.SetAliases(aliases, description);
    return result;
  }
}

using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Result;

namespace GqlPlus.Merging;

internal abstract class AstAliasedMerger<TItem>(
  ILoggerFactory logger
) : DistinctMerger<TItem>(logger)
  where TItem : IGqlpAliased
{
  private readonly ILogger _logger = logger.CreateLogger(nameof(AstAliasedMerger<TItem>));

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
    if (distinct.Count() == 1) {
      return Messages();
    }

    string typeName = typeof(TItem).TidyTypeName();
    string values = distinct.Debug();
    _logger.AliasesNotSingular(typeName, group.Key, ItemMatchName, values);

    return group.Last().item
        .MakeError($"Aliases of {typeName} for '{group.Key}' is not singular {ItemMatchName}[{values}]");
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

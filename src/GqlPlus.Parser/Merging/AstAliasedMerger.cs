using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
using GqlPlus.Result;

namespace GqlPlus.Merging;

internal abstract class AstAliasedMerger<TItem>
  : DistinctMerger<TItem>
  where TItem : IGqlpAliased
{
  private readonly ILogger _logger;

  public AstAliasedMerger(ILoggerFactory logger)
    : base(logger)
    => _logger = logger.CreateTypedLogger(this);

  protected override string ItemGroupKey(TItem item) => item.Name;

  public override IMessages CanMerge(IEnumerable<TItem> items)
    => base.CanMerge(items)
      .Add(items
      .SelectMany(item => item.Aliases.Select(alias => (alias, item)))
      .GroupBy(pair => pair.alias)
      .SelectMany(CanMergeAliases));

  private IMessages CanMergeAliases(IGrouping<string, (string alias, TItem item)> group)
  {
    IEnumerable<string> distinct = group
      .Select(pair => ItemGroupKey(pair.item))
      .Distinct();
    if (distinct.Count() == 1) {
      return Messages.New;
    }

    string typeName = typeof(TItem).TidyTypeName();
    string values = distinct.Debug();
    _logger.AliasesNotSingular(typeName, group.Key, ItemMatchName, values);

    return group.Last().item
        .MakeError($"Aliases of {typeName} for '{group.Key}' not singular {ItemMatchName}[{values}]");
  }

  protected override TItem MergeGroup(IEnumerable<TItem> group)
  {
    TItem[] list = [.. group];
    TItem result = list.First();
    if (result is IAstSetAliases setAliases) {
      setAliases.SetAliases(list.SelectMany(item => item.Aliases).Distinct());
      setAliases.MakeDescription(list);
    }

    return result;
  }
}

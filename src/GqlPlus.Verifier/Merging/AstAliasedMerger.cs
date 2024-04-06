using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Merging;

internal abstract class AstAliasedMerger<TItem>(
  ILoggerFactory logger
) : DistinctMerger<TItem>(logger)
  where TItem : AstAliased
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
    var distinct = group.Select(pair => ItemGroupKey(pair.item))
            .Distinct();
    return distinct.Count() == 1 ? []
      : new TokenMessages(group.Last()
        .item.Error($"Aliases of {typeof(TItem).ExpandTypeName()} for {group.Key} is not singular [{distinct.Debug()}]"));
  }

  protected override ITokenMessages CanMergeGroup(IGrouping<string, TItem> group)
    => base.CanMergeGroup(group)
      .Add(group.CanMerge(item => item.Description));

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

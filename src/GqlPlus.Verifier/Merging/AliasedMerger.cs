using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public abstract class AliasedMerger<TItem>
  : DistinctMerger<TItem>
  where TItem : AstAliased
{
  protected override string ItemGroupKey(TItem item) => item.Name;

  protected override bool CanMergeGroup(IGrouping<string, TItem> group)
    => base.CanMergeGroup(group)
      && group.CanMerge(item => item.Description);

  protected override TItem MergeGroup(IEnumerable<TItem> group)
  {
    var description = group.MergeDescriptions();
    var aliases = group.MergeAliases();

    return group.First() with {
      Description = description,
      Aliases = aliases,
    };
  }
}

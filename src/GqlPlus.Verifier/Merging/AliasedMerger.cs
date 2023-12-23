using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public abstract class AliasedMerger<TItem>
  : NamedMerger<TItem>
  where TItem : AstAliased
{
  protected override bool CanMergeGroup(IGrouping<string, TItem> group)
    => base.CanMergeGroup(group)
      && group.CanMerge(item => item.Description);

  protected override TItem MergeGroup(TItem[] group)
  {
    var description = group.MergeDescriptions();
    var aliases = group.MergeAliases();
    return group.First() with {
      Description = description,
      Aliases = aliases,
    };
  }
}

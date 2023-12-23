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
    => group.First() with {
      Description = group.MergeDescriptions(),
      Aliases = group.MergeAliases(),
    };
}

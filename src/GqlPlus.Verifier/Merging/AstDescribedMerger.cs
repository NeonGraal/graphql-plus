using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Merging;

internal abstract class AstDescribedMerger<TItem>(
  ILoggerFactory logger
) : DistinctMerger<TItem>(logger)
  where TItem : IAstDescribed
{
  protected override bool CanMergeGroup(IGrouping<string, TItem> group)
    => base.CanMergeGroup(group)
    && group.CanMerge(item => item.Description);
}

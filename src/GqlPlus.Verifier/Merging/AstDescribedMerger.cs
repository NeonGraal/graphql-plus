using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;

namespace GqlPlus.Merging;

internal abstract class AstDescribedMerger<TItem>(
  ILoggerFactory logger
) : DistinctMerger<TItem>(logger)
  where TItem : AstBase, IGqlpDescribed
{
  protected override ITokenMessages CanMergeGroup(IGrouping<string, TItem> group)
    => base.CanMergeGroup(group)
    .Add(group.CanMerge(item => item.Description));
}

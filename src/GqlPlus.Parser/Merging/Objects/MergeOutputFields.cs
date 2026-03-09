using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

internal class MergeOutputFields(
  IMergerRepository mergers
) : AstObjectFieldsMerger<IGqlpOutputField>(mergers.LoggerFactory)
{
  protected override IMessages CanMergeGroup(IGrouping<string, IGqlpOutputField> group)
    => base.CanMergeGroup(group)
      .Add(group.CanMerge(item => item.Parameter, mergers.MergerFor<IGqlpInputParam>()));
  protected override IGqlpOutputField MergeGroup(IEnumerable<IGqlpOutputField> group)
    => (OutputFieldAst)base.MergeGroup(group) with {
      Parameter = group.Merge(item => item.Parameter, mergers.MergerFor<IGqlpInputParam>()).FirstOrDefault(),
    };
}

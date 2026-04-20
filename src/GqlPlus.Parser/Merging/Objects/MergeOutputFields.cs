using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

internal class MergeOutputFields(
  IMergerRepository mergers
) : AstObjectFieldsMerger<IAstOutputField>(mergers)
{
  protected override IMessages CanMergeGroup(IGrouping<string, IAstOutputField> group)
    => base.CanMergeGroup(group)
      .Add(group.CanMerge(item => item.Parameter, mergers.MergerFor<IAstInputParam>()));
  protected override IAstOutputField MergeGroup(IEnumerable<IAstOutputField> group)
    => (OutputFieldAst)base.MergeGroup(group) with {
      Parameter = group.Merge(item => item.Parameter, mergers.MergerFor<IAstInputParam>()).FirstOrDefault(),
    };

  internal static MergeOutputFields Factory(IMergerRepository m) => new(m);
}

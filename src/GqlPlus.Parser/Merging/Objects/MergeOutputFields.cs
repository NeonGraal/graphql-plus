using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

internal class MergeOutputFields(
  IMergerRepository mergers
) : AstObjectFieldsMerger<IAstOutputField>(mergers)
{
  private readonly DeferOne<IMerge<IAstInputParam>> _inputParam = mergers.MergerFor<IAstInputParam>();

  protected override IMessages CanMergeGroup(IGrouping<string, IAstOutputField> group)
    => base.CanMergeGroup(group)
      .Add(group.CanMerge(item => item.Parameter, _inputParam.I));
  protected override IAstOutputField MergeGroup(IEnumerable<IAstOutputField> group)
    => (OutputFieldAst)base.MergeGroup(group) with {
      Parameter = group.Merge(item => item.Parameter, _inputParam.I).FirstOrDefault(),
    };

  internal static MergeOutputFields Factory(IMergerRepository m) => new(m);
}

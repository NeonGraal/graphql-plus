using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

internal class MergeOutputFields(
  ILoggerFactory logger,
  IMerge<IGqlpInputParameter> parameters
) : AstObjectFieldsMerger<IGqlpOutputField>(logger)
{
  protected override ITokenMessages CanMergeGroup(IGrouping<string, IGqlpOutputField> group)
    => base.CanMergeGroup(group)
      .Add(group.ManyCanMerge(item => item.Parameters, parameters));

  protected override OutputFieldAst MergeGroup(IEnumerable<IGqlpOutputField> group)
    => (OutputFieldAst)base.MergeGroup(group) with {
      Parameters = group.ManyMerge(item => item.Parameters, parameters).ArrayOf<InputParameterAst>(),
    };
}

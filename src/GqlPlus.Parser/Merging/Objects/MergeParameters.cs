using GqlPlus.Ast;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

internal class MergeParameters(
  ILoggerFactory logger,
  IMerge<IGqlpConstant> constant
) : AstAlternatesMerger<InputParameterAst, InputBaseAst>(logger)
{
  protected override ITokenMessages CanMergeGroup(IGrouping<string, InputParameterAst> group)
    => base.CanMergeGroup(group)
      .Add(group.CanMerge(item => item.DefaultValue, constant));
  protected override InputParameterAst MergeGroup(IEnumerable<InputParameterAst> group)
  => base.MergeGroup(group) with {
    DefaultValue = (ConstantAst?)group.Merge(item => item.DefaultValue, constant).FirstOrDefault()
  };
}

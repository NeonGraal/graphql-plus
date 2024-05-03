using GqlPlus.Ast;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Merging.Objects;

internal class MergeParameters(
  ILoggerFactory logger,
  IMerge<ConstantAst> constant
) : AstAlternatesMerger<ParameterAst, InputBaseAst>(logger)
{
  protected override ITokenMessages CanMergeGroup(IGrouping<string, ParameterAst> group)
    => base.CanMergeGroup(group)
      .Add(group.CanMerge(item => item.Default, constant));
  protected override ParameterAst MergeGroup(IEnumerable<ParameterAst> group)
  => base.MergeGroup(group) with {
    Default = group.Merge(item => item.Default, constant).FirstOrDefault()
  };
}

using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Ast.Schema.Objects;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Merging.Objects;

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

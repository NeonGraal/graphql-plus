using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Merging;

internal class MergeParameters(
  ILoggerFactory logger
) : AstAlternatesMerger<ParameterAst, InputReferenceAst>(logger)
{
  protected override ITokenMessages CanMergeGroup(IGrouping<string, ParameterAst> group)
    => base.CanMergeGroup(group)
      .Add(group.CanMerge(item => item.Default));
}

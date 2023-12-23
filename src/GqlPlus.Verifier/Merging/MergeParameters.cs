using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeParameters
  : AlternatesMerger<ParameterAst, InputReferenceAst>
{
  protected override bool CanMergeGroup(IGrouping<string, ParameterAst> group)
    => base.CanMergeGroup(group)
    && group.CanMerge(item => item.Default);
}

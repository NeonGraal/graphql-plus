using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeParameters
  : AlternatesMerger<ParameterAst, InputReferenceAst>
{
  public override bool CanMerge(ParameterAst[] items)
    => base.CanMerge(items)
    && items.CanMerge(item => item.Default);
}

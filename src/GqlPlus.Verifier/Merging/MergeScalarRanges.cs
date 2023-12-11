using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeScalarRanges
  : DistinctsMerger<ScalarRangeAst>
{
  protected override string ItemGroupKey(ScalarRangeAst item)
    => "";
}

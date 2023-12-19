using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeScalarRanges
  : DistinctsMerger<ScalarRangeAst>
{
  public override ScalarRangeAst Merge(ScalarRangeAst[] items)
    => items.First();
}

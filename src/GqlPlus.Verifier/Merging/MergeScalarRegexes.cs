using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeScalarRegexes
  : DistinctMerger<ScalarRegexAst>
{
  protected override string ItemGroupKey(ScalarRegexAst item)
    => item.Excludes.ToString();
}

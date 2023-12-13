using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeScalarRegexes
  : DistinctsMerger<ScalarRegexAst>
{
  protected override string ItemMatchKey(ScalarRegexAst item)
    => item.Excludes.ToString();
}

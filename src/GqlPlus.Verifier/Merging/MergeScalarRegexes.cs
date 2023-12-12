using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeScalarRegexes
  : DistinctsMerger<ScalarRegexAst>
{
  protected override string ItemGroupKey(ScalarRegexAst item)
    => item.Regex;
  protected override string ItemMatchKey(ScalarRegexAst item)
    => item.Excludes.ToString();
}

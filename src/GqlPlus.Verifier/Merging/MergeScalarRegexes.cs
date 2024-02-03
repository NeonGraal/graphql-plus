using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeScalarRegexes
  : ScalarItemMerger<ScalarRegexAst>
{
  protected override string ItemGroupKey(ScalarRegexAst item)
    => item.Regex;
}

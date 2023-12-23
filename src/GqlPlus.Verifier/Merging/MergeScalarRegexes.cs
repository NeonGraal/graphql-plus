using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeScalarRegexes
  : DistinctMerger<ScalarRegexAst>
{
  protected override string ItemGroupKey(ScalarRegexAst item) => item.Regex;

  protected override string ItemMatchKey(ScalarRegexAst item)
    => item.Excludes.ToString();

  protected override ScalarRegexAst MergeGroup(IEnumerable<ScalarRegexAst> group)
    => group.First();
}

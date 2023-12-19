using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeScalarRegexes
  : DistinctsMerger<ScalarRegexAst>
{
  public override ScalarRegexAst Merge(ScalarRegexAst[] items)
    => items.First();

  protected override string ItemMatchKey(ScalarRegexAst item)
    => item.Excludes.ToString();
}

using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeScalars(
  IMerge<ScalarRangeAst> ranges,
  IMerge<ScalarRegexAst> regexes
) : DescribedMerger<ScalarDeclAst>
{
  protected override string ItemGroupKey(ScalarDeclAst item)
    => item.Kind.ToString();
  public override bool CanMerge(ScalarDeclAst[] items)
    => base.CanMerge(items)
      && ranges.CanMerge([.. items.SelectMany(item => item.Ranges)])
      && regexes.CanMerge([.. items.SelectMany(item => item.Regexes)]);
}

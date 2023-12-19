using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeScalars(
  IMerge<ScalarRangeAst> ranges,
  IMerge<ScalarRegexAst> regexes
) : DescribedsMerger<ScalarDeclAst>
{
  protected override string ItemMatchKey(ScalarDeclAst item)
    => item.Kind.ToString();

  public override bool CanMerge(ScalarDeclAst[] items)
    => base.CanMerge(items)
      && items.ManyMerge(i => i.Ranges, ranges)
      && items.ManyGroupMerge(i => i.Regexes, r => r.Regex, regexes);
  public override ScalarDeclAst Merge(ScalarDeclAst[] items)
    => items.First() with { Description = MergeDescriptions(items) };
}

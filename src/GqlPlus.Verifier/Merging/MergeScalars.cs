using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeScalars(
  IMerge<ScalarRangeAst> ranges,
  IMerge<ScalarRegexAst> regexes
) : AliasedMerger<ScalarDeclAst>
{
  protected override string ItemMatchKey(ScalarDeclAst item)
    => item.Kind.ToString();

  public override bool CanMerge(ScalarDeclAst[] items)
    => base.CanMerge(items)
      && items.ManyCanMerge(i => i.Ranges, ranges)
      && items.ManyGroupCanMerge(i => i.Regexes, r => r.Regex, regexes);
}

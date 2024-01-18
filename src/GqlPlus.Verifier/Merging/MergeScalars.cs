using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeScalars(
  IMerge<ScalarRangeNumberAst> ranges,
  IMerge<ScalarRegexAst> regexes
) : AliasedMerger<ScalarDeclAst>
{
  protected override string ItemMatchKey(ScalarDeclAst item)
    => item.Kind.ToString();

  public override bool CanMerge(IEnumerable<ScalarDeclAst> items)
    => base.CanMerge(items)
      && items.ManyCanMerge(i => i.Numbers, ranges)
      && items.ManyGroupCanMerge(i => i.Regexes, r => r.Regex, regexes);
}

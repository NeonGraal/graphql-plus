using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeScalars(
  IMerge<ScalarRangeAst> ranges,
  IMerge<ScalarRegexAst> regexes
) : NamedMerger<ScalarDeclAst>
{
  protected override string ItemMatchKey(ScalarDeclAst item)
    => item.Kind.ToString();

  public override bool CanMerge(ScalarDeclAst[] items)
    => base.CanMerge(items)
      && items.CanMerge(item => item.Description)
      && items.ManyMerge(i => i.Ranges, ranges)
      && items.ManyGroupMerge(i => i.Regexes, r => r.Regex, regexes);

  protected override ScalarDeclAst MergeGroup(ScalarDeclAst[] items)
    => items.First() with { Description = items.MergeDescriptions() };
}

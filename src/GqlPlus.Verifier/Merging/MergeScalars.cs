using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeScalars(
  IMerge<ScalarRangeNumberAst> ranges
) : AliasedMerger<AstScalar>
{
  protected override string ItemMatchKey(AstScalar item)
    => item.Kind.ToString();

  public override bool CanMerge(IEnumerable<AstScalar> items)
    => base.CanMerge(items)
      ; // && items.ManyCanMerge(i => i.Members, ranges);
}

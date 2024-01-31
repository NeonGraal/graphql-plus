using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeScalars<TMember>(
  IMerge<TMember> members
) : AliasedAllMerger<AstScalar, AstScalar<TMember>>
  where TMember : IAstScalarMember
{
  protected override string ItemMatchKey(AstScalar<TMember> item)
    => item.Kind.ToString();

  public override bool CanMerge(IEnumerable<AstScalar<TMember>> items)
    => base.CanMerge(items)
      && items.ManyCanMerge(i => i.Items, members);
}

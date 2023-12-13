using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeEnums(
  IMerge<EnumValueAst> enumValues
) : DescribedsMerger<EnumDeclAst>
{
  protected override string ItemMatchKey(EnumDeclAst item)
    => item.Extends ?? "";

  public override bool CanMerge(EnumDeclAst[] items)
    => base.CanMerge(items)
      && items.ManyMerge(e => e.Values, enumValues);
}

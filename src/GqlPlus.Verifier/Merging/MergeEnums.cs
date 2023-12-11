using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeEnums(IMerge<EnumValueAst> enumValues)
  : DescribedsMerger<EnumDeclAst>
{
  protected override string ItemGroupKey(EnumDeclAst item)
    => item.Extends ?? "";
  public override bool CanMerge(EnumDeclAst[] items)
    => base.CanMerge(items)
      && enumValues.CanMerge([.. items.SelectMany(item => item.Values)]);
}

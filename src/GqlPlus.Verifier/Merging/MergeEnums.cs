using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeEnums(
  IMerge<EnumValueAst> enumValues
) : AliasedMerger<EnumDeclAst>
{
  protected override string ItemMatchKey(EnumDeclAst item)
    => item.Extends ?? "";

  public override bool CanMerge(IEnumerable<EnumDeclAst> items)
    => base.CanMerge(items)
      && items.ManyCanMerge(e => e.Values, enumValues);

  protected override EnumDeclAst MergeGroup(IEnumerable<EnumDeclAst> group)
    => base.MergeGroup(group) with {
      Values = [.. group.ManyMerge(item => item.Values, enumValues)],
    };
}

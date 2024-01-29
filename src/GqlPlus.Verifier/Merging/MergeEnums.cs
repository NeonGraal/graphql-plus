using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeEnums(
  IMerge<EnumMemberAst> enumMembers
) : AliasedAllMerger<AstType, EnumDeclAst>, IMergeAll<AstType>
{
  protected override string ItemMatchKey(EnumDeclAst item)
    => item.Parent ?? "";

  public override bool CanMerge(IEnumerable<EnumDeclAst> items)
    => base.CanMerge(items)
      && items.ManyCanMerge(e => e.Members, enumMembers);

  protected override EnumDeclAst MergeGroup(IEnumerable<EnumDeclAst> group)
    => base.MergeGroup(group) with {
      Members = [.. group.ManyMerge(item => item.Members, enumMembers)],
    };
}

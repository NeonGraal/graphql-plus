using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeEnums(
  IMerge<EnumMemberAst> enumMembers
) : TypedMerger<AstType, EnumDeclAst, string, EnumMemberAst>(enumMembers), IMergeAll<AstType>
{
  protected override string ItemMatchKey(EnumDeclAst item)
    => item.Parent ?? "";

  internal override IEnumerable<EnumMemberAst> GetItems(EnumDeclAst type)
    => type.Members;

  internal override EnumDeclAst SetItems(EnumDeclAst input, IEnumerable<EnumMemberAst> items)
    => input with { Members = [.. items] };
}

using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeUnions(
  IMerge<UnionMemberAst> unionMembers
) : AstTypeMerger<AstType, UnionDeclAst, string, UnionMemberAst>(unionMembers), IMergeAll<AstType>
{
  protected override string ItemMatchKey(UnionDeclAst item)
    => item.Parent ?? "";

  internal override IEnumerable<UnionMemberAst> GetItems(UnionDeclAst type)
    => type.Members;

  internal override UnionDeclAst SetItems(UnionDeclAst input, IEnumerable<UnionMemberAst> items)
    => input with { Members = [.. items] };
}

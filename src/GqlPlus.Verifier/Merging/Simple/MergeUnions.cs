using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Ast.Schema.Simple;

namespace GqlPlus.Verifier.Merging.Simple;

internal class MergeUnions(
  ILoggerFactory logger,
  IMerge<UnionMemberAst> unionMembers
) : AstTypeMerger<AstType, UnionDeclAst, string, UnionMemberAst>(logger, unionMembers)
{
  protected override string ItemMatchName => "Parent";
  protected override string ItemMatchKey(UnionDeclAst item)
    => item.Parent ?? "";

  internal override IEnumerable<UnionMemberAst> GetItems(UnionDeclAst type)
    => type.Members;

  internal override UnionDeclAst SetItems(UnionDeclAst input, IEnumerable<UnionMemberAst> items)
    => input with { Members = [.. items] };
}

using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Merging.Simple;

internal class MergeUnions(
  ILoggerFactory logger,
  IMerge<UnionMemberAst> unionMembers
) : AstTypeMerger<IGqlpType, UnionDeclAst, string, UnionMemberAst>(logger, unionMembers)
{
  protected override string ItemMatchName => "Parent";
  protected override string ItemMatchKey(UnionDeclAst item)
    => item.Parent ?? "";

  internal override IEnumerable<UnionMemberAst> GetItems(UnionDeclAst type)
    => type.Members;

  internal override UnionDeclAst SetItems(UnionDeclAst input, IEnumerable<UnionMemberAst> items)
    => input with { Members = [.. items] };
}

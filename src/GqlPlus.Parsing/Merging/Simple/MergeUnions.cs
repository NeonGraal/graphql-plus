using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Merging.Simple;

internal class MergeUnions(
  ILoggerFactory logger,
  IMerge<UnionMemberAst> unionMembers
) : AstTypeMerger<IGqlpType, IGqlpUnion, string, UnionMemberAst>(logger, unionMembers)
{
  protected override string ItemMatchName => "Parent";
  protected override string ItemMatchKey(IGqlpUnion item)
    => item.Parent ?? "";

  internal override IEnumerable<UnionMemberAst> GetItems(IGqlpUnion type)
    => type.Items.ArrayOf<UnionMemberAst>();

  internal override IGqlpUnion SetItems(IGqlpUnion input, IEnumerable<UnionMemberAst> items)
  {
    UnionDeclAst ast = (UnionDeclAst)input;
    return ast with { Members = items.ArrayOf<UnionMemberAst>() };
  }
}

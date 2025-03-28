using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Merging.Simple;

internal class MergeUnions(
  ILoggerFactory logger,
  IMerge<IGqlpUnionMember> unionMembers
) : AstTypeMerger<IGqlpType, IGqlpUnion, string, IGqlpUnionMember>(logger, unionMembers)
{
  protected override string ItemMatchName => "Parent";
  protected override string ItemMatchKey(IGqlpUnion item)
    => item.Parent ?? "";

  internal override IEnumerable<IGqlpUnionMember> GetItems(IGqlpUnion type)
    => type.Items;

  internal override IGqlpUnion SetItems(IGqlpUnion input, IEnumerable<IGqlpUnionMember> items)
  {
    UnionDeclAst ast = (UnionDeclAst)input;
    return ast with { Items = items.ArrayOf<UnionMemberAst>() };
  }
}

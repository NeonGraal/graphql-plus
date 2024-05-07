using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Merging.Simple;

internal class MergeUnions(
  ILoggerFactory logger,
  IMerge<IGqlpUnionItem> unionMembers
) : AstTypeMerger<IGqlpType, IGqlpUnion, string, IGqlpUnionItem>(logger, unionMembers)
{
  protected override string ItemMatchName => "Parent";
  protected override string ItemMatchKey(IGqlpUnion item)
    => item.Parent ?? "";

  internal override IEnumerable<IGqlpUnionItem> GetItems(IGqlpUnion type)
    => type.Items;

  internal override IGqlpUnion SetItems(IGqlpUnion input, IEnumerable<IGqlpUnionItem> items)
  {
    UnionDeclAst ast = (UnionDeclAst)input;
    return ast with { Members = items.ArrayOf<UnionMemberAst>() };
  }
}

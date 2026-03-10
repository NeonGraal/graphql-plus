using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Merging.Simple;

internal class MergeUnions(
  IMergerRepository mergers
) : AstSimpleMerger<IGqlpType, IGqlpUnion, IGqlpUnionMember>(mergers)
{
  internal override IGqlpUnion SetItems(IGqlpUnion input, IEnumerable<IGqlpUnionMember> items)
  {
    UnionDeclAst ast = (UnionDeclAst)input;
    return ast with { Items = items.ArrayOf<UnionMemberAst>() };
  }
}

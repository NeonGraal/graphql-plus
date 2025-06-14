using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Merging.Simple;

internal class MergeUnions(
  ILoggerFactory logger,
  IMerge<IGqlpUnionMember> unionMembers
) : AstSimpleMerger<IGqlpType, IGqlpUnion, IGqlpUnionMember>(logger, unionMembers)
{
  internal override IGqlpUnion SetItems(IGqlpUnion input, IEnumerable<IGqlpUnionMember> items)
  {
    UnionDeclAst ast = (UnionDeclAst)input;
    return ast with { Items = items.ArrayOf<UnionMemberAst>() };
  }
}

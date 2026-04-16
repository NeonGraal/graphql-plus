using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Merging.Simple;

internal class MergeUnions(
  IMergerRepository mergers
) : AstSimpleMerger<IAstType, IAstUnion, IAstUnionMember>(mergers)
{
  internal override IAstUnion SetItems(IAstUnion input, IEnumerable<IAstUnionMember> items)
  {
    UnionDeclAst ast = (UnionDeclAst)input;
    return ast with { Items = items.ArrayOf<UnionMemberAst>() };
  }

  internal static MergeUnions Factory(IMergerRepository m) => new(m);
}

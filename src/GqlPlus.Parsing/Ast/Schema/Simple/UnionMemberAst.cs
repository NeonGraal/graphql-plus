using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Simple;

public sealed record class UnionMemberAst(
  TokenAt At,
  string Name,
  string Description
) : AstDescribed(At, Name, Description)
  , IEquatable<UnionMemberAst>
  , IGqlpUnionItem
{
  internal override string Abbr => "UM";
}

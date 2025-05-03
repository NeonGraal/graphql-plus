using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Simple;

internal sealed record class UnionMemberAst(
  ITokenAt At,
  string Name,
  string Description
) : AstNamed(At, Name, Description)
  , IEquatable<UnionMemberAst>
  , IGqlpUnionMember
{
  internal override string Abbr => "UM";
}

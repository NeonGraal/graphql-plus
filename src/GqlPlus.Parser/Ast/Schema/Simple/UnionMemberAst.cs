using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Simple;

internal sealed record class UnionMemberAst(
  TokenAt At,
  string Name,
  string Description
) : AstNamed(At, Name, Description)
  , IGqlpUnionMember
{
  internal override string Abbr => "UM";

  public bool Equals(UnionMemberAst other)
    => other is IGqlpUnionMember member && Equals(member);
  public bool Equals(IGqlpUnionMember? other)
    => base.Equals(other);
  public override int GetHashCode() => base.GetHashCode();
}

using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class UnionMemberAst(
  TokenAt At,
  string Name
) : AstNamed(At, Name), IEquatable<UnionMemberAst>
{
  internal override string Abbr => "UM";
}

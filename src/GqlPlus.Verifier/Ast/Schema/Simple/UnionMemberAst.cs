using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Simple;

public sealed record class UnionMemberAst(
  TokenAt At,
  string Name
) : AstNamed(At, Name), IEquatable<UnionMemberAst>
{
  internal override string Abbr => "UM";
}

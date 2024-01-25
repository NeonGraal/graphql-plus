using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class ScalarFalseAst(TokenAt At)
  : AstAbbreviated(At), IAstScalarMember
{
  internal override string Abbr => "SF";
}

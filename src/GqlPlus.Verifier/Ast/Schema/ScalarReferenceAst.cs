using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class ScalarReferenceAst(TokenAt At, string Name)
  : AstNamed(At, Name), IAstScalarItem
{
  internal override string Abbr => "ST";
}

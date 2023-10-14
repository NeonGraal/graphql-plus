namespace GqlPlus.Verifier.Ast;

internal static class AstNulls
{
  internal static readonly ParseAt At = new(TokenKind.Start, 0, "");

  internal static readonly AstSelection Selection = new NullSelectionAst();

  internal class NullSelectionAst : AstSelection { }
}

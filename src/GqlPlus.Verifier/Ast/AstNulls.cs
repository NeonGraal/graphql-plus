namespace GqlPlus.Verifier.Ast;

internal static class AstNulls
{
  internal static readonly AstSelection Selection = new NullSelectionAst();

  internal class NullSelectionAst : AstSelection { }
}

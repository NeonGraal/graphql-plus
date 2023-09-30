namespace GqlPlus.Verifier.Ast;

internal static class NullAst
{
  internal static readonly SelectionAst Selection = new NullSelectionAst();

  internal class NullSelectionAst : SelectionAst { }
}

using GqlPlus.Abstractions.Operation;
using GqlPlus.Token;

namespace GqlPlus.Ast;

internal static class AstNulls
{
  internal static readonly TokenAt At = new(TokenKind.Start, 0, 0, "");

  internal static readonly IGqlpSelection Selection = new NullSelectionAst();

  public static readonly ConstantAst Constant = new(At);

  internal class NullSelectionAst
    : IGqlpSelection
  {
    IEnumerable<IGqlpDirective> IGqlpDirectives.Directives
    {
      get => [];
      init { }
    }
  }
}

﻿using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast;

internal static class AstNulls
{
  internal static readonly TokenAt At = new(TokenKind.Start, 0, 0, "");

  internal static readonly IAstSelection Selection = new NullSelectionAst();

  public static readonly ConstantAst Constant = new(At);

  internal class NullSelectionAst : IAstSelection { }
}

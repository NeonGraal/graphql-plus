using GqlPlus.Token;

namespace GqlPlus.Ast;

public static class AstNulls
{
  public static readonly TokenAt At = new(TokenKind.Start, 0, 0, "");
}

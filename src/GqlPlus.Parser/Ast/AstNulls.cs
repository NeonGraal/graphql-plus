using GqlPlus.Token;

namespace GqlPlus.Ast;

internal static class AstNulls
{
  internal static readonly TokenAt At = new(TokenKind.Start, 0, 0, "");
}

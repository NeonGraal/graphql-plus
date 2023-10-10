namespace GqlPlus.Verifier;

internal record class ParseError(TokenKind At, int Pos, string Next, string Message);

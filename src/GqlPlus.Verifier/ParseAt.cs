namespace GqlPlus.Verifier;

public record class ParseAt(TokenKind Kind, int Pos, string Next);

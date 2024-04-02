namespace GqlPlus.Verifier.Token;

public record class TokenAt(TokenKind Kind, int Column, int Line, string Next)
{
  public override string? ToString()
    => Kind is TokenKind.Start or TokenKind.End ? ""
      : $"{Kind.ToString()[..1]}@{Column:D3}/{Line:D4}";
}

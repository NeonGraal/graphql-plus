namespace GqlPlus.Verifier;

public record class ParseAt(TokenKind Kind, int Pos, string Next)
{
  public override string? ToString()
    => Kind == TokenKind.Start ? "" : $" {Kind.ToString()[..1]}@{Pos}";
}

namespace GqlPlus.Verifier.Ast;

public record class ParseAt(TokenKind Kind, int Column, int Line, string Next)
{
  public override string? ToString()
    => Kind == TokenKind.Start ? "" : $" {Kind.ToString()[..1]}@{Column}/{Line}";
}

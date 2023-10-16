using System.Text.RegularExpressions;

namespace GqlPlus.Verifier;

public record class ParseError(TokenKind Kind, int Pos, string Next, string Message)
  : ParseAt(Kind, Pos, Next)
{
  public ParseError(ParseAt at, string message)
    : this(at.Kind, at.Pos, at.Next, message) { }

  public override string? ToString()
    => $"!!! {base.ToString()} : {Message} - '{Regex.Escape(Next)}' !!!";
}

using System.Text.RegularExpressions;

namespace GqlPlus.Verifier;

public record class ParseError(TokenKind Kind, int Column, int Line, string Next, string Message)
  : ParseAt(Kind, Column, Line, Next)
{
  public ParseError(ParseAt at, string message)
    : this(at.Kind, at.Column, at.Line, at.Next, message) { }

  public override string? ToString()
    => $"!!! {base.ToString()} : {Message} - '{Regex.Escape(Next)}' !!!";
}

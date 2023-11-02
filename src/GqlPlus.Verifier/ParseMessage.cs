using System.Text.RegularExpressions;

namespace GqlPlus.Verifier;

public record class ParseMessage(TokenKind Kind, int Column, int Line, string Next, string Message)
  : ParseAt(Kind, Column, Line, Next)
{
  public ParseMessage(ParseAt at, string message)
    : this(at.Kind, at.Column, at.Line, at.Next, message) { }

  public override string? ToString()
    => $"!!! {base.ToString()} : {Message} - '{Regex.Escape(Next)}' !!!";
}

using System.Text.RegularExpressions;

namespace GqlPlus.Token;

#pragma warning disable CA1062 // Validate arguments of public methods
public record class TokenMessage(
  TokenKind Kind,
  int Column,
  int Line,
  string After,
  string Message
)
  : TokenAt(Kind, Column, Line, After)
  , ITokenMessage
{
  public TokenMessage(ITokenAt at, string message)
    : this(at.Kind, at.Column, at.Line, at.After, message) { }

  MessageLevel IMessage.Level => MessageLevel.Error;

  public override string? ToString()
    => $"!!! {base.ToString()} : {Message} - '{Regex.Escape(After)}' !!!";
}

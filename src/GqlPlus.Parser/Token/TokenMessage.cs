using System.Text.RegularExpressions;

namespace GqlPlus.Token;

#pragma warning disable CA1062 // Validate arguments of public methods
public record class TokenMessage(
  TokenKind Kind,
  int Column,
  int Line,
  string After,
  string Message
) : TokenAt(Kind, Column, Line, After)
  , ITokenMessage
{
  public TokenMessage(TokenAt at, string message)
    : this(at.Kind, at.Column, at.Line, at.After, message) { }

  public override string? ToString()
    => $"!!! {base.ToString()} : {Message} - '{Regex.Escape(After)}' !!!";
}

public class TokenMessages(
  params ITokenMessage[] collection
) : List<ITokenMessage>(collection)
  , ITokenMessages
{
  public static ITokenMessages New
    => new TokenMessages();

  ITokenMessages ITokenMessages.Add(IEnumerable<ITokenMessage> messages)
    => messages.Aggregate(this as ITokenMessages, (a, m) => a.Add(m));

  ITokenMessages ITokenMessages.Add(ITokenMessage message)
  {
    if (!Contains(message)) {
      Add(message);
    }

    return this;
  }
}

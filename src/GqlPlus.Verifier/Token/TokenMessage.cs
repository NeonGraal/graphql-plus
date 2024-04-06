using System.Text.RegularExpressions;

namespace GqlPlus.Verifier.Token;

public record class TokenMessage(TokenKind Kind, int Column, int Line, string Next, string Message)
  : TokenAt(Kind, Column, Line, Next)
{
  [SuppressMessage("Design", "CA1062:Validate arguments of public methods")]
  public TokenMessage(TokenAt at, string message)
    : this(at.Kind, at.Column, at.Line, at.Next, message) { }

  public override string? ToString()
    => $"!!! {base.ToString()} : {Message} - '{Regex.Escape(Next)}' !!!";
}

internal class TokenMessages(
  params TokenMessage[] collection
) : List<TokenMessage>(collection), ITokenMessages
{
  public ITokenMessages Add(IEnumerable<TokenMessage> messages)
  {
    foreach (var message in messages) {
      Add(message);
    }

    return this;
  }
}

public interface ITokenMessages
  : IList<TokenMessage>
{
  ITokenMessages Add(IEnumerable<TokenMessage> messages);
}

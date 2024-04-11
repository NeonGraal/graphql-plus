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
  public static ITokenMessages New
    => new TokenMessages();

  ITokenMessages ITokenMessages.Add(IEnumerable<TokenMessage> messages)
    => messages.Aggregate(this as ITokenMessages, (a, m) => a.Add(m));

  ITokenMessages ITokenMessages.Add(TokenMessage message)
  {
    if (!Contains(message)) {
      Add(message);
    }

    return this;
  }

  void ITokenMessages.Clear() => Clear();
}

public interface ITokenMessages
  : IReadOnlyList<TokenMessage>
{
  void Clear();
  ITokenMessages Add(TokenMessage message);
  ITokenMessages Add(IEnumerable<TokenMessage> messages);
}

using System.Text.RegularExpressions;

namespace GqlPlus.Verifier.Token;

public record class TokenMessage(TokenKind Kind, int Column, int Line, string Next, string Message)
  : TokenAt(Kind, Column, Line, Next)
{
  public TokenMessage(TokenAt at, string message)
    : this(at.Kind, at.Column, at.Line, at.Next, message) { }

  public override string? ToString()
    => $"!!! {base.ToString()} : {Message} - '{Regex.Escape(Next)}' !!!";
}

internal class TokenMessages
  : List<TokenMessage>, ITokenMessages
{
  public void Add(ITokenMessages messages)
  {
    foreach (var message in messages) {
      Add(message);
    }
  }
}

public interface ITokenMessages : IList<TokenMessage>
{
  void Add(ITokenMessages messages);
}

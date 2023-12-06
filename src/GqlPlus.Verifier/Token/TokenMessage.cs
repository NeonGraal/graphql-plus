using System.Diagnostics.CodeAnalysis;
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

public class TokenMessages : List<TokenMessage>, ITokenMessages
{
  [SuppressMessage("Style", "IDE0025:Use expression body for property")]
  public static TokenMessages Empty { get => []; }
}

public interface ITokenMessages : IEnumerable<TokenMessage>;

namespace GqlPlus.Abstractions;

public enum ParseResultKind
{
  Failure,
  Success
}

public interface ITokenAt
{
  TokenKind Kind { get; }
  int Column { get; }
  int Line { get; }
  string After { get; }
}

public enum TokenKind
{
  Start,
  Identifer,
  Number,
  String,
  Regex,
  Punctuation,
  End
}

public interface ITokenMessage
  : ITokenAt, IMessage
{ }

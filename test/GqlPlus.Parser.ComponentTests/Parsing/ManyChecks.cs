using GqlPlus.Result;

namespace GqlPlus.Parsing;

internal sealed class ManyChecksParser<T>
{
  private readonly Parser<T>.LA _parser;
  private readonly string _type = typeof(T).ToString();

  public ManyChecksParser(Parser<T>.DA parser)
    => _parser = parser;

  internal void TrueExpected(string input, bool skipIf, params T[] expected)
  {
    Skip.If(skipIf);

    TrueExpected(input, expected);
  }

  internal void TrueExpected(string input, params T[] expected)
  {
    IResultArray<T> result = _parser.Parse(Tokens(input), _type);

    result.IsOk().Should().BeTrue(_type);
    using AssertionScope scope = new();
    result.Required().Should().Equal(expected);
  }

  internal void False(string input)
  {
    IResultArray<T> result = _parser.Parse(Tokens(input), _type);

    using AssertionScope scope = new();
    result.IsError(message => message.Message.Contains("Expected", StringComparison.InvariantCulture)).Should().BeTrue(_type);
  }

  internal void Count(string input, int count)
  {
    IResultArray<T> result = _parser.Parse(Tokens(input), _type);

    result.IsOk().Should().BeTrue(_type);
    using AssertionScope scope = new();
    result.Required().Count().Should().Be(count);
  }
}

internal sealed class ManyChecksParser<I, T>
where I : Parser<T>.IA
{
  private readonly ParserArray<I, T>.LA _parser;
  private readonly string _type = typeof(I).ToString();

  public ManyChecksParser(ParserArray<I, T>.DA parser)
    => _parser = parser;

  internal void TrueExpected(string input, params T[] expected)
  {
    IResultArray<T> result = _parser.I.Parse(Tokens(input), _type);

    result.IsOk().Should().BeTrue(_type);
    using AssertionScope scope = new();
    result.Required().Should().Equal(expected);
  }

  internal void False(string input)
  {
    IResultArray<T> result = _parser.I.Parse(Tokens(input), _type);

    using AssertionScope scope = new();
    result.IsError(message => message.Message.Contains("Expected", StringComparison.InvariantCulture)).Should().BeTrue(_type);
  }

  internal void Count(string input, int count)
  {
    IResultArray<T> result = _parser.I.Parse(Tokens(input), _type);

    result.IsOk().Should().BeTrue(_type);
    using AssertionScope scope = new();
    result.Required().Count().Should().Be(count);
  }
}

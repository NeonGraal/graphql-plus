namespace GqlPlus.Verifier.Parse;

internal sealed class ManyChecksParser<T>
{
  private readonly Parser<T>.LA _parser;
  private readonly string _type = typeof(T).ToString();

  public ManyChecksParser(Parser<T>.DA parser)
    => _parser = parser;

  internal void TrueExpected(string input, bool skipIf, params T[] expected)
  {
    if (!skipIf) {
      TrueExpected(input, expected);
    }
  }

  internal void TrueExpected(string input, params T[] expected)
  {
    var result = _parser.Parse(Tokens(input), _type);

    result.IsOk().Should().BeTrue(_type);
    using var scope = new AssertionScope();
    result.Required().Should().Equal(expected);
  }

  internal void False(string input)
  {
    var result = _parser.Parse(Tokens(input), _type);

    using var scope = new AssertionScope();
    result.IsError(message => message.Message.Contains("Expected")).Should().BeTrue(_type);
  }

  internal void Count(string input, int count)
  {
    var result = _parser.Parse(Tokens(input), _type);

    result.IsOk().Should().BeTrue(_type);
    using var scope = new AssertionScope();
    result.Required().Length.Should().Be(count);
  }
}

internal sealed class ManyChecksParser<I, T>
where I : Parser<T>.IA
{
  private readonly ParserArray<I, T>.LA _parser;
  private readonly string _type = typeof(I).ToString();

  public ManyChecksParser(ParserArray<I, T>.DA parser)
    => _parser = parser;

  internal void TrueExpected(string input, bool skipIf, params T[] expected)
  {
    if (!skipIf) {
      TrueExpected(input, expected);
    }
  }

  internal void TrueExpected(string input, params T[] expected)
  {
    var result = _parser.I.Parse(Tokens(input), _type);

    result.IsOk().Should().BeTrue(_type);
    using var scope = new AssertionScope();
    result.Required().Should().Equal(expected);
  }

  internal void False(string input)
  {
    var result = _parser.I.Parse(Tokens(input), _type);

    using var scope = new AssertionScope();
    result.IsError(message => message.Message.Contains("Expected")).Should().BeTrue(_type);
  }

  internal void Count(string input, int count)
  {
    var result = _parser.I.Parse(Tokens(input), _type);

    result.IsOk().Should().BeTrue(_type);
    using var scope = new AssertionScope();
    result.Required().Length.Should().Be(count);
  }
}

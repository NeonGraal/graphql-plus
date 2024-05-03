using GqlPlus.Verifier.Result;

namespace GqlPlus.Verifier.Parse;

internal sealed class CheckMany<T>(Parser<T>.DA parser)
{
  private readonly Parser<T>.LA _parser = parser;
  private readonly string _type = typeof(T).ToString();

  internal void TrueExpected(string input, bool skipIf, params T[] expected)
  {
    Skip.If(skipIf);

    TrueExpected(input, expected);
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
    result.IsError(message => message.Message.Contains("Expected", StringComparison.InvariantCulture)).Should().BeTrue(_type);
  }

  internal void Count(string input, int count)
  {
    var result = _parser.Parse(Tokens(input), _type);

    result.IsOk().Should().BeTrue(_type);
    using var scope = new AssertionScope();
    result.Required().Length.Should().Be(count);
  }
}

internal sealed class CheckMany<I, T>
where I : Parser<T>.IA
{
  private readonly ParserArray<I, T>.LA _parser;
  private readonly string _type = typeof(I).ToString();

  public CheckMany(ParserArray<I, T>.DA parser)
    => _parser = parser;

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
    result.IsError(message => message.Message.Contains("Expected", StringComparison.InvariantCulture)).Should().BeTrue(_type);
  }

  internal void Count(string input, int count)
  {
    var result = _parser.I.Parse(Tokens(input), _type);

    result.IsOk().Should().BeTrue(_type);
    using var scope = new AssertionScope();
    result.Required().Length.Should().Be(count);
  }
}

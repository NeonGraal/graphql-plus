using GqlPlus.Parsing;
using GqlPlus.Result;

namespace GqlPlus;

internal class ManyChecksParser<TResult>(
  Parser<TResult>.DA parser
) : IManyChecksParser<TResult>
{
  private readonly Parser<TResult>.LA _parser = parser;
  private readonly string _type = typeof(TResult).ToString();

  public void TrueExpected(string input, params TResult[] expected)
  {
    IResultArray<TResult> result = _parser.Parse(Tokens(input), _type);

    result.IsOk().Should().BeTrue(_type);
    using AssertionScope scope = new();
    result.Required().Should().Equal(expected);
  }

  public void FalseExpected(string input)
  {
    IResultArray<TResult> result = _parser.Parse(Tokens(input), _type);

    using AssertionScope scope = new();
    result.IsError(message => message.Message.Contains("Expected", StringComparison.InvariantCulture)).Should().BeTrue(_type);
  }

  public void Count(string input, int count)
  {
    IResultArray<TResult> result = _parser.Parse(Tokens(input), _type);

    result.IsOk().Should().BeTrue(_type);
    using AssertionScope scope = new();
    result.Required().Count().Should().Be(count);
  }
}

internal sealed class ManyChecksParser<TInterface, TResult>(
  ParserArray<TInterface, TResult>.DA parser
) : IManyChecksParser<TInterface, TResult>
  where TInterface : Parser<TResult>.IA
{
  private readonly ParserArray<TInterface, TResult>.LA _parser = parser;
  private readonly string _type = typeof(TInterface).ToString();

  public void TrueExpected(string input, params TResult[] expected)
  {
    IResultArray<TResult> result = _parser.I.Parse(Tokens(input), _type);

    result.IsOk().Should().BeTrue(_type);
    using AssertionScope scope = new();
    result.Required().Should().Equal(expected);
  }

  public void FalseExpected(string input)
  {
    IResultArray<TResult> result = _parser.I.Parse(Tokens(input), _type);

    using AssertionScope scope = new();
    result.IsError(message => message.Message.Contains("Expected", StringComparison.InvariantCulture)).Should().BeTrue(_type);
  }

  public void Count(string input, int count)
  {
    IResultArray<TResult> result = _parser.I.Parse(Tokens(input), _type);

    result.IsOk().Should().BeTrue(_type);
    using AssertionScope scope = new();
    result.Required().Count().Should().Be(count);
  }
}

public interface IManyChecksParser<T>
{
  void TrueExpected(string input, params T[] expected);
  void FalseExpected(string input);
  void Count(string input, int count);
}

public interface IManyChecksParser<TInterface, TResult>
  : IManyChecksParser<TResult>
  where TInterface : Parser<TResult>.IA
{ }

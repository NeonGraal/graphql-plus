using GqlPlus.Result;

namespace GqlPlus.Parsing;

internal class OneChecksParser<TResult>(
  Parser<TResult>.D parser
) : IOneChecksParser<TResult>
{
  private readonly Parser<TResult>.L _parser = parser;
  private readonly string _type = typeof(TResult).ToString();

  public void TrueExpected(string input, TResult expected)
  {
    Token.Tokenizer tokens = Tokens(input);
    IResult<TResult> result = _parser.Parse(tokens, "Test");

    using AssertionScope scope = new();
    scope.FormattingOptions.MaxDepth = 10;
    result.IsOk().Should().BeTrue(_type + " -> " + input);
    scope.FormattingOptions.MaxDepth = 10;
    tokens.Errors.Should().BeEmpty();
    result.Required().Should().Be(expected);
  }

  public void FalseExpected(string input, Action<TResult?>? check = null)
  {
    IResult<TResult> result = _parser.Parse(Tokens(input), "Test");

    using AssertionScope scope = new();
    scope.FormattingOptions.MaxDepth = 10;
    if (result.IsEmpty()) {
      return;
    }

    result.IsError(message => message.Message.Contains("Expected", StringComparison.InvariantCulture)).Should().BeTrue(_type + " -> " + input);
    result.Optional(result => check?.Invoke(result));
  }

  public void OkResult(string input, TResult expected)
  {
    Token.Tokenizer tokens = Tokens(input);
    IResult<TResult> result = _parser.Parse(tokens, "Test");

    using AssertionScope scope = new();
    scope.FormattingOptions.MaxDepth = 10;
    result.IsOk().Should().BeTrue(_type + " -> " + input);
    tokens.Errors.Should().BeEmpty();
    result.Required().Should().Be(expected);
  }

  public void EmptyResult(string input)
  {
    Token.Tokenizer tokens = Tokens(input);
    IResult<TResult> result = _parser.Parse(tokens, "Test");

    using AssertionScope scope = new();
    scope.FormattingOptions.MaxDepth = 10;
    result.IsEmpty().Should().BeTrue(_type + " -> " + input);
    tokens.Errors.Should().BeEmpty();
  }

  public void ErrorResult(string input, string errorMessage)
  {
    IResult<TResult> result = _parser.Parse(Tokens(input), "Test");

    using AssertionScope scope = new();
    scope.FormattingOptions.MaxDepth = 10;
    result.IsError(message => message.Message.Contains(errorMessage, StringComparison.InvariantCulture)).Should().BeTrue(_type + " -> " + input);
  }
}

internal sealed class OneChecksParser<TInterface, TResult>(
  Parser<TInterface, TResult>.D parser
) : IOneChecksParser<TInterface, TResult>
  where TInterface : Parser<TResult>.I
{
  private readonly Parser<TInterface, TResult>.L _parser = parser;
  private readonly string _type = typeof(TInterface).ToString();

  public void TrueExpected(string input, TResult expected)
  {
    Token.Tokenizer tokens = Tokens(input);
    IResult<TResult> result = _parser.I.Parse(tokens, "Test");

    using AssertionScope scope = new();
    scope.FormattingOptions.MaxDepth = 10;
    result.IsOk().Should().BeTrue(_type + " -> " + input);
    scope.FormattingOptions.MaxDepth = 10;
    tokens.Errors.Should().BeEmpty();
    result.Required().Should().Be(expected);
  }

  public void FalseExpected(string input, Action<TResult?>? check = null)
  {
    IResult<TResult> result = _parser.I.Parse(Tokens(input), "Test");

    using AssertionScope scope = new();
    scope.FormattingOptions.MaxDepth = 10;
    result.IsError(message => message.Message.Contains("Expected", StringComparison.InvariantCulture)).Should().BeTrue(_type + " -> " + input);
    result.Optional(result => check?.Invoke(result));
  }

  public void EmptyResult(string input)
  {
    Token.Tokenizer tokens = Tokens(input);
    IResult<TResult> result = _parser.I.Parse(tokens, "Test");

    using AssertionScope scope = new();
    scope.FormattingOptions.MaxDepth = 10;
    result.IsEmpty().Should().BeTrue(_type + " -> " + input);
    tokens.Errors.Should().BeEmpty();
  }
}

public interface IOneChecksParser<TResult>
{
  void TrueExpected(string input, TResult expected);
  void FalseExpected(string input, Action<TResult?>? check = null);

  void OkResult(string input, TResult expected);
  void EmptyResult(string input);
  void ErrorResult(string input, string errorMessage);
}

public interface IOneChecksParser<TInterface, TResult>
  where TInterface : Parser<TResult>.I
{
  void TrueExpected(string input, TResult expected);
  void FalseExpected(string input, Action<TResult?>? check = null);

  void EmptyResult(string input);
}

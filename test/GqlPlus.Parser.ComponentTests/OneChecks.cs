using GqlPlus.Parsing;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus;

internal class OneChecksParser<TResult>(
  Parser<TResult>.D parser
) : IOneChecksParser<TResult>
{
  private readonly Parser<TResult>.L _parser = parser;
  private readonly string _type = typeof(TResult).ToString();

  public void TrueExpected(string input, TResult expected)
  {
    ITokenizer tokens = Tokens(input);
    IResult<TResult> result = _parser.Parse(tokens, "Test");

    result.ShouldSatisfyAllConditions(_type + " -> " + input,
      r => r.IsOk().ShouldBeTrue(),
      _ => tokens.Errors.ShouldBeEmpty(),
      r => r.Required().ShouldBe(expected));
  }

  public void FalseExpected(string input, Action<TResult?>? check = null)
  {
    IResult<TResult> result = _parser.Parse(Tokens(input), "Test");

    if (result.IsEmpty()) {
      return;
    }

    result.ShouldSatisfyAllConditions(_type + " -> " + input,
      r => r.IsError(message => message.Message.Contains("Expected", StringComparison.InvariantCulture)).ShouldBeTrue(),
      r => r.Optional(result => check?.Invoke(result)));
  }

  public void OkResult(string input, TResult expected)
  {
    ITokenizer tokens = Tokens(input);
    IResult<TResult> result = _parser.Parse(tokens, "Test");

    result.ShouldSatisfyAllConditions(_type + " -> " + input,
      r => r.IsOk().ShouldBeTrue(),
      _ => tokens.Errors.ShouldBeEmpty(),
      r => r.Required().ShouldBe(expected));
  }

  public void EmptyResult(string input)
  {
    ITokenizer tokens = Tokens(input);
    IResult<TResult> result = _parser.Parse(tokens, "Test");

    result.ShouldSatisfyAllConditions(_type + " -> " + input,
      r => r.IsEmpty().ShouldBeTrue(),
      _ => tokens.Errors.ShouldBeEmpty());
  }

  public void ErrorResult(string input, string errorMessage)
  {
    IResult<TResult> result = _parser.Parse(Tokens(input), "Test");

    result.IsError(message => message.Message.Contains(errorMessage, StringComparison.InvariantCulture)).ShouldBeTrue(_type + " -> " + input);
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
    ITokenizer tokens = Tokens(input);
    IResult<TResult> result = _parser.I.Parse(tokens, "Test");

    result.ShouldSatisfyAllConditions(_type + " -> " + input,
      r => r.IsOk().ShouldBeTrue(),
      _ => tokens.Errors.ShouldBeEmpty(),
      r => r.Required().ShouldBe(expected));
  }

  public void FalseExpected(string input, Action<TResult?>? check = null)
  {
    IResult<TResult> result = _parser.I.Parse(Tokens(input), "Test");

    result.ShouldSatisfyAllConditions(_type + " -> " + input,
      r => r.IsError(message => message.Message.Contains("Expected", StringComparison.InvariantCulture)).ShouldBeTrue(),
      r => r.Optional(result => check?.Invoke(result)));
  }

  public void EmptyResult(string input)
  {
    ITokenizer tokens = Tokens(input);
    IResult<TResult> result = _parser.I.Parse(tokens, "Test");

    result.ShouldSatisfyAllConditions(_type + " -> " + input,
      r => r.IsEmpty().ShouldBeTrue(),
      _ => tokens.Errors.ShouldBeEmpty());
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

using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

internal class OptionParser<TOption>(
  Parser<IEnumParser<TOption>, TOption>.D parser
) : IOptionParser<TOption>
  where TOption : struct
{
  private readonly Parser<IEnumParser<TOption>, TOption>.L _parser = parser;

  public IResult<TOption> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    if (tokens.Take('(')) {
      var enumResult = _parser.I.Parse(tokens, label);

      return enumResult.Map(result =>
        tokens.Take(')')
          ? enumResult
          : tokens.Partial(label, "')' after option", () => result));
    }

    return 0.Empty<TOption>();
  }
}

public interface IOptionParser<TOption>
  : Parser<TOption>.I
  where TOption : struct
{ }

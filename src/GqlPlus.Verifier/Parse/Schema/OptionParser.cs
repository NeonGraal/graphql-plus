using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

internal class OptionParser<O>(
  Parser<IEnumParser<O>, O>.D parser
) : IOptionParser<O>
  where O : struct
{
  private readonly Parser<IEnumParser<O>, O>.L _parser = parser;

  public IResult<O> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    if (tokens.Take('(')) {
      var enumResult = _parser.I.Parse(tokens, label);

      return enumResult.Map(result =>
        tokens.Take(')')
          ? enumResult
          : tokens.Partial(label, "')' after option", () => result));
    }

    return 0.Empty<O>();
  }
}

public interface IOptionParser<O>
  : Parser<O>.I
  where O : struct
{ }

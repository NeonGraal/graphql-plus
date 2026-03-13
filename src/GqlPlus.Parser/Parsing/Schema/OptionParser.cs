using GqlPlus.Parsing.Schema.Simple;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema;

internal class OptionParser<TOption>(
  IParserRepository parsers
) : IOptionParser<TOption>
  where TOption : struct
{
  private readonly Parser<IEnumParser<TOption>, TOption>.L _parser = parsers.ParserFor<IEnumParser<TOption>, TOption>();

  public IResult<TOption> Parse(ITokenizer tokens, string label)

  {
    if (tokens.Take('(')) {
      IResult<TOption> enumResult = _parser.I.Parse(tokens, label);

      return enumResult.Map(result =>
        tokens.Take(')')
          ? enumResult
          : tokens.Partial(label, "')' after option", () => result));
    }

    return default(TOption).Empty();
  }
}

public interface IOptionParser<TOption>
  : Parser<TOption>.I
  where TOption : struct
{ }

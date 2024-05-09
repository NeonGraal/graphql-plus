using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing;

internal class ParseDefault(
  Parser<IGqlpConstant>.D constant
) : IParserDefault
{
  private readonly Parser<IGqlpConstant>.L _constant = constant;

  public IResult<IGqlpConstant> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
    => tokens.Take('=') ? _constant.Parse(tokens, "Default").MapEmpty(
          () => tokens.Error<IGqlpConstant>("Default", "value after '='")
        ) : 0.Empty<IGqlpConstant>();
}

public interface IParserDefault
  : Parser<IGqlpConstant>.I
{ }

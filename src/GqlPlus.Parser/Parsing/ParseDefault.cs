using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing;

internal class ParseDefault(
  IParserRepository parsers
) : IParserDefault
{
  private readonly Parser<IGqlpConstant>.L _constant = parsers.ParserFor<IGqlpConstant>();

  public IResult<IGqlpConstant> Parse(ITokenizer tokens, string label)

    => tokens.Take('=') ? _constant.Parse(tokens, "Default").MapEmpty(
          () => tokens.Error<IGqlpConstant>("Default", "value after '='")
        ) : default(IGqlpConstant).Empty();
}

public interface IParserDefault
  : Parser<IGqlpConstant>.I
{ }

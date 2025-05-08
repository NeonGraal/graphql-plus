using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing;

internal class ParseDefault(
  Parser<IGqlpConstant>.D constant
) : IParserDefault
{
  private readonly Parser<IGqlpConstant>.L _constant = constant;

  public IResult<IGqlpConstant> Parse(ITokenizer tokens, string label)

    => tokens.Take('=') ? _constant.Parse(tokens, "Default").MapEmpty(
          () => tokens.Error<IGqlpConstant>("Default", "value after '='")
        ) : 0.Empty<IGqlpConstant>();
}

public interface IParserDefault
  : Parser<IGqlpConstant>.I
{ }

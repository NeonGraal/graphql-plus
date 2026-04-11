using GqlPlus.Ast;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing;

internal class ParseDefault(
  IParserRepository parsers
) : IParserDefault
{
  private readonly Parser<IAstConstant>.L _constant = parsers.ParserFor<IAstConstant>();

  public IResult<IAstConstant> Parse(ITokenizer tokens, string label)

    => tokens.Take('=') ? _constant.Parse(tokens, "Default").MapEmpty(
          () => tokens.Error<IAstConstant>("Default", "value after '='")
        ) : default(IAstConstant).Empty();
}

public interface IParserDefault
  : Parser<IAstConstant>.I
{ }

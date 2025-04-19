using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Operation;

internal class ParseVarType : IParserVarType
{
  public IResult<string> Parse(ITokenizer tokens, string label)

=> ParseVarNull(tokens).Select(nullType
      => tokens.Take('!') ? nullType + '!' : nullType);

  internal IResult<string> ParseVarNull(ITokenizer tokens)
  {
    if (tokens.Take('[')) {
      return Parse(tokens, "Variable Type").MapOk(
        varType => tokens.Take(']')
          ? $"[{varType}]".Ok()
          : tokens.Partial("Variable Type", "an inner variable type", () => varType),
        () => tokens.Error("Variable Type", "an inner variable type", ""));
    } else if (tokens.Identifier(out string? varNull)) {
      return varNull.Ok();
    }

    return "".Empty();
  }
}

public interface IParserVarType : Parser<string>.I { }

namespace GqlPlus.Verifier.Parse.Operation;

internal class ParseVarType : IParserVarType
{
  public IResult<string> Parse(Tokenizer tokens)
=> ParseVarNull(tokens).Select(nullType
      => tokens.Take('!') ? nullType + '!' : nullType);

  internal IResult<string> ParseVarNull(Tokenizer tokens)
  {
    if (tokens.Take('[')) {
      return Parse(tokens).MapOk(
        varType => tokens.Take(']')
          ? $"[{varType}]".Ok()
          : tokens.Partial("Variable Type", "an inner variable type", varType),
        () => tokens.Error("Variable Type", "an inner variable type", ""));
    } else if (tokens.Identifier(out var varNull)) {
      return varNull.Ok();
    }

    return "".Empty();
  }
}

public interface IParserVarType : IParser<string> { }

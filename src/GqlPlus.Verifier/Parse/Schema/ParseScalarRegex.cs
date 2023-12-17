using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseScalarRegex : Parser<ScalarRegexAst>.I
{
  public IResult<ScalarRegexAst> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    ScalarRegexAst? result = null;
    var at = tokens.At;
    if (tokens.Regex(out var regex)) {
      var excluded = tokens.Take('!');
      result = new(at, regex, excluded);
      return result.Ok();
    }

    return result.Empty();
  }
}

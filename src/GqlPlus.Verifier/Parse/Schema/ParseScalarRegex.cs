using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseScalarRegex : Parser<ScalarRegexAst>.I
{
  public IResult<ScalarRegexAst> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    var at = tokens.At;
    ScalarRegexAst? result;
    if (tokens.Regex(out var regex)) {
      var excluded = tokens.Take('!');
      result = new(at, regex, excluded);
      return result.Ok();
    }

    result = new(at, regex, false);
    return string.IsNullOrEmpty(regex)
      ? result.Empty()
      : tokens.Error(label, "Closing '/'", result);
  }
}

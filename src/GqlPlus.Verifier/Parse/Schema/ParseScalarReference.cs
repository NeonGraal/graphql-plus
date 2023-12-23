using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseScalarReference : Parser<ScalarReferenceAst>.I
{
  public IResult<ScalarReferenceAst> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    ScalarReferenceAst? result = null;
    var at = tokens.At;
    if (tokens.Take('|')) {
      if (tokens.Identifier(out var name)) {
        result = new(at, name);
        return result.Ok();
      }

      return tokens.Error(label, "reference after '|'", result);
    }

    return result.Empty();
  }
}

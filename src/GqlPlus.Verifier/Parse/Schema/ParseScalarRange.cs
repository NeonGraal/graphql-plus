using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseScalarRange : Parser<ScalarRangeAst>.I
{
  public IResult<ScalarRangeAst> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    var at = tokens.At;
    var excludes = tokens.Take('!');

    var range = new ScalarRangeAst(at, excludes);
    var isUpper = tokens.Take('<');
    var hasLower = tokens.Number(out var min);

    if (isUpper) {
      range.Upper = min;
      return hasLower
        ? range.Ok()
        : tokens.Error(label, "upper bound after '<'", range);
    }

    range.Lower = min;
    if (tokens.Take('>')) {
      return hasLower
        ? range.Ok()
        : tokens.Error(label, "lower bound before '>'", range);
    }

    if (!tokens.Take('~')) {
      range.Upper = min;
      return hasLower
        ? range.Ok()
        : range.Empty();
    }

    if (!hasLower) {
      return tokens.Error(label, "lower bound before '~'", range);
    }

    var hasUpper = tokens.Number(out var max);
    range.Upper = max;
    return hasUpper
      ? range.Ok()
      : tokens.Error(label, "upper bound after '~'", range);
  }
}

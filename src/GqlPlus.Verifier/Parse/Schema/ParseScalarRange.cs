using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseScalarRange : Parser<ScalarRangeNumberAst>.I
{
  public IResult<ScalarRangeNumberAst> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    var at = tokens.At;
    var excludes = tokens.Take('!');

    var range = new ScalarRangeNumberAst(at, excludes);
    var hasLower = tokens.Number(out var min);
    var hasRange = tokens.Take('~');
    if (hasLower && !hasRange) {
      return tokens.Error(label, "range operator ('~')", range);
    }

    var hasUpper = tokens.Number(out var max);

    if (hasLower) {
      range.Lower = min;
    }

    if (hasUpper) {
      range.Upper = max;
    }

    return hasLower || hasUpper
      ? range.Ok()
      : hasRange
        ? tokens.Error(label, "min or max bounds", range)
        : range.Empty();
  }
}

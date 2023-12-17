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
    var range = new ScalarRangeAst(at);
    var hasLower = tokens.Number(out var min);
    var excludesLower = tokens.Take('>');
    var hasRange = tokens.Take(':');
    if (hasLower && !hasRange) {
      return tokens.Error(label, "range operator (':')", range);
    }

    var excludesUpper = tokens.Take('<');
    var hasUpper = tokens.Number(out var max);

    if (hasLower) {
      range.Lower = min;
      range.LowerExcluded = excludesLower;
    }

    if (hasUpper) {
      range.Upper = max;
      range.UpperExcluded = excludesUpper;
    }

    return hasLower || hasUpper
      ? range.Ok()
      : hasRange
        ? tokens.Error(label, "min or max bounds", range)
        : range.Empty();
  }
}

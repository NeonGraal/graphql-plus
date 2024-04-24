using GqlPlus.Verifier.Ast.Schema.Simple;
using GqlPlus.Verifier.Result;

namespace GqlPlus.Verifier.Parse.Schema.Simple;

internal class ParseDomainRange(
  Parser<DomainRangeAst>.DA items
) : ParseDomainItem<DomainRangeAst>(items)
{
  public override DomainKind Kind => DomainKind.Number;

  public override IResult<DomainRangeAst> Parse<TContext>(TContext tokens, string label)
  {
    var at = tokens.At;
    var excludes = tokens.Take('!');

    var range = new DomainRangeAst(at, excludes);
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

  protected override void ApplyItems(DomainDefinition result, DomainRangeAst[] items)
    => result.Numbers = items;
}

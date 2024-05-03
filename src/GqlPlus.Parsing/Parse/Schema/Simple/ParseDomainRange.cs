using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Result;

namespace GqlPlus.Parse.Schema.Simple;

internal class ParseDomainRange(
  Parser<DomainRangeAst>.DA items
) : ParseDomainItem<DomainRangeAst>(items)
{
  public override DomainKind Kind => DomainKind.Number;

  public override IResult<DomainRangeAst> Parse<TContext>(TContext tokens, string label)
  {
    Token.TokenAt at = tokens.At;
    bool excludes = tokens.Take('!');

    DomainRangeAst range = new(at, excludes);
    bool isUpper = tokens.Take('<');
    bool hasLower = tokens.Number(out decimal min);

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

    bool hasUpper = tokens.Number(out decimal max);
    range.Upper = max;
    return hasUpper
      ? range.Ok()
      : tokens.Error(label, "upper bound after '~'", range);
  }

  protected override void ApplyItems(DomainDefinition result, DomainRangeAst[] items)
    => result.Numbers = items;
}

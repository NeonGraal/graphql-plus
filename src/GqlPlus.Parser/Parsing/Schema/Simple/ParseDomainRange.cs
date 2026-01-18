using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Simple;

internal class ParseDomainRange(
  Parser<IGqlpDomainRange>.DA items
) : ParseDomainItem<IGqlpDomainRange>(items)
{
  public override DomainKind Kind => DomainKind.Number;

  public override IResult<IGqlpDomainRange> Parse(ITokenizer tokens, string label)
  {
    string description = tokens.Description();
    TokenAt at = tokens.At;
    bool excludes = tokens.Take('!');

    DomainRangeAst value = new(at, description, excludes);
    IGqlpDomainRange range = value;
    bool isUpper = tokens.Take('<');
    bool hasLower = tokens.Number(out decimal min);

    if (isUpper) {
      range = value with { Upper = min };
      return LowerOr(() => tokens.Error(label, "upper bound after '<'", range));
    }

    range = value = value with { Lower = min };
    if (tokens.Take('>')) {
      return LowerOr(() => tokens.Error(label, "lower bound before '>'", range));
    }

    if (!tokens.Take('~')) {
      range = value with { Upper = min };
      return LowerOr(() => range.Empty());
    }

    if (!hasLower) {
      return tokens.Error(label, "lower bound before '~'", range);
    }

    bool hasUpper = tokens.Number(out decimal max);
    range = value with { Upper = max };
    return hasUpper
      ? range.Ok()
      : tokens.Error(label, "upper bound after '~'", range);

    IResult<IGqlpDomainRange> LowerOr(Func<IResult<IGqlpDomainRange>> error)
      => hasLower
        ? range.Ok()
        : error();
  }

  protected override void ApplyItems(ITokenizer tokens, string label, DomainDefinition result, IGqlpDomainRange[] items)
    => result.Numbers = items.ArrayOf<DomainRangeAst>();
}

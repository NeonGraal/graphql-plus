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
    bool hasFirstChar = tokens.TakeAny(out char firstChar, '<', '>');
    bool hasFirst = tokens.Number(out decimal first);

    if (hasFirstChar) {
      if (firstChar == '<') {
        range = value with { Upper = first };
      } else {
        range = value with { Lower = first };
      }

      return FirstOr(() => tokens.Error(label, "bound after '<' or '>'", range));
    }

    if (!tokens.TakeAny(out char secondChar, '<', '>')) {
      range = value with { Lower = first, Upper = first };
      return FirstOr(() => range.Empty());
    }

    if (!hasFirst) {
      return tokens.Error(label, "value or first bound", range);
    }

    bool hasSecond = tokens.Number(out decimal second);
    if (secondChar == '<') {
      range = value = value with { Lower = first };
      if (hasSecond) {
        range = value with { Upper = second };
      }
    } else {
      range = value = value with { Upper = first };
      if (hasSecond) {
        range = value with { Lower = second };
      }
    }

    return range.Ok();

    IResult<IGqlpDomainRange> FirstOr(Func<IResult<IGqlpDomainRange>> error)
      => hasFirst
        ? range.Ok()
        : error();
  }

  protected override void ApplyItems(
    ITokenizer tokens,
    string label,
    DomainDefinition result,
    IGqlpDomainRange[] items
  ) => result.Numbers = items.ArrayOf<DomainRangeAst>();
}

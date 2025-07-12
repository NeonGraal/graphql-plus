using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Simple;

internal class ParseDomainLabel(
  Parser<IGqlpDomainLabel>.DA items
) : ParseDomainItem<IGqlpDomainLabel>(items)
{
  public override DomainKind Kind => DomainKind.Enum;

  public override IResult<IGqlpDomainLabel> Parse(ITokenizer tokens, string label)
  {
    string description = tokens.Description();
    TokenAt at = tokens.At;
    bool excluded = tokens.Take('!');
    bool hasType = tokens.Identifier(out string? enumType);
    IGqlpDomainLabel result = new DomainLabelAst(at, description, excluded, enumType.IfWhitespace());
    if (!hasType) {
      return excluded
        ? tokens.Partial(label, "identifier after '!'", () => result)
        : result.Empty();
    }

    if (tokens.Take('.')) {
      if (tokens.Identifier(out string? enumItem)) {
        result = new DomainLabelAst(at, description, excluded, enumItem) { EnumType = enumType! };
      } else if (tokens.Take('*')) {
        result = new DomainLabelAst(at, description, excluded, "*") { EnumType = enumType! };
      } else {
        return tokens.Partial(label, "identifier or '*' after '.'", () => result);
      }
    }

    return result.Ok();
  }

  protected override void ApplyItems(ITokenizer tokens, string label, DomainDefinition result, IGqlpDomainLabel[] items)
  {
    if (items.Length == 0) {
      tokens.Error<IGqlpDomainLabel>(label, "enum Labels");
    }

    result.Labels = items.ArrayOf<DomainLabelAst>();
  }
}

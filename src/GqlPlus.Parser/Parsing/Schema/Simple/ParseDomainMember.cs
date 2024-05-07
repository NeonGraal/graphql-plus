using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Result;

namespace GqlPlus.Parsing.Schema.Simple;

internal class ParseDomainMember(
  Parser<DomainMemberAst>.DA items
) : ParseDomainItem<DomainMemberAst>(items)
{
  public override DomainKind Kind => DomainKind.Enum;

  public override IResult<DomainMemberAst> Parse<TContext>(TContext tokens, string label)
  {
    Token.TokenAt at = tokens.At;
    DomainMemberAst? result;
    bool excluded = tokens.Take('!');
    bool hasType = tokens.Identifier(out string? type);
    result = new(at, excluded, type);
    if (!hasType) {
      return excluded
        ? tokens.Partial(label, "identifier after '!'", () => result)
        : result.Empty();
    }

    if (tokens.Take('.')) {
      if (tokens.Identifier(out string? member)) {
        result = new(at, excluded, member) { EnumType = type };
      } else if (tokens.Take("*")) {
        result = new(at, excluded, "*") { EnumType = type };
      } else {
        return tokens.Partial(label, "identifier or '*' after '.'", () => result);
      }
    }

    return result.Ok();
  }

  protected override void ApplyItems(DomainDefinition result, DomainMemberAst[] items)
    => result.Members = items;
}

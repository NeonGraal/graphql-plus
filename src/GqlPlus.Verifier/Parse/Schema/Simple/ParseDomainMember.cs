using GqlPlus.Verifier.Ast.Schema.Simple;
using GqlPlus.Verifier.Result;

namespace GqlPlus.Verifier.Parse.Schema.Simple;

internal class ParseDomainMember(
  Parser<DomainMemberAst>.DA items
) : ParseDomainItem<DomainMemberAst>(items)
{
  public override DomainDomain Kind => DomainDomain.Enum;

  public override IResult<DomainMemberAst> Parse<TContext>(TContext tokens, string label)
  {
    var at = tokens.At;
    DomainMemberAst? result;
    var excluded = tokens.Take('!');
    var hasType = tokens.Identifier(out var type);
    result = new(at, excluded, type);
    if (!hasType) {
      return excluded
        ? tokens.Partial(label, "identifier after '!'", () => result)
        : result.Empty();
    }

    if (tokens.Take('.')) {
      if (tokens.Identifier(out var member)) {
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

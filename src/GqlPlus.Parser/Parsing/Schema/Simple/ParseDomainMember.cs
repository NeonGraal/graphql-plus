using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Simple;

internal class ParseDomainMember(
  Parser<IGqlpDomainMember>.DA items
) : ParseDomainItem<IGqlpDomainMember>(items)
{
  public override DomainKind Kind => DomainKind.Enum;

  public override IResult<IGqlpDomainMember> Parse<TContext>(TContext tokens, string label)
  {
    Token.TokenAt at = tokens.At;
    bool excluded = tokens.Take('!');
    bool hasType = tokens.Identifier(out string? type);
    IGqlpDomainMember result = new DomainMemberAst(at, excluded, type);
    if (!hasType) {
      return excluded
        ? tokens.Partial(label, "identifier after '!'", () => result)
        : result.Empty();
    }

    if (tokens.Take('.')) {
      if (tokens.Identifier(out string? member)) {
        result = new DomainMemberAst(at, excluded, member) { EnumType = type };
      } else if (tokens.Take("*")) {
        result = new DomainMemberAst(at, excluded, "*") { EnumType = type };
      } else {
        return tokens.Partial(label, "identifier or '*' after '.'", () => result);
      }
    }

    return result.Ok();
  }

  protected override void ApplyItems(Tokenizer tokens, string label, DomainDefinition result, IGqlpDomainMember[] items)
  {
    if (items.Length == 0) {
      tokens.Error(label, "enum Members");
    }

    result.Members = items.ArrayOf<DomainMemberAst>();
  }
}

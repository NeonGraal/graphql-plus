using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseScalarMember(
  Parser<ScalarMemberAst>.DA items
) : ParseScalarItem<ScalarMemberAst>(items)
{
  public override ScalarKind Kind => ScalarKind.Enum;

  public override IResult<ScalarMemberAst> Parse<TContext>(TContext tokens, string label)
  {
    var at = tokens.At;
    ScalarMemberAst? result;
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

  protected override void ApplyItems(ScalarDefinition result, ScalarMemberAst[] items)
    => result.Members = items;
}

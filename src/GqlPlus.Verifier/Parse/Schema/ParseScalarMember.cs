using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseScalarMember : Parser<ScalarMemberAst>.I
{
  public IResult<ScalarMemberAst> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
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
      } else {
        return tokens.Partial(label, "identifier after '.'", () => result);
      }
    }

    return result.Ok();
  }
}

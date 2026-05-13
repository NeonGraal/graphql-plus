using GqlPlus.Ast.Schema;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema;

internal class ParseTypeRef
  : IParser<IAstTypeRef>
{
  public IResult<IAstTypeRef> Parse([NotNull] ITokenizer tokens, string label)

  {
    string description = tokens.Description();
    TokenAt at = tokens.At;
    if (tokens.Identifier(out string? name)) {
      IAstTypeRef result = new TypeRefAst(at, name, description);
      return result.Ok();
    } else {
      return tokens.Error<IAstTypeRef>(label, "type name");
    }
  }

  internal static ParseTypeRef Factory(IParserRepository _) => new();
}

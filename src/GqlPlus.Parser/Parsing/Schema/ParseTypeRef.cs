using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema;

internal class ParseTypeRef
  : Parser<IGqlpTypeRef>.I
{
  public IResult<IGqlpTypeRef> Parse(ITokenizer tokens, string label)

  {
    string description = tokens.Description();
    TokenAt at = tokens.At;
    if (tokens.Identifier(out string name)) {
      IGqlpTypeRef result = new TypeRefAst(at, name, description);
      return result.Ok();
    } else {
      return tokens.Error<IGqlpTypeRef>(label, "type name");
    }
  }
}

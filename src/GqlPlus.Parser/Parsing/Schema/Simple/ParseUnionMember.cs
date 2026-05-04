using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Simple;

internal class ParseUnionMember
  : Parser<IAstUnionMember>.I
{
  public IResult<IAstUnionMember> Parse(ITokenizer tokens, string label)

  {
    string description = tokens.Description();
    TokenAt at = tokens.At;
    return tokens.Identifier(out string? value)
      ? new UnionMemberAst(at, value, description).Ok<IAstUnionMember>()
      : tokens.Error<IAstUnionMember>(label, "member");
  }

  internal static ParseUnionMember Factory(IParserRepository _) => new();
}

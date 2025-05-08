using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Simple;

internal class ParseUnionMember
  : Parser<IGqlpUnionMember>.I
{
  public IResult<IGqlpUnionMember> Parse(ITokenizer tokens, string label)

  {
    string description = tokens.Description();
    TokenAt at = tokens.At;
    return tokens.Identifier(out string? value)
      ? new UnionMemberAst(at, value, description).Ok<IGqlpUnionMember>()
      : tokens.Error<IGqlpUnionMember>(label, "member");
  }
}

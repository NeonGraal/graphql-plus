using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parse.Schema.Simple;

internal class ParseUnionMember
  : Parser<UnionMemberAst>.I
{
  public IResult<UnionMemberAst> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    var at = tokens.At;

    return tokens.Identifier(out var value)
      ? new UnionMemberAst(at, value).Ok()
      : tokens.Error<UnionMemberAst>(label, "member");
  }
}

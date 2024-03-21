using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

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

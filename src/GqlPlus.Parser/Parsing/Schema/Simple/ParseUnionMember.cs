using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Simple;

internal class ParseUnionMember
  : Parser<UnionMemberAst>.I
{
  public IResult<UnionMemberAst> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    tokens.TakeDescription();
    TokenAt at = tokens.At;
    string description = tokens.GetDescription();

    return tokens.Identifier(out string? value)
      ? new UnionMemberAst(at, value, description).Ok()
      : tokens.Error<UnionMemberAst>(label, "member");
  }
}

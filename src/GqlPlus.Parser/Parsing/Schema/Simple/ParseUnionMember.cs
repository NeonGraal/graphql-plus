using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Simple;

internal class ParseUnionMember
  : Parser<IGqlpUnionItem>.I
{
  public IResult<IGqlpUnionItem> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    tokens.TakeDescription();
    TokenAt at = tokens.At;
    string description = tokens.GetDescription();

    return tokens.Identifier(out string? value)
      ? new UnionMemberAst(at, value, description).Ok<IGqlpUnionItem>()
      : tokens.Error<IGqlpUnionItem>(label, "member");
  }
}

using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseNull : IParser<NullAst>
{
  public IResult<NullAst> Parse<TContext>(TContext tokens)
    where TContext : Tokenizer
    => 0.Empty<NullAst>();
}

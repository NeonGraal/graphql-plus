using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseNull : Parser<NullAst>.I
{
  public IResult<NullAst> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
    => 0.Empty<NullAst>();
}

internal class ParseNulls : Parser<NullAst>.IA
{
  public IResultArray<NullAst> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
    => 0.EmptyArray<NullAst>();
}

internal enum NullOption { }

internal class ParseNullOption : IEnumParser<NullOption>, IOptionParser<NullOption>
{
  public IResult<NullOption> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
    => 0.Empty<NullOption>();
}

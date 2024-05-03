using GqlPlus.Ast;
using GqlPlus.Parse.Schema.Simple;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parse.Schema;

internal class ParseNull
  : Parser<NullAst>.I
{
  [ExcludeFromCodeCoverage]
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

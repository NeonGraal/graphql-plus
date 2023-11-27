namespace GqlPlus.Verifier.Parse;

public interface IParser<TResult>
{
  IResult<TResult> Parse<TContext>(TContext tokens)
    where TContext : Tokenizer;
}

public interface IParserArray<TResult>
{
  IResultArray<TResult> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer;
}

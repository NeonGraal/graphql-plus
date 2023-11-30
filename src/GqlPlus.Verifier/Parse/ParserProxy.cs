namespace GqlPlus.Verifier.Parse;

public class ParserProxy<T, C> : IParser<T>
  where C : Tokenizer
{
  public delegate IResult<T> Proxy(C context);

  private readonly Proxy _parser;

  public ParserProxy(Proxy parser)
    => _parser = parser;

  public IResult<T> Parse<TContext>(TContext tokens)
    where TContext : Tokenizer
    => tokens is C context ? _parser(context) : 0.Empty<T>();
}

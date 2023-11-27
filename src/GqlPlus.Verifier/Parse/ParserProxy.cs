namespace GqlPlus.Verifier.Parse.Schema;

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

public class ParserArrayProxy<T, C> : IParserArray<T>
  where C : Tokenizer
{
  public delegate IResultArray<T> Proxy(C context, string label);

  private readonly Proxy _parser;

  public ParserArrayProxy(Proxy parser)
    => _parser = parser;

  public IResultArray<T> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
    => tokens is C context ? _parser(context, label) : 0.EmptyArray<T>();
}

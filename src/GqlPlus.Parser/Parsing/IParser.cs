using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing;

public interface IParser<TResult>
{
  IResult<TResult> Parse(ITokenizer tokens)
    ;
}

public interface IParserArray<TResult>
{
  IResultArray<TResult> Parse(ITokenizer tokens, string label)
    ;
}

#pragma warning disable CA1034 // Nested types should not be visible
public static class Parser<T>
{
  public interface I
  {
    IResult<T> Parse(ITokenizer tokens, string label)
      ;
  }

  public interface IA
  {
    IResultArray<T> Parse(ITokenizer tokens, string label)
      ;
  }

  public delegate I D();
  public delegate IA DA();

  public class L(D factory) : Lazy<I>(() => factory())
  {
    public static implicit operator L(D factory) => new(factory.ThrowIfNull());

    public IResult<T> Parse(ITokenizer tokens, string label)

      => Value.Parse(tokens, label);
  }

  public class LA(DA factory) : Lazy<IA>(() => factory())
  {
    public static implicit operator LA(DA factory) => new(factory.ThrowIfNull());

    public IResultArray<T> Parse(ITokenizer tokens, string label)

      => Value.Parse(tokens, label);
  }
}

public static class Parser<TInterface, T>
  where TInterface : Parser<T>.I
{
  public delegate TInterface D();

  public class L(D factory) : Lazy<TInterface>(() => factory())
  {
    public static implicit operator L(D factory) => new(factory.ThrowIfNull());

    public TInterface I => Value;
  }
}

public static class ParserArray<TInterface, T>
  where TInterface : Parser<T>.IA
{
  public delegate TInterface DA();

  public class LA(DA factory) : Lazy<TInterface>(() => factory())
  {
    public static implicit operator LA(DA factory) => new(factory.ThrowIfNull());

    public TInterface I => Value;
  }
}

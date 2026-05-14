using GqlPlus.Parsing.Schema;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing;

public interface IParser<T>
{
  IResult<T> Parse([NotNull] ITokenizer tokens, string label);
}

public interface IParserArray<T>
{
  IResultArray<T> Parse([NotNull] ITokenizer tokens, string label);
}

public class ParserOne<T>(
  ParserOne<T>.D factory
) : DeferOne<IParser<T>>(factory)
  , IParser<T>
{
  public IResult<T> Parse([NotNull] ITokenizer tokens, string label)
    => Value.Parse(tokens, label);

  public static implicit operator ParserOne<T>(D factory)
    => new(factory.ThrowIfNull());
}

public class ParserArray<T>(
  ParserArray<T>.D factory
) : DeferOne<IParserArray<T>>(factory)
  , IParserArray<T>
{
  public IResultArray<T> Parse([NotNull] ITokenizer tokens, string label)
    => Value.Parse(tokens, label);

  public static implicit operator ParserArray<T>(D factory)
    => new(factory.ThrowIfNull());
}

public class ParserOne<TInterface, T>(
  ParserOne<TInterface, T>.D factory
) : DeferOne<TInterface>(factory)
  , IParser<T>
  where TInterface : class, IParser<T>
{
  public IResult<T> Parse([NotNull] ITokenizer tokens, string label)
    => Value.Parse(tokens, label);

  public static implicit operator ParserOne<TInterface, T>(D factory)
    => new(factory.ThrowIfNull());
}

public class ParserArray<TInterface, T>(
  ParserArray<TInterface, T>.D factory
) : DeferOne<TInterface>(factory)
  , IParserArray<T>
  where TInterface : class, IParserArray<T>
{
  public IResultArray<T> Parse([NotNull] ITokenizer tokens, string label)
    => Value.Parse(tokens, label);

  public static implicit operator ParserArray<TInterface, T>(D factory)
    => new(factory.ThrowIfNull());
}

public class ParserName<T>(
  ParserName<T>.D factory
) : DeferOne<T>(factory)
  , INameParser
  where T : class, INameParser
{
  public bool ParseName([NotNull] ITokenizer tokens, [NotNullWhen(true)] out string? name, out TokenAt at)
    => Value.ParseName(tokens, out name, out at);

  public static implicit operator ParserName<T>(D factory)
    => new(factory.ThrowIfNull());
}

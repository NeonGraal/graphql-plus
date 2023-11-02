namespace GqlPlus.Verifier;

public interface IParseResult<T>
{
  T? Value { get; }
}

public readonly struct ParseOk<T> : IParseResult<T>
{
  public T? Value { get; }

  public ParseOk(T result)
    => Value = result;
}

public readonly struct ParseError<T> : IParseResult<T>
{
  public T? Value => default;

  public ParseMessage Error { get; }

  public ParseError(ParseMessage error)
    => Error = error;
}

public readonly struct ParseEmpty<T> : IParseResult<T>
{
  public T? Value => default;
}

public readonly struct ParsePartial<T> : IParseResult<T>
{
  public T? Value { get; }
  public ParseMessage Error { get; }

  public ParsePartial(T partial, ParseMessage error)
    => (Value, Error) = (partial, error);
}

public static class ParseExtenstions
{
  public static bool IsError<T>(this IParseResult<T> result, Action<ParseMessage>? action = null)
  {
    if (result is ParseError<T> error) {
      action?.Invoke(error.Error);
      return true;
    }

    return false;
  }

  public static IParseResult<T[]> Ok<T>(this IEnumerable<T> result)
    => new ParseOk<T[]>(result.ToArray());
}

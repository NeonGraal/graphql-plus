using System;

namespace GqlPlus.Verifier;

public interface IParseResult<T> { }

public readonly struct ParseOk<T> : IParseResult<T>
{
  public T Result { get; }

  public ParseOk(T result)
    => Result = result;
}

public readonly struct ParseError<T> : IParseResult<T>
{
  public ParseMessage Error { get; }

  public ParseError(ParseMessage error)
    => Error = error;
}

public readonly struct ParseEmpty<T> : IParseResult<T> { }

public readonly struct ParsePartial<T> : IParseResult<T>
{
  public T? Result { get; }
  public ParseMessage Error { get; }

  public ParsePartial(T partial, ParseMessage error)
    => (Result, Error) = (partial, error);
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

  public static bool HasResult<T>(this IParseResult<T> result, out T? value)
  {
    if (result is ParseOk<T> ok) {
      value = ok.Result;
      return true;
    }

    value = default;
    return result is ParseEmpty<T>;
  }

  public static void WithResult<T>(this IParseResult<T> result, Action<T> action)
  {
    if (result is ParseOk<T> ok) {
      action.Invoke(ok.Result);
    }
  }

  public static IParseResult<T[]> Ok<T>(this IEnumerable<T> result)
    => new ParseOk<T[]>(result.ToArray());
}

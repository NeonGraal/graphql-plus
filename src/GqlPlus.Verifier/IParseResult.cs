using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Verifier;

public interface IParseResult<T>
{
  IParseResult<R> AsResult<R>();
}

public readonly struct ParseOk<T> : IParseResult<T>
{
  public T Result { get; }

  public ParseOk(T result)
  {
    ArgumentNullException.ThrowIfNull(result);
    Result = result;
  }

  public IParseResult<R> AsResult<R>()
    => Result is R newResult
      ? new ParseOk<R>(newResult)
      : new ParseEmpty<R>();
}

public readonly struct ParseError<T> : IParseResult<T>
{
  public ParseMessage Error { get; }

  public ParseError(ParseMessage error)
    => Error = error;

  public IParseResult<R> AsResult<R>()
    => new ParseError<R>(Error);
}

public readonly struct ParseEmpty<T> : IParseResult<T>
{
  public IParseResult<R> AsResult<R>()
    => new ParseEmpty<R>();
}

public readonly struct ParsePartial<T> : IParseResult<T>
{
  public T? Result { get; }
  public ParseMessage Error { get; }

  public ParsePartial(T partial, ParseMessage error)
    => (Result, Error) = (partial, error);

  public IParseResult<R> AsResult<R>()
    => Result is R newResult
      ? new ParsePartial<R>(newResult, Error)
      : new ParseError<R>(Error);
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

  public static bool Optional<T>(this IParseResult<T> result, out T? value)
  {
    if (result is ParseOk<T> ok) {
      value = ok.Result;
      return true;
    }

    value = default;
    return result is ParseEmpty<T>;
  }

  public static bool Required<T>(this IParseResult<T> result, [NotNullWhen(true)] out T? value)
  {
    if (result is ParseOk<T> ok) {
      value = ok.Result!;
      return true;
    }

    value = default;
    return false;
  }

  public static void WithResult<T>(this IParseResult<T> result, Action<T> action)
  {
    if (result is ParseOk<T> ok) {
      action.Invoke(ok.Result);
    }
  }

  public static IParseResult<T[]> OkArray<T>(this IEnumerable<T> result)
    => new ParseOk<T[]>(result.ToArray());

  public static IParseResult<T> Ok<T>(this T result)
    => new ParseOk<T>(result);

  public static IParseResult<T[]> EmptyArray<T>(this IEnumerable<T> _)
    => new ParseEmpty<T[]>();

  public static IParseResult<T> Empty<T>(this T _)
    => new ParseEmpty<T>();
}

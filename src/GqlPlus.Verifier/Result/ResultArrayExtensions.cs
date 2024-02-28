using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Result;

public static class ResultArrayExtensions
{
  public static bool IsError<T>(this IResultArray<T> result, Action<TokenMessage>? action = null)
  {
    if (result is IResultMessage<T[]> error) {
      action?.Invoke(error.Message);
      return true;
    }

    return false;
  }

  public static bool Optional<T>(this IResultArray<T> result, Action<T[]> action)
  {
    ArgumentNullException.ThrowIfNull(action);

    if (result is ResultArrayOk<T> ok) {
      action(ok.Result);
      return true;
    }

    if (result is ResultArrayEmpty<T>) {
      action([]);
      return true;
    }

    return false;
  }

  public static T[] Optional<T>(this IResultArray<T> result)
    => result switch {
      IResultEmpty<T[]>
        => [],
      IResultValue<T[]> ok
        => ok.Result,
      IResultMessage<T[]> message
        => throw new InvalidOperationException(message.Message.ToString()),
      _ => throw new InvalidOperationException("Result for " + typeof(T).Name + " has no message"),
    };

  public static bool Required<T>(this IResultArray<T> result, Action<T[]> action)
  {
    ArgumentNullException.ThrowIfNull(action);

    if (result is ResultArrayOk<T> ok) {
      action(ok.Result!);
      return true;
    }

    return false;
  }

  public static void WithResult<T>(this IResultArray<T> result, Action<T[]> action)
  {
    ArgumentNullException.ThrowIfNull(action);

    if (result is IResultValue<T[]> ok) {
      action.Invoke(ok.Result);
    }
  }

  public static IResultArray<T> OkArray<T>(this IEnumerable<T> result)
    => new ResultArrayOk<T>([.. result]);

  public static IResultArray<T> EmptyArray<T>(this IEnumerable<T>? _)
    => new ResultArrayEmpty<T>();

  public static IResultArray<T> EmptyArray<T>(this int _)
    => new ResultArrayEmpty<T>();

  public static IResultArray<T> PartialArray<T>(this IEnumerable<T> result, TokenMessage message)
    => new ResultArrayPartial<T>([.. result], message);

  public static IResultArray<T> ErrorArray<T>(this IEnumerable<T>? _, TokenMessage message)
    => new ResultArrayError<T>(message);
}

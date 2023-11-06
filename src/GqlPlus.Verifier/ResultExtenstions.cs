using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Verifier;

public static class ResultExtenstions
{
  public static IResultArray<R> AsResultArray<T, R>(this IResult<T> result, IEnumerable<R>? _ = default)
    => result switch {
      ResultArrayOk<T> ok when ok.Result is R[] newResult
        => new ResultArrayOk<R>(newResult),
      ResultPartial<T> part when part.Result is R[] newResult
        => new ResultArrayPartial<R>(newResult, part.Message),
      IResultMessage<T> msg
        => new ResultArrayError<R>(msg.Message),
      _ => new ResultArrayEmpty<R>(),
    };

  public static IResult<R> AsPartial<T, R>(this IResult<T> old, R result, Action<ParseMessage>? action = null)
  {
    if (old is IResultMessage<T> part) {
      action?.Invoke(part.Message);
      return new ResultPartial<R>(result, part.Message);
    }

    return new ResultOk<R>(result);
  }

  public static bool IsError<T>(this IResult<T> result, Action<ParseMessage>? action = null)
  {
    if (result is IResultMessage<T> error) {
      action?.Invoke(error.Message);
      return true;
    }

    return false;
  }

  public static bool Optional<T>(this IResult<T> result, Action<T?> action)
  {
    if (result is IResultOk<T> ok) {
      action(ok.Result);
      return true;
    }

    if (result is ResultEmpty<T>) {
      action(default);
      return true;
    }

    return false;
  }

  public static bool Required<T>(this IResult<T> result, [NotNullWhen(true)] out T? value)
  {
    if (result is IResultOk<T> ok) {
      value = ok.Result!;
      return true;
    }

    value = result is ResultPartial<T> part ? part.Result : default;
    return false;
  }

  public static bool Required<T>(this IResult<T> result, Action<T> action)
  {
    if (result is IResultOk<T> ok) {
      action(ok.Result!);
      return true;
    }

    return false;
  }

  public static void WithResult<T>(this IResult<T> result, Action<T> action)
  {
    if (result is IResultValue<T> ok) {
      action.Invoke(ok.Result);
    }
  }

  public static IResult<T> Ok<T>(this T result)
    => new ResultOk<T>(result);

  public static IResult<T> Empty<T>(this T _)
    => new ResultEmpty<T>();
}

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

  public static IResult<R> AsPartial<T, R>(this IResult<T> old, R result, Action<T>? action = null)
  {
    if (old is IResultValue<T> value) {
      action?.Invoke(value.Result);
    }

    return old is IResultMessage<T> part
      ? new ResultPartial<R>(result, part.Message)
      : new ResultOk<R>(result);
  }

  public static bool HasValue<T>(this IResult<T> result)
    => result is IResultValue<T>;

  public static bool IsEmpty<T>(this IResult<T> result)
    => result is IResultEmpty<T>;

  public static bool IsError<T>(this IResult<T> result, Action<ParseMessage>? action = null)
  {
    if (result is IResultMessage<T> error) {
      action?.Invoke(error.Message);
      return true;
    }

    return false;
  }

  public static bool IsOk<T>(this IResult<T> result)
    => result is IResultOk<T>;

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

  public static T? Optional<T>(this IResult<T> result)
    => result switch {
      ResultEmpty<T>
        => default,
      IResultValue<T> ok
        => ok.Result,
      IResultMessage<T> message
        => throw new InvalidOperationException(message.Message.ToString()),
      _ => throw new InvalidOperationException("Result for " + typeof(T).Name + " has no message"),
    };

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

  public static T Required<T>(this IResult<T> result)
    => result switch {
      IResultOk<T> ok
        => ok.Result,
      IResultMessage<T> message
        => throw new InvalidOperationException(message.Message.ToString()),
      _ => throw new InvalidOperationException("Result for " + typeof(T).Name + " is empty"),
    };

  public static IResult<R> Select<T, R>(this IResult<T> old, Func<T, R?> selector)
  {
    R? result = default;
    if (old is IResultValue<T> value) {
      result = selector(value.Result);
    }

    return old switch {
      IResultOk<T> when result is not null
        => result.Ok(),
      IResultMessage<T> part when result is not null
        => new ResultPartial<R>(result, part.Message),
      _ => old.AsResult<R>(),
    };
  }

  public static IResult<R> SelectOk<T, R>(this IResult<T> old, Func<T, R?> selector)
  {
    R? result = default;
    if (old is IResultOk<T> value) {
      result = selector(value.Result);
    }

    return old switch {
      IResultOk<T> when result is not null
        => result.Ok(),
      IResultMessage<T> part when result is not null
        => new ResultPartial<R>(result, part.Message),
      _ => old.AsResult<R>(),
    };
  }

  public static IResult<T> Map<T>(this IResult<T> old, Func<T, IResult<T>> selector)
    => old.Map(selector, () => old);

  public static IResult<R> Map<T, R>(this IResult<T> old, Func<T, IResult<R>> selector)
    => old.Map(selector, () => old.AsResult<R>());

  public static IResult<R> Map<T, R>(this IResult<T> old, Func<T, IResult<R>> onValue, Func<IResult<R>> otherwise)
    => old is IResultValue<T> value
      ? onValue(value.Result)
      : otherwise();

  public static IResult<R> MapOk<T, R>(this IResult<T> old, Func<T, IResult<R>> onValue, Func<IResult<R>> otherwise)
    => old is IResultOk<T> value
      ? onValue(value.Result)
      : otherwise();

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

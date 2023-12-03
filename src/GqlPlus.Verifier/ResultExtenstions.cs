namespace GqlPlus.Verifier;

public static class ResultExtenstions
{
  public static IResultArray<R> AsPartialArray<T, R>(this IResult<T> old, IEnumerable<R> result, Action<T>? withValue = null)
  {
    if (old is IResultValue<T> value) {
      withValue?.Invoke(value.Result);
    }

    return old switch {
      IResultMessage<T> msg
        => result.PartialArray(msg.Message),
      _ => result.OkArray(),
    };
  }

  public static IResultArray<R> AsResultArray<T, R>(this IResult<T> result, IEnumerable<R>? _ = default)
    => result switch {
      IResultOk<T> ok when ok.Result is R[] newResult
        => new ResultArrayOk<R>(newResult),
      IResultPartial<T> part when part.Result is R[] newResult
        => new ResultArrayPartial<R>(newResult, part.Message),
      IResultMessage<T> msg
        => new ResultArrayError<R>(msg.Message),
      _ => new ResultArrayEmpty<R>(),
    };

  public static IResult<T> Empty<T>(this T? _)
    => new ResultEmpty<T>();
  public static IResult<T> Empty<T>(this int _)
    => new ResultEmpty<T>();

  public static IResult<T> Error<T>(this T? _, TokenMessage error)
    => new ResultError<T>(error);
  public static IResult<T> Error<T>(this int _, TokenMessage error)
    => new ResultError<T>(error);

  public static bool HasValue<T>(this IResult<T> result)
    => result is IResultValue<T>;

  public static bool IsEmpty<T>(this IResult<T> result)
    => result is IResultEmpty<T>;

  public static bool IsError<T>(this IResult<T> result, Action<TokenMessage>? action = null)
  {
    if (result is IResultMessage<T> error) {
      action?.Invoke(error.Message);
      return true;
    }

    return false;
  }

  public static bool IsOk<T>(this IResult<T> result)
    => result is IResultOk<T>;

  public static IResult<T> MapEmpty<T>(this IResult<T> result, OnResult<T> onEmpty)
    => result is IResultEmpty<T> ? onEmpty() : result;

  public static IResult<R> MapOk<T, R>(this IResult<T> old, SelectResult<T, R> onValue, OnResult<R> otherwise)
    => old is IResultOk<T> value
      ? onValue(value.Result)
      : otherwise();

  public static IResult<T> Ok<T>(this T result)
    => new ResultOk<T>(result);

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

  public static IResult<T> Partial<T>(this T result, TokenMessage error)
    => new ResultPartial<T>(result, error);

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

  public static IResult<R> Select<T, R>(this IResult<T> old, Func<T, R?> selector, OnResult<R>? onEmpty = null)
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
      IResultEmpty<T> when onEmpty is not null
        => onEmpty(),
      _ => old.AsResult<R>(),
    };
  }

  public static IResult<R> SelectOk<T, R>(this IResult<T> old, Func<T, R?> selector, OnResult<R>? onEmpty = null)
  {
    R? result = default;
    if (old is IResultOk<T> value) {
      result = selector(value.Result);
    }

    return old switch {
      IResultOk<T> when result is not null
        => result.Ok(),
      IResultEmpty<T> when onEmpty is not null
        => onEmpty(),
      _ => old.AsResult<R>(),
    };
  }

  public static void WithMessage<T>(this IResult<T> result, Action<TokenMessage> action)
  {
    if (result is IResultMessage<T> message) {
      action.Invoke(message.Message);
    }
  }

  public static void WithResult<T>(this IResult<T> result, Action<T> action)
  {
    if (result is IResultValue<T> ok) {
      action.Invoke(ok.Result);
    }
  }
}

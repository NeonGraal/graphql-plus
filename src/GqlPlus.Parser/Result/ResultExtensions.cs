using GqlPlus.Token;

namespace GqlPlus.Result;

public static class ResultExtensions
{
  public static IResultArray<TResult> AsPartialArray<TValue, TResult>(this IResult<TValue> old, IEnumerable<TResult> result, Action<TValue>? withValue = null)
  {
    if (old is IResultValue<TValue> value) {
      withValue?.Invoke(value.Result);
    }

    return old switch {
      IResultMessage<TValue> msg
        => result.PartialArray(msg.Message),
      _ => result.OkArray(),
    };
  }

  public static IResultArray<TResult> AsResultArray<TValue, TResult>(this IResult<TValue> result, IEnumerable<TResult>? _ = default)
    => result switch {
      IResultOk<TValue> ok when ok.Result is IEnumerable<TResult> newResult
        => new ResultArrayOk<TResult>(newResult),
      IResultPartial<TValue> part when part.Result is IEnumerable<TResult> newResult
        => new ResultArrayPartial<TResult>(newResult, part.Message),
      IResultMessage<TValue> msg
        => new ResultArrayError<TResult>(msg.Message),
      _ => new ResultArrayEmpty<TResult>(),
    };

  public static IResult<TValue> Empty<TValue>(this TValue? _)
    => new ResultEmpty<TValue>();
  public static IResult<TValue> Empty<TValue>(this int _)
    => new ResultEmpty<TValue>();

  public static IResult<TValue> Error<TValue>(this TValue? _, TokenMessage error)
    => new ResultError<TValue>(error);
  public static IResult<TValue> Error<TValue>(this TokenMessage error)
    => new ResultError<TValue>(error);

  public static bool HasValue<TValue>(this IResult<TValue> result)
    => result is IResultValue<TValue>;

  public static bool IsEmpty<TValue>(this IResult<TValue> result)
    => result is IResultEmpty<TValue>;

  public static bool IsError<TValue>(this IResult<TValue> result, Action<TokenMessage>? action = null)
  {
    if (result is IResultMessage<TValue> error) {
      action?.Invoke(error.Message);
      return true;
    }

    return false;
  }

  public static bool IsOk<TValue>(this IResult<TValue> result)
    => result is IResultOk<TValue>;

  public static IResult<TValue> MapEmpty<TValue>(this IResult<TValue> result, OnResult<TValue> onEmpty)
  {
    ArgumentNullException.ThrowIfNull(onEmpty);

    return result is IResultEmpty<TValue> ? onEmpty() : result;
  }

  public static IResult<TResult> MapOk<TValue, TResult>(this IResult<TValue> old, SelectResult<TValue, TResult> onValue, OnResult<TResult> otherwise)
  {
    ArgumentNullException.ThrowIfNull(onValue);
    ArgumentNullException.ThrowIfNull(otherwise);

    return old is IResultOk<TValue> value
        ? onValue(value.Result)
        : otherwise();
  }

  public static IResult<TValue> Ok<TValue>(this TValue result)
    => new ResultOk<TValue>(result);

  public static bool Optional<TValue>(this IResult<TValue> result, Action<TValue?> action)
  {
    ArgumentNullException.ThrowIfNull(action);

    if (result is IResultOk<TValue> ok) {
      action(ok.Result);
      return true;
    }

    if (result is ResultEmpty<TValue>) {
      action(default);
      return true;
    }

    return false;
  }

  public static TValue? Optional<TValue>(this IResult<TValue> result)
    => result switch {
      ResultEmpty<TValue>
        => default,
      IResultValue<TValue> ok
        => ok.Result,
      IResultMessage<TValue> message
        => throw new InvalidOperationException(message.Message.ToString()),
      _ => throw new InvalidOperationException("Result for " + typeof(TValue).Name + " has no message"),
    };

  public static IResult<TValue> Partial<TValue>(this TValue result, TokenMessage error)
    => new ResultPartial<TValue>(result, error);

  public static bool Required<TValue>(this IResult<TValue> result, Action<TValue> action)
  {
    ArgumentNullException.ThrowIfNull(action);

    if (result is IResultOk<TValue> ok) {
      action(ok.Result!);
      return true;
    }

    return false;
  }

  public static TValue Required<TValue>(this IResult<TValue> result)
    => result switch {
      IResultOk<TValue> ok
        => ok.Result,
      IResultMessage<TValue> message
        => throw new InvalidOperationException(message.Message.ToString()),
      _ => throw new InvalidOperationException("Result for " + typeof(TValue).Name + " is empty"),
    };

  public static IResult<TResult> Select<TValue, TResult>(this IResult<TValue> old, Func<TValue, TResult?> selector, OnResult<TResult>? onEmpty = null)
  {
    ArgumentNullException.ThrowIfNull(selector);

    TResult? result = default;
    if (old is IResultValue<TValue> value) {
      result = selector(value.Result);
    }

    return old switch {
      IResultOk<TValue> when result is not null
        => result.Ok(),
      IResultMessage<TValue> part when result is not null
        => new ResultPartial<TResult>(result, part.Message),
      IResultEmpty<TValue> when onEmpty is not null
        => onEmpty(),
      _ => old.AsResult<TResult>(),
    };
  }

  public static IResult<TResult> SelectOk<TValue, TResult>(this IResult<TValue> old, Func<TValue, TResult?> selector, OnResult<TResult>? onEmpty = null)
  {
    ArgumentNullException.ThrowIfNull(selector);

    TResult? result = default;
    if (old is IResultOk<TValue> value) {
      result = selector(value.Result);
    }

    return old switch {
      IResultOk<TValue> when result is not null
        => result.Ok(),
      IResultEmpty<TValue> when onEmpty is not null
        => onEmpty(),
      _ => old.AsResult<TResult>(),
    };
  }

  public static void WithMessage<TValue>(this IResult<TValue> result, Action<TokenMessage> action)
  {
    ArgumentNullException.ThrowIfNull(action);

    if (result is IResultMessage<TValue> message) {
      action.Invoke(message.Message);
    }
  }

  public static void WithResult<TValue>(this IResult<TValue> result, Action<TValue> action)
  {
    ArgumentNullException.ThrowIfNull(action);

    if (result is IResultValue<TValue> ok) {
      action.Invoke(ok.Result);
    }
  }
}

using GqlPlus.Token;

namespace GqlPlus.Result;

public static class ResultExtensions
{
  public static IResultArray<TResult> AsPartialArray<TValue, TResult>(
    this IResult<TValue> old,
    IEnumerable<TResult> result,
    Action<TValue>? withValue = null
  )
  {
    if (old is IResultValue<TValue> value) {
      withValue?.Invoke(value.Result);
    }

    return old switch {
      IResultMessage msg
        => result.PartialArray(msg.Message),
      _ => result.OkArray(),
    };
  }

  public static IResultArray<TResult> AsResultArray<TValue, TResult>(this IResult<TValue> result, IEnumerable<TResult>? partial = default)
    => result switch {
      IResultOk<TValue> ok when ok.Result is IEnumerable<TResult> newResult
        => new ResultArrayOk<TResult>(newResult),
      IResultPartial<TValue> part when part.Result is IEnumerable<TResult> newResult
        => new ResultArrayPartial<TResult>(newResult, part.Message),
      IResultMessage msg
        => partial is null
          ? new ResultArrayError<TResult>(msg.Message)
          : new ResultArrayPartial<TResult>(partial, msg.Message),
      _ => new ResultArrayEmpty<TResult>(),
    };

  public static IResult<TValue> Empty<TValue>(this TValue? _)
    => new ResultEmpty<TValue>();

  public static IResult<TValue> Error<TValue>(this TValue? _, TokenMessage error)
    => new ResultError<TValue>(error);

  public static bool HasValue<TValue>(this IResult<TValue> result)
    => result is IResultValue<TValue>;

  public static bool IsEmpty<TValue>(this IResult<TValue> result)
    => result is IResultEmpty<TValue>;

  public static bool IsError<TValue>(this IResult<TValue> result, Action<TokenMessage>? action = null)
  {
    if (result is IResultMessage error) {
      action?.Invoke(error.Message);
      return true;
    }

    return false;
  }

  public static bool IsOk<TValue>(this IResult<TValue> result)
    => result is IResultOk<TValue>;

  public static IResult<TValue> MapEmpty<TValue>(this IResult<TValue> result, OnResult<TValue> onEmpty)
  {
    onEmpty.ThrowIfNull();

#pragma warning disable CA1062 // Validate arguments of public methods
    return result is IResultEmpty ? onEmpty() : result;
#pragma warning restore CA1062 // Validate arguments of public methods
  }

  public static IResult<TResult> MapOk<TValue, TResult>(
    this IResult<TValue> old,
    SelectResult<TValue, TResult> onValue,
    OnResult<TResult> otherwise
  )
  {
    onValue.ThrowIfNull();
    otherwise.ThrowIfNull();

#pragma warning disable CA1062 // Validate arguments of public methods
    return old is IResultOk<TValue> value
        ? onValue(value.Result)
        : otherwise();
#pragma warning restore CA1062 // Validate arguments of public methods
  }

  public static TokenMessage Message<TValue>(this TValue result)
    => result is IResultMessage msg ? msg.Message : throw new InvalidOperationException("Expected Message");

  public static IResult<TValue> Ok<TValue>(this TValue result)
    => new ResultOk<TValue>(result);

  public static bool Optional<TValue>(this IResult<TValue> result, Action<TValue?> action)
  {
    action.ThrowIfNull();

    if (result is IResultOk<TValue> ok) {
#pragma warning disable CA1062 // Validate arguments of public methods
      action(ok.Result);
#pragma warning restore CA1062 // Validate arguments of public methods
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
      IResultEmpty
        => default,
      IResultValue<TValue> ok
        => ok.Result,
      IResultMessage message
        => throw new InvalidOperationException(message.Message.ToString()),
      _ => throw new InvalidOperationException("Result for " + typeof(TValue).Name + " has no message"),
    };

  public static IResult<TValue> Partial<TValue>(this TValue result, TokenMessage error)
    => new ResultPartial<TValue>(result, error);

  public static bool Required<TValue>(this IResult<TValue> result, Action<TValue> action)
  {
    action.ThrowIfNull();

    if (result is IResultOk<TValue> ok) {
#pragma warning disable CA1062 // Validate arguments of public methods
      action(ok.Result!);
#pragma warning restore CA1062 // Validate arguments of public methods
      return true;
    }

    return false;
  }

  public static TValue Required<TValue>(this IResult<TValue> result)
    => result switch {
      IResultOk<TValue> ok
        => ok.Result,
      IResultMessage message
        => throw new InvalidOperationException(message.Message.ToString()),
      _ => throw new InvalidOperationException("Result for " + typeof(TValue).Name + " is empty"),
    };

  public static IResult<TResult> Select<TValue, TResult>(
    this IResult<TValue> old,
    Func<TValue, TResult?> selector,
    OnResult<TResult>? onEmpty = null
  )
  {
    selector.ThrowIfNull();

    TResult? result = default;
    if (old is IResultValue<TValue> value) {
#pragma warning disable CA1062 // Validate arguments of public methods
      result = selector(value.Result);
#pragma warning restore CA1062 // Validate arguments of public methods
    }

    return old switch {
      IResultOk when result is not null
        => result.Ok(),
      IResultMessage part when result is not null
        => new ResultPartial<TResult>(result, part.Message),
      IResultEmpty when onEmpty is not null
        => onEmpty(),
      _ => old.AsResult<TResult>(),
    };
  }

  public static IResult<TResult> SelectOk<TValue, TResult>(
    this IResult<TValue> old,
    Func<TValue, TResult?> selector,
    OnResult<TResult>? onEmpty = null
  )
  {
    selector.ThrowIfNull();

    TResult? result = default;
    if (old is IResultOk<TValue> value) {
#pragma warning disable CA1062 // Validate arguments of public methods
      result = selector(value.Result);
#pragma warning restore CA1062 // Validate arguments of public methods
    }

    return old switch {
      IResultOk when result is not null
        => result.Ok(),
      IResultEmpty when onEmpty is not null
        => onEmpty(),
      _ => old.AsResult<TResult>(),
    };
  }

  public static void WithMessage<TValue>(this IResult<TValue> result, Action<TokenMessage> action)
  {
    action.ThrowIfNull();

    if (result is IResultMessage message) {
#pragma warning disable CA1062 // Validate arguments of public methods
      action.Invoke(message.Message);
#pragma warning restore CA1062 // Validate arguments of public methods
    }
  }

  public static void WithResult<TValue>(this IResult<TValue> result, Action<TValue> action)
  {
    action.ThrowIfNull();

    if (result is IResultValue<TValue> ok) {
#pragma warning disable CA1062 // Validate arguments of public methods
      action.Invoke(ok.Result);
#pragma warning restore CA1062 // Validate arguments of public methods
    }
  }
}

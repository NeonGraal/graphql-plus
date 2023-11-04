﻿using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Verifier;

public static class ResultExtenstions
{
  public static IResult<R> AsResult<T, R>(this IResult<T> result, R? _ = default)
    => result switch {
      ResultPartial<T> part
        => part.Result is R newResult
          ? new ResultPartial<R>(newResult, part.Message)
          : new ResultError<R>(part.Message),
      ResultError<T> error
        => new ResultError<R>(error.Message),
      ResultOk<T> ok when ok.Result is R newResult
        => new ResultOk<R>(newResult),
      _ => new ResultEmpty<R>(),
    };

  public static IResultArray<R> AsResultArray<T, R>(this IResult<T> result, IEnumerable<R>? _ = default)
    => result is ResultArrayOk<T> ok && ok.Result is R[] newResult
      ? new ResultArrayOk<R>(newResult)
      : new ResultArrayEmpty<R>();

  public static bool IsError<T>(this IResult<T> result, Action<ParseMessage>? action = null)
  {
    if (result is IResultMessage<T> error) {
      action?.Invoke(error.Message);
      return true;
    }

    return false;
  }

  public static bool Optional<T>(this IResult<T> result, out T? value)
  {
    if (result is IResultValue<T> ok) {
      value = ok.Result;
      return true;
    }

    value = default;
    return result is ResultEmpty<T>;
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

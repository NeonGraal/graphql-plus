using System.Diagnostics.CodeAnalysis;
using GqlPlus.Token;

namespace GqlPlus.Result;

public static class ResultArrayExtensions
{
  public static bool Optional<T>(this IResultArray<T> result, [NotNullWhen(true)] Action<IEnumerable<T>> action)
  {
    action.ThrowIfNull();

    if (result is IResultArrayOk<T> ok) {
#pragma warning disable CA1062 // Validate arguments of public methods
      action(ok.Result);
#pragma warning restore CA1062 // Validate arguments of public methods
      return true;
    }

    if (result is IResultEmpty) {
      action([]);
      return true;
    }

    return false;
  }

  public static IEnumerable<T> Optional<T>(this IResultArray<T> result)
    => result switch {
      IResultEmpty
        => [],
      IResultValue<IEnumerable<T>> ok
        => ok.Result,
      IResultMessage message
        => throw new InvalidOperationException(message.Message.ToString()),
      _ => throw new InvalidOperationException("Result for " + typeof(T).Name + " has no message"),
    };

  public static bool Required<T>(this IResultArray<T> result, Action<IEnumerable<T>> action)
  {
    action.ThrowIfNull();

    if (result is ResultArrayOk<T> ok) {
#pragma warning disable CA1062 // Validate arguments of public methods
      action(ok.Result!);
#pragma warning restore CA1062 // Validate arguments of public methods
      return true;
    }

    return false;
  }

  public static void WithResult<T>(this IResultArray<T> result, Action<IEnumerable<T>> action)
  {
    action.ThrowIfNull();

    if (result is IResultValue<IEnumerable<T>> ok) {
#pragma warning disable CA1062 // Validate arguments of public methods
      action.Invoke(ok.Result);
#pragma warning restore CA1062 // Validate arguments of public methods
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

  public static IResultArray<T> ErrorArray<T>(this TokenMessage message)
    => new ResultArrayError<T>(message);
}

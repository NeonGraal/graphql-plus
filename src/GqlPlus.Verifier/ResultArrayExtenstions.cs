namespace GqlPlus.Verifier;

public static class ResultArrayExtenstions
{
  public static IResult<R> AsPartial<T, R>(this IResultArray<T> old, R result, Action<ParseMessage>? action = null)
  {
    if (old is IResultMessage<T[]> part) {
      action?.Invoke(part.Message);
      return new ResultPartial<R>(result, part.Message);
    }

    return new ResultOk<R>(result);
  }

  public static bool IsError<T>(this IResultArray<T> result, Action<ParseMessage>? action = null)
  {
    if (result is IResultMessage<T[]> error) {
      action?.Invoke(error.Message);
      return true;
    }

    return false;
  }

  public static bool Optional<T>(this IResultArray<T> result, out T[] value)
  {
    if (result is ResultArrayOk<T> ok) {
      value = ok.Result;
      return true;
    }

    value = Array.Empty<T>();
    return result is ResultEmpty<T>;
  }

  public static bool Required<T>(this IResultArray<T> result, out T[] value)
  {
    if (result is ResultArrayOk<T> ok) {
      value = ok.Result!;
      return true;
    }

    value = Array.Empty<T>();
    return false;
  }

  public static void WithResult<T>(this IResultArray<T> result, Action<T[]> action)
  {
    if (result is ResultArrayOk<T> ok) {
      action.Invoke(ok.Result);
    }
  }

  public static IResultArray<T> OkArray<T>(this IEnumerable<T> result)
    => new ResultArrayOk<T>(result.ToArray());

  public static IResultArray<T> EmptyArray<T>(this IEnumerable<T> _)
    => new ResultArrayEmpty<T>();
}

namespace GqlPlus.Verifier.Result;

public readonly struct ResultArrayEmpty<T> : IResultArray<T>, IResultEmpty<T[]>
{
  public IResult<R> AsPartial<R>(R result, Action<T[]>? withValue = null, Action? action = null)
  {
    action?.Invoke();
    return result.Ok();
  }

  public IResultArray<R> AsPartialArray<R>(IEnumerable<R> result, Action<T[]>? withValue = null)
    => result.OkArray();

  public IResult<R> AsResult<R>(R? _ = default)
    => _.Empty();

  public IResultArray<R> AsResultArray<R>(R[]? _ = default)
    => _.EmptyArray();

  public IResult<R> Map<R>(SelectResult<T[], R> onValue, OnResult<R>? otherwise = null)
    => otherwise?.Invoke() ?? AsResult<R>();
}

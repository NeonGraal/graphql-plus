namespace GqlPlus.Verifier.Result;

public readonly struct ResultArrayOk<T> : IResultArray<T>, IResultOk<T[]>
{
  public T[] Result { get; }

  public ResultArrayOk(T[] result) => Result = result;

  public IResult<R> AsPartial<R>(R result, Action<T[]>? withValue = null, Action? action = null)
  {
    withValue?.Invoke(Result);
    action?.Invoke();
    return result.Ok();
  }

  public IResultArray<R> AsPartialArray<R>(IEnumerable<R> result, Action<T[]>? withValue = null)
  {
    withValue?.Invoke(Result);
    return result.OkArray();
  }

  public IResult<R> AsResult<R>(R? _ = default)
    => Result is R newResult
      ? newResult.Ok()
      : _.Empty();

  public IResultArray<R> AsResultArray<R>(R[]? _ = default)
    => Result is R[] newResult
      ? newResult.OkArray()
      : _.EmptyArray();

  public IResult<R> Map<R>(SelectResult<T[], R> onValue, OnResult<R>? otherwise = null)
    => onValue(Result);
}

namespace GqlPlus.Verifier.Result;

public readonly struct ResultOk<T> : IResultOk<T>
{
  public T Result { get; }

  public ResultOk(T result)
  {
    ArgumentNullException.ThrowIfNull(result);
    Result = result;
  }

  public IResult<R> AsPartial<R>(R result, Action<T>? withValue = null, Action? action = null)
  {
    withValue?.Invoke(Result);
    action?.Invoke();
    return result.Ok();
  }

  public IResult<R> AsResult<R>(R? _ = default)
    => Result is R newResult
      ? newResult.Ok()
      : _.Empty();

  public IResult<R> Map<R>(SelectResult<T, R> onValue, OnResult<R>? otherwise = null)
    => onValue(Result);
}

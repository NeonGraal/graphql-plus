namespace GqlPlus.Verifier.Result;

public readonly struct ResultEmpty<T> : IResultEmpty<T>
{
  public IResult<R> AsPartial<R>(R result, Action<T>? withValue = null, Action? action = null)
  {
    action?.Invoke();
    return result.Ok();
  }

  public IResult<R> AsResult<R>(R? _ = default)
    => _.Empty();

  public IResult<R> Map<R>(SelectResult<T, R> onValue, OnResult<R>? otherwise = null)
    => otherwise?.Invoke() ?? AsResult<R>();
}

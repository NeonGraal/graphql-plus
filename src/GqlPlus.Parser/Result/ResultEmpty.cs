namespace GqlPlus.Result;

public readonly struct ResultEmpty<TValue>
  : IResultEmpty<TValue>
{
  public IResult<TResult> AsPartial<TResult>(TResult result, Action<TValue>? withValue = null, Action? action = null)
  {
    action?.Invoke();
    return result.Ok();
  }

  public IResult<TResult> AsResult<TResult>(TResult? _ = default)
    => _.Empty();

  public IResult<TResult> Map<TResult>(SelectResult<TValue, TResult> onValue, OnResult<TResult>? otherwise = null)
    => otherwise?.Invoke() ?? AsResult<TResult>();
}

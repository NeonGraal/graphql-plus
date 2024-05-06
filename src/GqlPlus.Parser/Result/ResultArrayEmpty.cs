namespace GqlPlus.Result;

public readonly struct ResultArrayEmpty<TValue>
  : IResultArray<TValue>, IResultEmpty<IEnumerable<TValue>>
{
  public IResult<TResult> AsPartial<TResult>(TResult result, Action<IEnumerable<TValue>>? withValue = null, Action? action = null)
  {
    action?.Invoke();
    return result.Ok();
  }

  public IResultArray<TResult> AsPartialArray<TResult>(IEnumerable<TResult> result, Action<IEnumerable<TValue>>? withValue = null)
    => result.OkArray();

  public IResult<TResult> AsResult<TResult>(TResult? _ = default)
    => _.Empty();

  public IResultArray<TResult> AsResultArray<TResult>(IEnumerable<TValue>? _ = default)
    => 0.EmptyArray<TResult>();

  public IResult<TResult> Map<TResult>(SelectResult<IEnumerable<TValue>, TResult> onValue, OnResult<TResult>? otherwise = null)
    => otherwise?.Invoke() ?? AsResult<TResult>();
}

namespace GqlPlus.Verifier.Result;

public readonly struct ResultArrayEmpty<TValue>
  : IResultArray<TValue>, IResultEmpty<TValue[]>
{
  public IResult<TResult> AsPartial<TResult>(TResult result, Action<TValue[]>? withValue = null, Action? action = null)
  {
    action?.Invoke();
    return result.Ok();
  }

  public IResultArray<TResult> AsPartialArray<TResult>(IEnumerable<TResult> result, Action<TValue[]>? withValue = null)
    => result.OkArray();

  public IResult<TResult> AsResult<TResult>(TResult? _ = default)
    => _.Empty();

  public IResultArray<TResult> AsResultArray<TResult>(TResult[]? _ = default)
    => _.EmptyArray();

  public IResult<TResult> Map<TResult>(SelectResult<TValue[], TResult> onValue, OnResult<TResult>? otherwise = null)
    => otherwise?.Invoke() ?? AsResult<TResult>();
}

namespace GqlPlus.Verifier.Result;

[SuppressMessage("Performance", "CA1815:Override equals and operator equals on value types")]
public readonly struct ResultArrayOk<TValue>
  : IResultArray<TValue>, IResultOk<TValue[]>
{
  public TValue[] Result { get; }

  public ResultArrayOk(TValue[] result) => Result = result;

  public IResult<TResult> AsPartial<TResult>(TResult result, Action<TValue[]>? withValue = null, Action? action = null)
  {
    withValue?.Invoke(Result);
    action?.Invoke();
    return result.Ok();
  }

  public IResultArray<TResult> AsPartialArray<TResult>(IEnumerable<TResult> result, Action<TValue[]>? withValue = null)
  {
    withValue?.Invoke(Result);
    return result.OkArray();
  }

  public IResult<TResult> AsResult<TResult>(TResult? _ = default)
    => Result is TResult newResult
      ? newResult.Ok()
      : _.Empty();

  public IResultArray<TResult> AsResultArray<TResult>(TResult[]? _ = default)
    => Result is TResult[] newResult
      ? newResult.OkArray()
      : _.EmptyArray();

  public IResult<TResult> Map<TResult>(SelectResult<TValue[], TResult> onValue, OnResult<TResult>? otherwise = null)
  {
    ArgumentNullException.ThrowIfNull(onValue);

    return onValue(Result);
  }
}

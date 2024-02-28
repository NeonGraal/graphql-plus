namespace GqlPlus.Verifier.Result;

public readonly struct ResultOk<TValue>
  : IResultOk<TValue>
{
  public TValue Result { get; }

  public ResultOk(TValue result)
  {
    ArgumentNullException.ThrowIfNull(result);
    Result = result;
  }

  public IResult<TResult> AsPartial<TResult>(TResult result, Action<TValue>? withValue = null, Action? action = null)
  {
    withValue?.Invoke(Result);
    action?.Invoke();
    return result.Ok();
  }

  public IResult<TResult> AsResult<TResult>(TResult? _ = default)
    => Result is TResult newResult
      ? newResult.Ok()
      : _.Empty();

  public IResult<TResult> Map<TResult>(SelectResult<TValue, TResult> onValue, OnResult<TResult>? otherwise = null)
    => onValue(Result);
}

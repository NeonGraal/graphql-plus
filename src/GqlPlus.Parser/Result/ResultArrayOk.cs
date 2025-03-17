namespace GqlPlus.Result;

public readonly struct ResultArrayOk<TValue>(
  IEnumerable<TValue> result
) : IResultArray<TValue>, IResultOk<IEnumerable<TValue>>
{
  public IEnumerable<TValue> Result { get; } = result;

  public IResult<TResult> AsPartial<TResult>(TResult result, Action<IEnumerable<TValue>>? withValue = null, Action? action = null)
  {
    withValue?.Invoke(Result);
    action?.Invoke();
    return result.Ok();
  }

  public IResultArray<TResult> AsPartialArray<TResult>(IEnumerable<TResult> result, Action<IEnumerable<TValue>>? withValue = null)
  {
    withValue?.Invoke(Result);
    return result.OkArray();
  }

  public IResult<TResult> AsResult<TResult>(TResult? _ = default)
    => Result is TResult newResult
      ? newResult.Ok()
      : _.Empty();

  public IResultArray<TResult> AsResultArray<TResult>(IEnumerable<TValue>? _ = default)
    => Result is IEnumerable<TResult> newResult
      ? newResult.OkArray()
      : 0.EmptyArray<TResult>();

  public IResult<TResult> Map<TResult>(SelectResult<IEnumerable<TValue>, TResult> onValue, OnResult<TResult>? otherwise = null)
  {
    onValue.ThrowIfNull();

#pragma warning disable CA1062 // Validate arguments of public methods
    return onValue(Result);
#pragma warning restore CA1062 // Validate arguments of public methods
  }
}

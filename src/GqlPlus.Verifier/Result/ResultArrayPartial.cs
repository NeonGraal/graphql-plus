namespace GqlPlus.Verifier.Result;

public readonly struct ResultArrayPartial<T> : IResultArray<T>, IResultPartial<T[]>
{
  public T[] Result { get; }
  public TokenMessage Message { get; }

  public ResultArrayPartial(T[] result, TokenMessage message)
    => (Result, Message) = (result, message);

  public IResult<R> AsPartial<R>(R result, Action<T[]>? withValue = null, Action? action = null)
  {
    withValue?.Invoke(Result);
    action?.Invoke();
    return result.Partial(Message);
  }

  public IResultArray<R> AsPartialArray<R>(IEnumerable<R> result, Action<T[]>? withValue = null)
  {
    withValue?.Invoke(Result);
    return result.PartialArray(Message);
  }

  public IResult<R> AsResult<R>(R? _ = default)
    => Result is R newResult
          ? newResult.Partial(Message)
          : _.Error(Message);

  public IResultArray<R> AsResultArray<R>(R[]? _ = default)
    => Result is R[] newResult
          ? newResult.PartialArray(Message)
          : _.ErrorArray(Message);

  public IResult<R> Map<R>(SelectResult<T[], R> onValue, OnResult<R>? otherwise = null)
    => onValue(Result);
}

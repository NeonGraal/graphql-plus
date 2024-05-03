using GqlPlus.Token;

namespace GqlPlus.Result;

public readonly struct ResultArrayPartial<TValue>
  : IResultArray<TValue>, IResultPartial<TValue[]>
{
  public TValue[] Result { get; }
  public TokenMessage Message { get; }

  public ResultArrayPartial(TValue[] result, TokenMessage message)
    => (Result, Message) = (result, message);

  public IResult<TResult> AsPartial<TResult>(TResult result, Action<TValue[]>? withValue = null, Action? action = null)
  {
    withValue?.Invoke(Result);
    action?.Invoke();
    return result.Partial(Message);
  }

  public IResultArray<TResult> AsPartialArray<TResult>(IEnumerable<TResult> result, Action<TValue[]>? withValue = null)
  {
    withValue?.Invoke(Result);
    return result.PartialArray(Message);
  }

  public IResult<TResult> AsResult<TResult>(TResult? _ = default)
    => Result is TResult newResult
          ? newResult.Partial(Message)
          : _.Error(Message);

  public IResultArray<TResult> AsResultArray<TResult>(TResult[]? _ = default)
    => Result is TResult[] newResult
          ? newResult.PartialArray(Message)
          : _.ErrorArray(Message);

  public IResult<TResult> Map<TResult>(SelectResult<TValue[], TResult> onValue, OnResult<TResult>? otherwise = null)
    => onValue?.Invoke(Result) ?? 0.Empty<TResult>();
}

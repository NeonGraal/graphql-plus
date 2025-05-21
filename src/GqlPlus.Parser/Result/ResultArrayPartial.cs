using GqlPlus.Token;

namespace GqlPlus.Result;
public readonly struct ResultArrayPartial<TValue>
  : IResultArrayPartial<TValue>
{
  public IEnumerable<TValue> Result { get; }
  public TokenMessage Message { get; }

  public ResultArrayPartial(IEnumerable<TValue> result, TokenMessage message)
    => (Result, Message) = (result, message);

  public IResult<TResult> AsPartial<TResult>(TResult result, Action<IEnumerable<TValue>>? withValue = null, Action? action = null)
  {
    withValue?.Invoke(Result);
    action?.Invoke();
    return result.Partial(Message);
  }

  public IResultArray<TResult> AsPartialArray<TResult>(IEnumerable<TResult> result, Action<IEnumerable<TValue>>? withValue = null)
  {
    withValue?.Invoke(Result);
    return result.PartialArray(Message);
  }

  public IResult<TResult> AsResult<TResult>(TResult? _ = default)
    => Result is TResult newResult
          ? newResult.Partial(Message)
          : _.Error(Message);

  public IResultArray<TResult> AsResultArray<TResult>(IEnumerable<TValue>? _ = default)
    => Result is IEnumerable<TResult> newResult
          ? newResult.PartialArray(Message)
          : Message.ErrorArray<TResult>();

  public IResult<TResult> Map<TResult>(SelectResult<IEnumerable<TValue>, TResult> onValue, OnResult<TResult>? otherwise = null)
    => onValue?.Invoke(Result) ?? 0.Empty<TResult>();
}

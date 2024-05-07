using GqlPlus.Token;

namespace GqlPlus.Result;

public readonly struct ResultArrayError<TValue>(
  TokenMessage message
) : IResultArray<TValue>, IResultError<IEnumerable<TValue>>
{
  public TokenMessage Message { get; } = message;

  public IResult<TResult> AsPartial<TResult>(TResult result, Action<IEnumerable<TValue>>? withValue = null, Action? action = null)
  {
    action?.Invoke();
    return result.Partial(Message);
  }

  public IResultArray<TResult> AsPartialArray<TResult>(IEnumerable<TResult> result, Action<IEnumerable<TValue>>? withValue = null)
    => result.PartialArray(Message);

  public IResult<TResult> AsResult<TResult>(TResult? _ = default)
    => _.Error(Message);

  public IResultArray<TResult> AsResultArray<TResult>(IEnumerable<TValue>? _ = default)
    => Message.ErrorArray<TResult>();

  public IResult<TResult> Map<TResult>(SelectResult<IEnumerable<TValue>, TResult> onValue, OnResult<TResult>? otherwise = null)
    => otherwise?.Invoke() ?? AsResult<TResult>();
}

using GqlPlus.Token;

namespace GqlPlus.Result;

public readonly struct ResultArrayError<TValue>
  : IResultArray<TValue>, IResultError<TValue[]>
{
  public TokenMessage Message { get; }

  public ResultArrayError(TokenMessage message) => Message = message;

  public IResult<TResult> AsPartial<TResult>(TResult result, Action<TValue[]>? withValue = null, Action? action = null)
  {
    action?.Invoke();
    return result.Partial(Message);
  }

  public IResultArray<TResult> AsPartialArray<TResult>(IEnumerable<TResult> result, Action<TValue[]>? withValue = null)
    => result.PartialArray(Message);

  public IResult<TResult> AsResult<TResult>(TResult? _ = default)
    => _.Error(Message);

  public IResultArray<TResult> AsResultArray<TResult>(TResult[]? _ = default)
    => _.ErrorArray(Message);

  public IResult<TResult> Map<TResult>(SelectResult<TValue[], TResult> onValue, OnResult<TResult>? otherwise = null)
    => otherwise?.Invoke() ?? AsResult<TResult>();
}

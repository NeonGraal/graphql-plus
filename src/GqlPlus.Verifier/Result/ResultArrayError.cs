using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Result;

public readonly struct ResultArrayError<T> : IResultArray<T>, IResultError<T[]>
{
  public TokenMessage Message { get; }

  public ResultArrayError(TokenMessage message) => Message = message;

  public IResult<R> AsPartial<R>(R result, Action<T[]>? withValue = null, Action? action = null)
  {
    action?.Invoke();
    return result.Partial(Message);
  }

  public IResultArray<R> AsPartialArray<R>(IEnumerable<R> result, Action<T[]>? withValue = null)
    => result.PartialArray(Message);

  public IResult<R> AsResult<R>(R? _ = default)
    => _.Error(Message);

  public IResultArray<R> AsResultArray<R>(R[]? _ = default)
    => _.ErrorArray(Message);

  public IResult<R> Map<R>(SelectResult<T[], R> onValue, OnResult<R>? otherwise = null)
    => otherwise?.Invoke() ?? AsResult<R>();
}

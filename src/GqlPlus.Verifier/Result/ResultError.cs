namespace GqlPlus.Verifier.Result;

public readonly struct ResultError<T> : IResultError<T>
{
  public TokenMessage Message { get; }

  public ResultError(TokenMessage message) => Message = message;

  public IResult<R> AsPartial<R>(R result, Action<T>? withValue = null, Action? action = null)
  {
    action?.Invoke();
    return result.Partial(Message);
  }

  public IResult<R> AsResult<R>(R? _ = default)
    => _.Error(Message);

  public IResult<R> Map<R>(SelectResult<T, R> onValue, OnResult<R>? otherwise = null)
    => otherwise?.Invoke() ?? AsResult<R>();
}

using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Result;

public readonly struct ResultError<TValue>
  : IResultError<TValue>
{
  public TokenMessage Message { get; }

  public ResultError(TokenMessage message) => Message = message;

  public IResult<TResult> AsPartial<TResult>(TResult result, Action<TValue>? withValue = null, Action? action = null)
  {
    action?.Invoke();
    return result.Partial(Message);
  }

  public IResult<TResult> AsResult<TResult>(TResult? _ = default)
    => _.Error(Message);

  public IResult<TResult> Map<TResult>(SelectResult<TValue, TResult> onValue, OnResult<TResult>? otherwise = null)
    => otherwise?.Invoke() ?? AsResult<TResult>();
}

using GqlPlus.Token;

namespace GqlPlus.Result;

public readonly struct ResultPartial<TValue>
  : IResultPartial<TValue>
{
  public TValue Result { get; }
  public TokenMessage Message { get; }

  public ResultPartial(TValue result, TokenMessage message)
  {
    ArgumentNullException.ThrowIfNull(result);

    (Result, Message) = (result, message);
  }

  public IResult<TResult> AsPartial<TResult>(TResult result, Action<TValue>? withValue = null, Action? action = null)
  {
    withValue?.Invoke(Result);
    action?.Invoke();
    return result.Partial(Message);
  }

  public IResult<TResult> AsResult<TResult>(TResult? _ = default)
    => Result is TResult newResult
          ? newResult.Partial(Message)
          : _.Error(Message);

  public IResult<TResult> Map<TResult>(SelectResult<TValue, TResult> onValue, OnResult<TResult>? otherwise = null)
  {
    ArgumentNullException.ThrowIfNull(onValue);
    return onValue(Result);
  }
}

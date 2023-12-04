using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Result;

public readonly struct ResultPartial<T> : IResultPartial<T>
{
  public T Result { get; }
  public TokenMessage Message { get; }

  public ResultPartial(T result, TokenMessage message)
  {
    ArgumentNullException.ThrowIfNull(result);

    (Result, Message) = (result, message);
  }

  public IResult<R> AsPartial<R>(R result, Action<T>? withValue = null, Action? action = null)
  {
    withValue?.Invoke(Result);
    action?.Invoke();
    return result.Partial(Message);
  }

  public IResult<R> AsResult<R>(R? _ = default)
    => Result is R newResult
          ? newResult.Partial(Message)
          : _.Error(Message);

  public IResult<R> Map<R>(SelectResult<T, R> onValue, OnResult<R>? otherwise = null)
    => onValue(Result);
}

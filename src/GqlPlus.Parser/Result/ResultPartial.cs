using GqlPlus.Token;

namespace GqlPlus.Result;

public readonly struct ResultPartial<TValue>
  : IResultPartial<TValue>
{
  public TValue Result { get; }
  public TokenMessage Message { get; }

  public ResultPartial(TValue result, TokenMessage message)
  {
    result.ThrowIfNull();

    (Result, Message) = (result, message);
  }

  public IResult<TResult> AsPartial<TResult>(
    TResult result,
    Action<TValue>? withValue = null,
    Action? action = null
  )
  {
    withValue?.Invoke(Result);
    action?.Invoke();
    return result.Partial(Message);
  }

  public IResult<TResult> AsResult<TResult>(TResult? _ = default)
    => Result is TResult newResult
          ? newResult.Partial(Message)
          : _.Error(Message);

  public IResult<TResult> Map<TResult>(
    SelectResult<TValue, TResult> onValue,
    OnResult<TResult>? otherwise = null
  )
  {
    onValue.ThrowIfNull();
#pragma warning disable CA1062 // Validate arguments of public methods
    return onValue(Result);
#pragma warning restore CA1062 // Validate arguments of public methods
  }
}

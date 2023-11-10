namespace GqlPlus.Verifier;

public interface IResult<T>
{
  IResult<R> AsResult<R>(R? _ = default);
  IResult<R> AsPartial<R>(R result, Action<T>? action = null);
  IResult<R> Map<R>(SelectResult<T, R> onValue, OnResult<R>? otherwise = null);
}

public delegate IResult<T> OnResult<T>();
public delegate IResult<R> SelectResult<T, R>(T value);

public interface IResultValue<T> : IResult<T>
{
  T Result { get; }
}

public interface IResultOk<T> : IResultValue<T> { }

public interface IResultMessage<T> : IResult<T>
{
  ParseMessage Message { get; }
}

public interface IResultError<T> : IResultMessage<T> { }

public interface IResultPartial<T> : IResultValue<T>, IResultMessage<T> { }

public interface IResultEmpty<T> : IResult<T> { }

public readonly struct ResultOk<T> : IResultOk<T>
{
  public T Result { get; }

  public ResultOk(T result)
  {
    ArgumentNullException.ThrowIfNull(result);
    Result = result;
  }

  public IResult<R> AsPartial<R>(R result, Action<T>? action = null)
  {
    action?.Invoke(Result);
    return result.Ok();
  }

  public IResult<R> AsResult<R>(R? _ = default)
    => Result is R newResult
      ? newResult.Ok()
      : _.Empty();

  public IResult<R> Map<R>(SelectResult<T, R> onValue, OnResult<R>? otherwise = null)
    => onValue(Result);
}

public readonly struct ResultEmpty<T> : IResultEmpty<T>
{
  public IResult<R> AsPartial<R>(R result, Action<T>? action = null)
    => result.Ok();

  public IResult<R> AsResult<R>(R? _ = default)
    => _.Empty();

  public IResult<R> Map<R>(SelectResult<T, R> onValue, OnResult<R>? otherwise = null)
    => otherwise?.Invoke() ?? AsResult<R>();
}

public readonly struct ResultError<T> : IResultError<T>
{
  public ParseMessage Message { get; }

  public ResultError(ParseMessage message) => Message = message;

  public IResult<R> AsPartial<R>(R result, Action<T>? action = null)
    => result.Partial(Message);

  public IResult<R> AsResult<R>(R? _ = default)
    => _.Error(Message);

  public IResult<R> Map<R>(SelectResult<T, R> onValue, OnResult<R>? otherwise = null)
    => otherwise?.Invoke() ?? AsResult<R>();
}

public readonly struct ResultPartial<T> : IResultPartial<T>
{
  public T Result { get; }
  public ParseMessage Message { get; }

  public ResultPartial(T result, ParseMessage message)
  {
    ArgumentNullException.ThrowIfNull(result);

    (Result, Message) = (result, message);
  }

  public IResult<R> AsPartial<R>(R result, Action<T>? action = null)
  {
    action?.Invoke(Result);
    return result.Partial(Message);
  }

  public IResult<R> AsResult<R>(R? _ = default)
    => Result is R newResult
          ? newResult.Partial(Message)
          : _.Error(Message);

  public IResult<R> Map<R>(SelectResult<T, R> onValue, OnResult<R>? otherwise = null)
    => onValue(Result);
}

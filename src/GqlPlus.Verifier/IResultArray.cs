namespace GqlPlus.Verifier;

public interface IResultArray<T> : IResult<T[]>
{
  IResultArray<R> AsResultArray<R>(R[]? _ = default);
}

public delegate IResultArray<T> OnResultArray<T>();
public delegate IResultArray<R> SelectResultArray<T, R>(T[] value);

public readonly struct ResultArrayOk<T> : IResultArray<T>, IResultOk<T[]>
{
  public T[] Result { get; }

  public ResultArrayOk(T[] result) => Result = result;

  public IResult<R> AsPartial<R>(R result, Action<T[]>? withValue = null, Action? action = null)
  {
    withValue?.Invoke(Result);
    action?.Invoke();
    return result.Ok();
  }

  public IResult<R> AsResult<R>(R? _ = default)
    => Result is R newResult
      ? newResult.Ok()
      : _.Empty();

  public IResultArray<R> AsResultArray<R>(R[]? _ = default)
    => Result is R[] newResult
      ? newResult.OkArray()
      : _.EmptyArray();

  public IResult<R> Map<R>(SelectResult<T[], R> onValue, OnResult<R>? otherwise = null)
    => onValue(Result);
}

public readonly struct ResultArrayEmpty<T> : IResultArray<T>, IResultEmpty<T[]>
{
  public IResult<R> AsPartial<R>(R result, Action<T[]>? withValue = null, Action? action = null)
  {
    action?.Invoke();
    return result.Ok();
  }

  public IResult<R> AsResult<R>(R? _ = default)
    => _.Empty();

  public IResultArray<R> AsResultArray<R>(R[]? _ = default)
    => _.EmptyArray();

  public IResult<R> Map<R>(SelectResult<T[], R> onValue, OnResult<R>? otherwise = null)
    => otherwise?.Invoke() ?? AsResult<R>();
}

public readonly struct ResultArrayError<T> : IResultArray<T>, IResultError<T[]>
{
  public ParseMessage Message { get; }

  public ResultArrayError(ParseMessage message) => Message = message;

  public IResult<R> AsPartial<R>(R result, Action<T[]>? withValue = null, Action? action = null)
  {
    action?.Invoke();
    return result.Partial(Message);
  }

  public IResult<R> AsResult<R>(R? _ = default)
    => _.Error(Message);

  public IResultArray<R> AsResultArray<R>(R[]? _ = default)
    => _.ErrorArray(Message);

  public IResult<R> Map<R>(SelectResult<T[], R> onValue, OnResult<R>? otherwise = null)
    => otherwise?.Invoke() ?? AsResult<R>();
}

public readonly struct ResultArrayPartial<T> : IResultArray<T>, IResultPartial<T[]>
{
  public T[] Result { get; }
  public ParseMessage Message { get; }

  public ResultArrayPartial(T[] result, ParseMessage message)
    => (Result, Message) = (result, message);

  public IResult<R> AsPartial<R>(R result, Action<T[]>? withValue = null, Action? action = null)
  {
    withValue?.Invoke(Result);
    action?.Invoke();
    return result.Partial(Message);
  }

  public IResult<R> AsResult<R>(R? _ = default)
    => Result is R newResult
          ? newResult.Partial(Message)
          : _.Error(Message);

  public IResultArray<R> AsResultArray<R>(R[]? _ = default)
    => Result is R[] newResult
          ? newResult.PartialArray(Message)
          : _.ErrorArray(Message);

  public IResult<R> Map<R>(SelectResult<T[], R> onValue, OnResult<R>? otherwise = null)
    => onValue(Result);
}

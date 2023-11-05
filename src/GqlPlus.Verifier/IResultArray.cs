namespace GqlPlus.Verifier;

public interface IResultArray<T> : IResult<T[]>
{
  IResultArray<R> AsResultArray<R>();
}

public readonly struct ResultArrayOk<T> : IResultArray<T>, IResultOk<T[]>
{
  public T[] Result { get; }

  public ResultArrayOk(T[] result) => Result = result ?? Array.Empty<T>();

  public IResult<R> AsResult<R>()
    => Result is R newResult
      ? new ResultOk<R>(newResult)
      : new ResultEmpty<R>();
  public IResultArray<R> AsResultArray<R>()
    => Result is R[] newResult
      ? new ResultArrayOk<R>(newResult)
      : new ResultArrayEmpty<R>();
}

public readonly struct ResultArrayError<T> : IResultArray<T>, IResultMessage<T[]>
{
  public ParseMessage Message { get; }

  public ResultArrayError(ParseMessage message) => Message = message;

  public IResult<R> AsResult<R>()
    => new ResultError<R>(Message);
  public IResultArray<R> AsResultArray<R>()
    => new ResultArrayError<R>(Message);
}

public readonly struct ResultArrayEmpty<T> : IResultArray<T>
{
  public IResult<R> AsResult<R>() => new ResultEmpty<R>();
  public IResultArray<R> AsResultArray<R>() => new ResultArrayEmpty<R>();
}

public readonly struct ResultArrayPartial<T> : IResultArray<T>, IResultValue<T[]>, IResultMessage<T[]>
{
  public T[] Result { get; }
  public ParseMessage Message { get; }

  public ResultArrayPartial(T[] result, ParseMessage message)
    => (Result, Message) = (result ?? Array.Empty<T>(), message);

  public IResult<R> AsResult<R>()
    => Result is R newResult
          ? new ResultPartial<R>(newResult, Message)
          : new ResultError<R>(Message);
  public IResultArray<R> AsResultArray<R>()
    => Result is R[] newResult
          ? new ResultArrayPartial<R>(newResult, Message)
          : new ResultArrayError<R>(Message);
}

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

  public ResultArrayOk(T[] result) => Result = result ?? Array.Empty<T>();

  public IResult<R> AsResult<R>(R? _ = default)
    => Result is R newResult
      ? new ResultOk<R>(newResult)
      : new ResultEmpty<R>();
  public IResultArray<R> AsResultArray<R>(R[]? _ = default)
    => Result is R[] newResult
      ? new ResultArrayOk<R>(newResult)
      : new ResultArrayEmpty<R>();
}

public readonly struct ResultArrayError<T> : IResultArray<T>, IResultError<T[]>
{
  public ParseMessage Message { get; }

  public ResultArrayError(ParseMessage message) => Message = message;

  public IResult<R> AsResult<R>(R? _ = default)
    => new ResultError<R>(Message);
  public IResultArray<R> AsResultArray<R>(R[]? _ = default)
    => new ResultArrayError<R>(Message);
}

public readonly struct ResultArrayEmpty<T> : IResultArray<T>, IResultEmpty<T[]>
{
  public IResult<R> AsResult<R>(R? _ = default) => new ResultEmpty<R>();
  public IResultArray<R> AsResultArray<R>(R[]? _ = default) => new ResultArrayEmpty<R>();
}

public readonly struct ResultArrayPartial<T> : IResultArray<T>, IResultPartial<T[]>
{
  public T[] Result { get; }
  public ParseMessage Message { get; }

  public ResultArrayPartial(T[] result, ParseMessage message)
    => (Result, Message) = (result ?? Array.Empty<T>(), message);

  public IResult<R> AsResult<R>(R? _ = default)
    => Result is R newResult
          ? new ResultPartial<R>(newResult, Message)
          : new ResultError<R>(Message);
  public IResultArray<R> AsResultArray<R>(R[]? _ = default)
    => Result is R[] newResult
          ? new ResultArrayPartial<R>(newResult, Message)
          : new ResultArrayError<R>(Message);
}

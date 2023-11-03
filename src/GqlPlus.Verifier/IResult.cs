namespace GqlPlus.Verifier;

public interface IResult<T> { }

public readonly struct ResultOk<T> : IResult<T>
{
  public T Result { get; }

  public ResultOk(T result)
  {
    ArgumentNullException.ThrowIfNull(result);
    Result = result;
  }
}

public readonly struct ResultError<T> : IResult<T>
{
  public ParseMessage Error { get; }

  public ResultError(ParseMessage error) => Error = error;
}

public readonly struct ResultEmpty<T> : IResult<T> { }

public readonly struct ResultPartial<T> : IResult<T>
{
  public T Result { get; }
  public ParseMessage Error { get; }

  public ResultPartial(T result, ParseMessage error)
  {
    ArgumentNullException.ThrowIfNull(result);

    (Result, Error) = (result, error);
  }
}

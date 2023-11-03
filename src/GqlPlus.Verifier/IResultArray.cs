namespace GqlPlus.Verifier;

public interface IResultArray<T> { }

public readonly struct ResultArrayOk<T> : IResultArray<T>
{
  public T[] Result { get; }

  public ResultArrayOk(T[] result) => Result = result ?? Array.Empty<T>();
}

public readonly struct ResultArrayError<T> : IResultArray<T>
{
  public ParseMessage Error { get; }

  public ResultArrayError(ParseMessage error) => Error = error;
}

public readonly struct ResultArrayEmpty<T> : IResultArray<T>
{
}

public readonly struct ResultArrayPartial<T> : IResultArray<T>
{
  public T[]? Result { get; }
  public ParseMessage Error { get; }

  public ResultArrayPartial(T[] partial, ParseMessage error)
    => (Result, Error) = (partial ?? Array.Empty<T>(), error);
}

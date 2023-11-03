namespace GqlPlus.Verifier;

public interface IResultArray<T> { }

public readonly struct ResultArrayOk<T> : IResultArray<T>, IResultValue<T[]>
{
  public T[] Result { get; }

  public ResultArrayOk(T[] result) => Result = result ?? Array.Empty<T>();
}

public readonly struct ResultArrayError<T> : IResultArray<T>, IResultMessage<T[]>
{
  public ParseMessage Message { get; }

  public ResultArrayError(ParseMessage message) => Message = message;
}

public readonly struct ResultArrayEmpty<T> : IResultArray<T> { }

public readonly struct ResultArrayPartial<T> : IResultArray<T>, IResultValue<T[]?>, IResultMessage<T[]?>
{
  public T[]? Result { get; }
  public ParseMessage Message { get; }

  public ResultArrayPartial(T[] result, ParseMessage message)
    => (Result, Message) = (result ?? Array.Empty<T>(), message);
}

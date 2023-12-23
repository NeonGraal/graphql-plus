namespace GqlPlus.Verifier.Result;

public interface IResult<T>
{
  IResult<R> AsResult<R>(R? _ = default);
  IResult<R> AsPartial<R>(R result, Action<T>? withValue = null, Action? action = null);
  IResult<R> Map<R>(SelectResult<T, R> onValue, OnResult<R>? otherwise = null);
}

public delegate IResult<T> OnResult<T>();
public delegate IResult<R> SelectResult<T, R>(T value);

namespace GqlPlus.Result;

public interface IResult<TValue>
{
  IResult<TResult> AsResult<TResult>(TResult? _ = default);
  IResult<TResult> AsPartial<TResult>(TResult result, Action<TValue>? withValue = null, Action? action = null);
  IResult<TResult> Map<TResult>(SelectResult<TValue, TResult> onValue, OnResult<TResult>? otherwise = null);
}

public delegate IResult<T> OnResult<T>();
public delegate IResult<TResult> SelectResult<TValue, TResult>(TValue value);

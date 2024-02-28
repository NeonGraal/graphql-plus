namespace GqlPlus.Verifier.Result;

public interface IResultArray<TValue>
  : IResult<TValue[]>
{
  IResultArray<TResult> AsPartialArray<TResult>(IEnumerable<TResult> result, Action<TValue[]>? withValue = null);
  IResultArray<TResult> AsResultArray<TResult>(TResult[]? _ = default);
}

public delegate IResultArray<T> OnResultArray<T>();
public delegate IResultArray<TResult> SelectResultArray<T, TResult>(T[] value);

namespace GqlPlus.Verifier.Result;

public interface IResultArray<T> : IResult<T[]>
{
  IResultArray<R> AsPartialArray<R>(IEnumerable<R> result, Action<T[]>? withValue = null);
  IResultArray<R> AsResultArray<R>(R[]? _ = default);
}

public delegate IResultArray<T> OnResultArray<T>();
public delegate IResultArray<R> SelectResultArray<T, R>(T[] value);

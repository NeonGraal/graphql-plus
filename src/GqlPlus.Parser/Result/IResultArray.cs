namespace GqlPlus.Result;

public interface IResultArray<TValue>
  : IResult<IEnumerable<TValue>>
{
  IResultArray<TResult> AsPartialArray<TResult>(IEnumerable<TResult> result, Action<IEnumerable<TValue>>? withValue = null);
  IResultArray<TResult> AsResultArray<TResult>(IEnumerable<TValue>? _ = default);
}

public delegate IResultArray<TValue> OnResultArray<TValue>();
public delegate IResultArray<TResult> SelectResultArray<TValue, TResult>(IEnumerable<TValue> value);

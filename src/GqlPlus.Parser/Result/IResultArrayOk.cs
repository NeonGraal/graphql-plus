namespace GqlPlus.Result;

public interface IResultArrayOk<T> : IResultArray<T>, IResultOk<IEnumerable<T>>;

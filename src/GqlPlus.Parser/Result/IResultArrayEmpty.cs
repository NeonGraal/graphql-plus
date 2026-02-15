namespace GqlPlus.Result;

public interface IResultArrayEmpty<T> : IResultArray<T>, IResultEmpty<IEnumerable<T>>;

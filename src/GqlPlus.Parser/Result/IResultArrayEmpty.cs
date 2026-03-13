namespace GqlPlus.Result;

internal interface IResultArrayEmpty<T> : IResultArray<T>, IResultEmpty<IEnumerable<T>>;

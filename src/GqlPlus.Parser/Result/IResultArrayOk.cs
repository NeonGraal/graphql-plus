namespace GqlPlus.Result;

internal interface IResultArrayOk<T> : IResultArray<T>, IResultOk<IEnumerable<T>>;

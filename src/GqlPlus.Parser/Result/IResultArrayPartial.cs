namespace GqlPlus.Result;

internal interface IResultArrayPartial<T>
  : IResultArray<T>, IResultPartial<IEnumerable<T>>
{ }

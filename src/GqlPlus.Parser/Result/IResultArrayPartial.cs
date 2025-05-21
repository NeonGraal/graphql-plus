namespace GqlPlus.Result;

public interface IResultArrayPartial<T>
  : IResultArray<T>, IResultPartial<IEnumerable<T>>
{ }

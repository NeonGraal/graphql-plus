namespace GqlPlus.Result;

public interface IResultValue<T> : IResult<T>
{
  T Result { get; }
}

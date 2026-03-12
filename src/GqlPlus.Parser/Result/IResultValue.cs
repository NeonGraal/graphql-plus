namespace GqlPlus.Result;

internal interface IResultValue<T> : IResult<T>
{
  T Result { get; }
}

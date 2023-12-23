namespace GqlPlus.Verifier.Result;

public interface IResultValue<T> : IResult<T>
{
  T Result { get; }
}

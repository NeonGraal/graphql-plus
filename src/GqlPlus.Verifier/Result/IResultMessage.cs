using GqlPlus.Token;

namespace GqlPlus.Result;

public interface IResultMessage<T> : IResult<T>
{
  TokenMessage Message { get; }
}

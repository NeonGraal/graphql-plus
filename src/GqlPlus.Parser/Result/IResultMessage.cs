using GqlPlus.Token;

namespace GqlPlus.Result;

public interface IResultMessage<T> : IResult<T>, IResultMessage { }

public interface IResultMessage
{
  TokenMessage Message { get; }
}

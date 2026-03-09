using GqlPlus.Token;

namespace GqlPlus.Result;

internal interface IResultMessage<T> : IResult<T>, IResultMessage;

public interface IResultMessage
{
  TokenMessage Message { get; }
}

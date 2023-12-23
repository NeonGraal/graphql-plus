using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Result;

public interface IResultMessage<T> : IResult<T>
{
  TokenMessage Message { get; }
}

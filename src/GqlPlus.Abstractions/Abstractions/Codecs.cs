using GqlPlus.Structures;

namespace GqlPlus.Abstractions;

public interface IEncoder<TInput>
{
  Structured Encode(TInput input);
}

public interface IDecoder<TOutput>
{
  IMessages Decode(IValue input, out TOutput? output);
}

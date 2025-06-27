using GqlPlus.Structures;

namespace GqlPlus.Abstractions;

public interface IEncoder<TModel>
{
  Structured Encode(TModel model);
}

public interface IDecoder<TModel>
{
  TModel Decode(IValue value);
}

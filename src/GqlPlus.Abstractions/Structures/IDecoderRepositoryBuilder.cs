namespace GqlPlus.Structures;

public interface IDecoderRepositoryBuilder
{
  IDecoderRepositoryBuilder AddDecoder<T>(Factory<IDecoder<T>, IDecoderRepository> factory);
  IDecoderRepositoryBuilder AddDecoder<TDecoder, TBase>(Factory<TDecoder, IDecoderRepository> factory)
    where TDecoder : class, IDecoder<TBase>;
}

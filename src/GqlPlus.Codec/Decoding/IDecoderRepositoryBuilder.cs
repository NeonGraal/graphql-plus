namespace GqlPlus.Decoding;

internal interface IDecoderRepositoryBuilder
{
  IDecoderRepositoryBuilder AddDecoder<T>(Factory<IDecoder<T>, IDecoderRepository> factory);
  IDecoderRepositoryBuilder AddNameFilter(Factory<INameFilterDecoder, IDecoderRepository> factory);
}

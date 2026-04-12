namespace GqlPlus.Decoding;

internal interface IDecoderRepository
{
  IDecoder<T> DecoderFor<T>();
  INameFilterDecoder NameFilterDecoder { get; }
}

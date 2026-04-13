namespace GqlPlus.Structures;

public interface IDecoderRepository
{
  IDecoder<T> DecoderFor<T>();
  TDecoder DecoderFor<TDecoder, TBase>()
    where TDecoder : class, IDecoder<TBase>;
}

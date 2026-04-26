using Microsoft.Extensions.Logging;

namespace GqlPlus.Decoding;

internal class DecoderRepository(
  DecoderRepositoryBuilder builder,
  ILoggerFactory loggerFactory
) : BaseRepository<IDecoderRepository>(loggerFactory)
  , IDecoderRepository
{
  private readonly DecoderRepositoryBuilder _builder = builder;

  public IDecoder<T> DecoderFor<T>()
    => Cached<T, IDecoder<T>>(_builder.Decoders, "decoder", this);
  public TDecoder DecoderFor<TDecoder, TBase>()
    where TDecoder : class, IDecoder<TBase>
    => Cached<TDecoder, TDecoder>(_builder.Decoders, $"decoder{typeof(TBase).TidyTypeName()}", this);
}

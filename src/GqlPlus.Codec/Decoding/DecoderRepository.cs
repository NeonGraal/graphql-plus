using Microsoft.Extensions.Logging;

namespace GqlPlus.Decoding;

internal class DecoderRepository
  : BaseRepository<IDecoderRepository>
  , IDecoderRepository
{
  private readonly DecoderRepositoryBuilder _builder;

  public DecoderRepository(DecoderRepositoryBuilder builder, ILoggerFactory loggerFactory)
    : base(loggerFactory)
    => _builder = builder;

  public IDecoder<T> DecoderFor<T>()
    => Cached<T, IDecoder<T>>(_builder.Decoders, "decoder", this);
  public TDecoder DecoderFor<TDecoder, TBase>()
    where TDecoder : class, IDecoder<TBase>
    => Cached<TDecoder, TDecoder>(_builder.Decoders, $"decoder{typeof(TBase).TidyTypeName()}", this);
}

using Microsoft.Extensions.Logging;

namespace GqlPlus.Decoding;

internal class DecoderRepository
  : BaseRepository<IDecoderRepository>
  , IDecoderRepository
{
  private readonly DecoderRepositoryBuilder _builder;
  private readonly Lazy<INameFilterDecoder> _nameFilter;

  public DecoderRepository(DecoderRepositoryBuilder builder, ILoggerFactory loggerFactory)
    : base(loggerFactory)
  {
    _builder = builder;
    _nameFilter = new(() => builder.NameFilter is not null
      ? builder.NameFilter(this)
      : new NameFilterModelDecoder());
  }

  public IDecoder<T> DecoderFor<T>()
    => Cached<T, IDecoder<T>>(_builder.Decoders, "decoder", this);

  public INameFilterDecoder NameFilterDecoder => _nameFilter.Value;
}

using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

namespace GqlPlus.Decoding;

internal class DecoderRepository(
  DecoderRepositoryBuilder builder,
  ILoggerFactory loggerFactory
) : BaseRepository<IDecoderRepository>(loggerFactory)
  , IDecoderRepository
{
  private readonly DecoderRepositoryBuilder _builder = builder;

  public IDecoder<T> DecoderFor<T>([CallerMemberName] string callerName = "")
    => Cached<T, IDecoder<T>>(_builder.Decoders, "decoder for " + callerName, this);
  public TDecoder DecoderFor<TDecoder, TBase>([CallerMemberName] string callerName = "")
    where TDecoder : class, IDecoder<TBase>
    => Cached<TDecoder, TDecoder>(_builder.Decoders, $"decoder for {callerName} ({typeof(TBase).TidyTypeName()})", this);
}

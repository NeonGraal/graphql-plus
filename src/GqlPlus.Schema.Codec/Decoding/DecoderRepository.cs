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

  public Decoder<T>.D DecoderFor<T>([CallerMemberName] string callerName = "")
    => () => Cached<T, IDecoder<T>>(_builder.Decoders, "decoder for " + callerName, this);

  public Decoder<TBase>.D DecoderFor<TDecoder, TBase>([CallerMemberName] string callerName = "")
    where TDecoder : class, IDecoder<TBase>
    => () => Cached<TDecoder, IDecoder<TBase>>(_builder.Decoders, $"decoder for {callerName} ({typeof(TBase).TidyTypeName()})", this);
}

using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

namespace GqlPlus.Decoding;

internal sealed class DecoderRepoWrapper(
  IDecoderRepository repo
) : RepositoryWrapperBase<IDecoderRepository, DecoderRepoWrapper>(repo)
  , IDecoderRepository
{
  protected override IDecoderRepository Wrapper => this;

  public ILoggerFactory LoggerFactory => repo.LoggerFactory;

  public static void WriteTree(ILoggerFactory loggerFactory,
    Action<IDecoderRepositoryBuilder> configureDecoders)
  {
    DecoderRepositoryBuilder repoBuilder = new();
    configureDecoders(repoBuilder);

    DecoderRepoWrapper repo = new(new DecoderRepository(repoBuilder, loggerFactory));
    repo.WriteFactories("Decoder", repoBuilder.AllFactories);
  }

  public Defer<IDecoder<T>>.D DecoderFor<T>([CallerMemberName] string callerName = "")
    => AddRelationship<T>(callerName)
      .DecoderFor<T>(callerName);
  public Defer<TDecoder>.D DecoderFor<TDecoder, TBase>(string callerName)
    where TDecoder : class, IDecoder<TBase>
    => AddRelationship<TDecoder>(callerName)
    .DecoderFor<TDecoder, TBase>(callerName);
}

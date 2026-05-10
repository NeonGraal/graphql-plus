using System.Runtime.CompilerServices;
using GqlPlus.Decoding;
using Microsoft.Extensions.Logging;

namespace GqlPlus.Encoding;

internal sealed class EncoderRepoWrapper(
  IEncoderRepository repo
) : RepositoryWrapperBase<IEncoderRepository, EncoderRepoWrapper>(repo)
  , IEncoderRepository
{
  protected override IEncoderRepository Wrapper => this;

  public ILoggerFactory LoggerFactory => repo.LoggerFactory;

  public static void WriteTree(ILoggerFactory loggerFactory,
    Action<IEncoderRepositoryBuilder> configureEncoders)
  {
    EncoderRepositoryBuilder repoBuilder = new();
    configureEncoders(repoBuilder);

    EncoderRepoWrapper repo = new(new EncoderRepository(repoBuilder, loggerFactory));
    repo.WriteFactories("Encoder", repoBuilder.AllFactories);
  }

  public Defer<IEncoder<T>>.D EncoderFor<T>([CallerMemberName] string callerName = "")
    => AddRelationship<T>(callerName)
      .EncoderFor<T>(callerName);
  public Defer<TList>.DA EncodersFor<TList>([CallerMemberName] string callerName = "")
    where TList : class
    => AddRelationship<TList>(callerName)
      .EncodersFor<TList>(callerName);
}

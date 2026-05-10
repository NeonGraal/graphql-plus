using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

namespace GqlPlus.Resolving;

internal sealed class ResolverRepoWrapper(
  IResolverRepository repo
) : RepositoryWrapperBase<IResolverRepository, ResolverRepoWrapper>(repo)
  , IResolverRepository
{
  protected override IResolverRepository Wrapper => this;

  public ILoggerFactory LoggerFactory => repo.LoggerFactory;

  public DeferList<ITypeResolver>.D TypeResolvers([CallerMemberName] string callerName = "")
    => AddRelationship<ITypeResolver>(callerName)
      .TypeResolvers(callerName);

  public static void WriteTree(ILoggerFactory loggerFactory,
    Action<IResolverRepositoryBuilder> configureResolvers)
  {
    ResolverRepositoryBuilder repoBuilder = new();
    configureResolvers(repoBuilder);

    ResolverRepoWrapper repo = new(new ResolverRepository(repoBuilder, loggerFactory));
    repo.WriteFactories("Resolver", repoBuilder.AllFactories);
  }

  public DeferOne<IResolver<T>>.D ResolverFor<T>([CallerMemberName] string callerName = "")
    where T : IModelBase
    => AddRelationship<T>(callerName)
      .ResolverFor<T>(callerName);
}

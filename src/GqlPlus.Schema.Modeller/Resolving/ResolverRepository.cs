using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

namespace GqlPlus.Resolving;

internal class ResolverRepository(
  ResolverRepositoryBuilder builder,
  ILoggerFactory loggerFactory
) : BaseRepository<IResolverRepository>(loggerFactory)
  , IResolverRepository
{
  public Resolver<T>.D ResolverFor<T>([CallerMemberName] string callerName = "")
    where T : IModelBase
    => () => Cached<T, IResolver<T>>(builder.Resolvers, "resolver for " + callerName, this);

  public DeferList<ITypeResolver>.D TypeResolvers([CallerMemberName] string callerName = "")
    => () => InstancesFor<ITypeResolver>(builder.TypeResolverFactories, this);
}

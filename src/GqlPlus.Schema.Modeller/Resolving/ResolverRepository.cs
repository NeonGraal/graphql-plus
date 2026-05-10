using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

namespace GqlPlus.Resolving;

internal class ResolverRepository
  : BaseRepository<IResolverRepository>
  , IResolverRepository
{
  private readonly ResolverRepositoryBuilder _builder;
  private readonly Lazy<IEnumerable<ITypeResolver>> _typeResolvers;

  public ResolverRepository(ResolverRepositoryBuilder builder, ILoggerFactory loggerFactory)
    : base(loggerFactory)
  {
    _builder = builder;
    _typeResolvers = new(() => [.. builder.TypeResolverFactories.Select(f => (ITypeResolver)f(this))]);
  }

  public DeferOne<IResolver<T>>.D ResolverFor<T>([CallerMemberName] string callerName = "")
    where T : IModelBase
    => () => Cached<T, IResolver<T>>(_builder.Resolvers, "resolver for " + callerName, this);

  public DeferList<ITypeResolver>.D TypeResolvers([CallerMemberName] string callerName = "")
    => () => _typeResolvers.Value;
}

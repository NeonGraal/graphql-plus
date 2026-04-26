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

  public IResolver<T> ResolverFor<T>()
    where T : IModelBase
    => Cached<T, IResolver<T>>(_builder.Resolvers, "resolver", this);

  public IEnumerable<ITypeResolver> TypeResolvers => _typeResolvers.Value;
}

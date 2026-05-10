namespace GqlPlus.Resolving;

internal class ResolverRepositoryBuilder
  : BaseFactory<IResolverRepository>, IResolverRepositoryBuilder
{
  internal readonly FactoryDict Resolvers = [];
  internal readonly FactoryList TypeResolverFactories = [];

  public IEnumerable<KeyValuePair<Type, Factory<object, IResolverRepository>>> AllFactories
    => [..Resolvers,
    .. TypeResolverFactories.Select(FactoryKeyValue<ITypeResolver>)];

  public IResolverRepositoryBuilder AddResolver<TModel>(Factory<IResolver<TModel>, IResolverRepository> factory)
    where TModel : IModelBase
    => this.FluentAction(b => b.Resolvers[typeof(TModel)] = factory);

  public IResolverRepositoryBuilder AddTypeResolver<TModel>(Factory<ITypeResolver, IResolverRepository> factory)
    where TModel : IModelBase
    => this.FluentAction(b => {
      b.Resolvers[typeof(TModel)] = factory;
      b.TypeResolverFactories.Add(r => ((Defer<IResolver<TModel>>.L)r.ResolverFor<TModel>()).I);
    });
}

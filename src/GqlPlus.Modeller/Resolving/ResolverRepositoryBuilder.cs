namespace GqlPlus.Resolving;

internal class ResolverRepositoryBuilder
  : BaseFactory<IResolverRepository>, IResolverRepositoryBuilder
{
  internal readonly FactoryDict Resolvers = [];
  internal readonly FactoryList TypeResolverFactories = [];

  public IResolverRepositoryBuilder AddResolver<TModel>(Factory<IResolver<TModel>, IResolverRepository> factory)
    where TModel : IModelBase
    => this.FluentAction(b => b.Resolvers[typeof(TModel)] = factory);

  public IResolverRepositoryBuilder AddTypeResolver<TModel>(Factory<ITypeResolver, IResolverRepository> factory)
    where TModel : IModelBase
    => this.FluentAction(b => {
      b.Resolvers[typeof(TModel)] = factory;
      b.TypeResolverFactories.Add(r => r.ResolverFor<TModel>());
    });
}

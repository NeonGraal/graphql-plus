namespace GqlPlus.Resolving;

internal interface IResolverRepositoryBuilder
{
  IResolverRepositoryBuilder AddResolver<TModel>(Factory<IResolver<TModel>, IResolverRepository> factory)
    where TModel : IModelBase;

  IResolverRepositoryBuilder AddTypeResolver<TModel>(Factory<IResolver<TModel>, IResolverRepository> factory)
    where TModel : IModelBase;
}

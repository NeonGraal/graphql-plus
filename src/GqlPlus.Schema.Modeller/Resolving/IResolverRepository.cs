namespace GqlPlus.Resolving;

internal interface IResolverRepository
{
  IResolver<T> ResolverFor<T>()
    where T : IModelBase;

  IEnumerable<ITypeResolver> TypeResolvers { get; }
}

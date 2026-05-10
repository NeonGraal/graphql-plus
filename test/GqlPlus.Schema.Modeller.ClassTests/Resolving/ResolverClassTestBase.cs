namespace GqlPlus.Resolving;

public abstract class ResolverClassTestBase<TModel>
  : SubstituteBase
    where TModel : IModelBase
{
  protected abstract IResolver<TModel> Resolver { get; }
  internal ModelsContext Context { get; } = [];

  protected static IResolver<T> RFor<T>()
    where T : IModelBase
  {
    IResolver<T> result = A.Of<IResolver<T>>();
    return result;
  }

  internal void ResolveForReturns<T>(IResolverRepository resolvers, IResolver<T> result)
    where T : IModelBase
  {
    Defer<IResolver<T>>.D factory = () => result;
    resolvers.ResolverFor<T>().ReturnsForAnyArgs(factory);
  }
}

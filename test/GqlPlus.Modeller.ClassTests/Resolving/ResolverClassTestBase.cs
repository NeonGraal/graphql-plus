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
    IResolver<T> result = For<IResolver<T>>();
    return result;
  }
}

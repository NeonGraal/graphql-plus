namespace GqlPlus.Resolving;

public abstract class ResolverClassTestBase<TModel>
  : SubstituteBase
    where TModel : IModelBase
{
  protected abstract IResolver<TModel> Resolver { get; }
  protected IModelsContext Context { get; } = new ModelsContext();

  protected static IResolver<T> RFor<T>()
    where T : IModelBase
  {
    IResolver<T> result = For<IResolver<T>>();
    return result;
  }
}

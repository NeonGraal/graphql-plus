namespace GqlPlus.Resolving;

public abstract class ResolverClassTestBase<TModel>(
  IResolveContext context
) : SubstituteBase
    where TModel : IModelBase
{
  protected abstract IResolver<TModel> Resolver { get; }
  protected IResolveContext Context { get; } = context;

  protected ResolverClassTestBase()
    : this(For<IResolveContext>())
  { }

  protected static IResolver<T> RFor<T>()
    where T : IModelBase
  {
    IResolver<T> result = For<IResolver<T>>();
    return result;
  }
}

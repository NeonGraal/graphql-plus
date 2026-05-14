using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Resolving;

public interface IResolver<TModel>
  where TModel : IModelBase
{
  TModel Resolve(TModel model, IResolveContext context);
}

public class Resolver<TModel>(
  Resolver<TModel>.D factory
) : DeferOne<IResolver<TModel>>(factory)
  , IResolver<TModel>
  where TModel : IModelBase
{
  public TModel Resolve(TModel model, IResolveContext context)
    => I.Resolve(model, context);

  public static implicit operator Resolver<TModel>(D factory)
    => new(factory.ThrowIfNull());
}

public interface IResolveContext
{
  bool TryGetType<TModel>(string label, [NotNullWhen(true)] string? name, [NotNullWhen(true)] out TModel? model, bool canError = true)
    where TModel : IModelBase;
}

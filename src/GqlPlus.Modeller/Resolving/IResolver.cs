using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Resolving;

public interface IResolver<TModel>
  where TModel : IModelBase
{
  TModel Resolve(TModel model, IResolveContext context);
}

public interface IResolveContext
{
  bool TryGetType<TModel>(string context, string? name, [NotNullWhen(true)] out TModel? model, bool canError = true)
    where TModel : IModelBase;
}

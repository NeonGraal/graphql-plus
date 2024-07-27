using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Resolving;

internal class ArgumentsContext(
  IResolveContext parent
) : Map<IObjArgModel>
  , IResolveContext
{
  internal IResolveContext Parent { get; } = parent;

  public bool TryGetArg<TArg>(string label, string name, [NotNullWhen(true)] out TArg? arg, bool canError = true)
    where TArg : IObjArgModel
  {
    arg = default;

    if (!TryGetValue("$" + name, out IObjArgModel? argValue)) {
      return false;
    }

    if (!argValue.IsTypeParam && argValue is TArg argModel) {
      arg = argModel;
      return true;
    }

    return Parent is ArgumentsContext parentContext
        && parentContext.TryGetArg(label, name, out arg, canError);
  }

  public bool TryGetType<TModel>(string label, string? name, [NotNullWhen(true)] out TModel? model, bool canError = true)
    where TModel : IModelBase
  {
    model = default;
    if (name is null) {
      return false;
    }

    if (TryGetValue(name, out IObjArgModel? type) && type is TModel modelType) {
      model = modelType;
      return true;
    }

    return Parent.TryGetType(label, name, out model, canError);
  }
}

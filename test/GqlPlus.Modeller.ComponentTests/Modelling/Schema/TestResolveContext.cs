using System.Diagnostics.CodeAnalysis;
using GqlPlus.Resolving;

namespace GqlPlus.Modelling.Schema;

internal sealed class TestResolveContext
  : Dictionary<string, BaseTypeModel>
  , IResolveContext
{
  public bool TryGetType<TModel>(string label, string? name, [NotNullWhen(true)] out TModel? model, bool canError = true)
    where TModel : IModelBase
  {
    if (name is not null && TryGetValue(name, out BaseTypeModel? type) && type is TModel modelType) {
      model = modelType;
      return true;
    }

    model = default;
    return false;
  }
}

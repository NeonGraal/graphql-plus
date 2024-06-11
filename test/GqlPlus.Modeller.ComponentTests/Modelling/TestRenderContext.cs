using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Modelling;

internal sealed class TestRenderContext
  : Dictionary<string, BaseTypeModel>
  , IRenderContext
{
  public bool TryGetType<TModel>(string context, string? name, [NotNullWhen(true)] out TModel? model)
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

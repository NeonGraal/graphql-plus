using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal sealed class TestRenderContext
  : Dictionary<string, BaseTypeModel>, IRenderContext
{
  public bool TryGetType<TModel>(string context, string? name, [NotNullWhen(true)] out TModel? model)
    where TModel : BaseTypeModel
  {
    if (name is not null && TryGetValue(name, out var type) && type is TModel modelType) {
      model = modelType;
      return true;
    }

    model = null;
    return false;
  }
}

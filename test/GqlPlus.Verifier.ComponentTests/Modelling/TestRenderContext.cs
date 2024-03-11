using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal sealed class TestRenderContext
  : Dictionary<string, BaseTypeModel>, IRenderContext
{
  public bool TryGetType(string? name, [NotNullWhen(true)] out BaseTypeModel? type)
  {
    type = null;
    return name is not null && TryGetValue(name, out type);
  }
}

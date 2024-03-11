using GqlPlus.Verifier.Modelling;

namespace GqlPlus.Verifier.Rendering;

public interface IRendering
{
  RenderStructure Render(IRenderContext context);
}

public interface IRenderContext
{
  bool TryGetType(string? name, [NotNullWhen(true)] out BaseTypeModel? type);
}

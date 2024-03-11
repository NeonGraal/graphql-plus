using GqlPlus.Verifier.Modelling;

namespace GqlPlus.Verifier.Rendering;

public interface IRendering
{
  RenderStructure Render(IRenderContext context);
}

public interface IRenderContext
{
  bool TryGetType<TModel>(string? name, [NotNullWhen(true)] out TModel? model)
    where TModel : BaseTypeModel;
}

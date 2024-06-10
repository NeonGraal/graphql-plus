using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Rendering;

public interface IRenderer<TModel>
  where TModel : IModelBase
{
  RenderStructure Render(TModel model, IRenderContext context);
}

public interface IRenderContext
{
  bool TryGetType<TModel>(string context, string? name, [NotNullWhen(true)] out TModel? model)
    where TModel : IModelBase;
}

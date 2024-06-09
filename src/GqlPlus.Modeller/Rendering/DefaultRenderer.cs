namespace GqlPlus.Rendering;

internal class DefaultRenderer<TModel>
  : IRenderer<TModel>
  where TModel : IRendering
{
  public RenderStructure Render(TModel model, IRenderContext context)
    => model.Render(context);
}

namespace GqlPlus.Rendering;

internal class BaseRenderer<TModel>
  : IRendering<TModel>
  where TModel : ModelBase
{
  RenderStructure IRendering<TModel>.Render(TModel model, IRenderContext context)
    => Render(model, context);

  internal virtual RenderStructure Render(TModel model, IRenderContext context)
    => RenderStructure.New(model.Tag);
}

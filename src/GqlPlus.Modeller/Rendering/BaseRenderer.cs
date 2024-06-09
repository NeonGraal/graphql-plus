namespace GqlPlus.Rendering;

internal class BaseRenderer<TModel>
  : IRenderer<TModel>
  where TModel : ModelBase
{
  RenderStructure IRenderer<TModel>.Render(TModel model, IRenderContext context)
    => Render(model, context);

  internal virtual RenderStructure Render(TModel model, IRenderContext context)
    => RenderStructure.New(model.Tag);
}

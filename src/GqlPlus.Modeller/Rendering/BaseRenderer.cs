namespace GqlPlus.Rendering;

internal class BaseRenderer<TModel>
  : IRenderer<TModel>
  where TModel : IModelBase
{
  RenderStructure IRenderer<TModel>.Render(TModel model)
    => Render(model);

  internal virtual RenderStructure Render(TModel model)
    => RenderStructure.New(model.Tag);
}

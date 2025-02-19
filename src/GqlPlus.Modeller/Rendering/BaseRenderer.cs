namespace GqlPlus.Rendering;

internal class BaseRenderer<TModel>
  : IRenderer<TModel>
  where TModel : IModelBase
{
  Structured IRenderer<TModel>.Render(TModel model)
    => Render(model);

  internal virtual Structured Render(TModel model)
    => Structured.New(model.Tag);
}

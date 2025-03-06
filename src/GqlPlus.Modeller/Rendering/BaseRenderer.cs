namespace GqlPlus.Rendering;

internal class BaseRenderer<TModel>
  : IRenderer<TModel>
  where TModel : IModelBase
{
  Structured IRenderer<TModel>.Render(TModel model)
    => Render(model);

  internal virtual Structured Render(TModel model)
    => new Map<Structured>().Render(model.Tag);
}

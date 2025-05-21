namespace GqlPlus.Rendering.Objects;

public abstract class ObjectBaseRendererBase<TModel, TBase>
  : RendererClassTestBase<TModel>
  where TModel : IModelBase
  where TBase : IModelBase
{
  protected IRenderer<TBase> Base { get; }

  protected ObjectBaseRendererBase()
    => Base = RFor<TBase>();
}

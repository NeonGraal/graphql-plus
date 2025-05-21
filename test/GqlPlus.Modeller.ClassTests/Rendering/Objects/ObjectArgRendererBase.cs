namespace GqlPlus.Rendering.Objects;

public abstract class ObjectArgRendererBase<TModel, TArg>
  : RendererClassTestBase<TModel>
  where TModel : IModelBase
  where TArg : IModelBase
{
  protected IRenderer<TArg> ObjArg { get; }

  protected ObjectArgRendererBase()
    => ObjArg = RFor<TArg>();
}

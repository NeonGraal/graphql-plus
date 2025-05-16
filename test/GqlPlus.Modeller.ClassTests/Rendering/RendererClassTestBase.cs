namespace GqlPlus.Rendering;

public abstract class RendererClassTestBase<TModel>
  : SubstituteBase
  where TModel : IModelBase
{
  protected abstract IRenderer<TModel> Renderer { get; }

  internal static IRenderer<TM> RFor<TM>()
    where TM : IModelBase
    => For<IRenderer<TM>>();
}

namespace GqlPlus.Rendering;

public abstract class RendererClassTestBase<TModel>
  : SubstituteBase
  where TModel : IModelBase
{
  protected abstract IRenderer<TModel> Renderer { get; }

  internal static IRenderer<TM> RFor<TM>()
    where TM : IModelBase
    => A.Of<IRenderer<TM>>();

  internal void RenderAndCheck(TModel model, string[] expected)
    => Renderer.Render(model)
      .ShouldNotBeNull()
      .ToLines(false).ToLines()
      .ShouldBe(expected);
}

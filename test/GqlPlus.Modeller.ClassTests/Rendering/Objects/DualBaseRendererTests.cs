namespace GqlPlus.Rendering.Objects;

public class DualBaseRendererTests
  : RendererClassTestBase<DualBaseModel>
{
  private readonly IRenderer<DualArgModel> _objArgRenderer;

  public DualBaseRendererTests()
  {
    _objArgRenderer = RFor<DualArgModel>();

    Renderer = new DualBaseRenderer(_objArgRenderer);
  }

  protected override IRenderer<DualBaseModel> Renderer { get; }

  [Theory, RepeatData]
  public void Render_WithTypeParam_ReturnsStructuredWithTypeParam(string dual, string contents)
    => RenderAndCheck(new(dual, contents) { IsTypeParam = true }, [
      "!_DualBase",
      "description: " + contents.Quoted("'"),
      "typeParam: " + dual
      ]);

  [Theory, RepeatData]
  public void Render_WithoutTypeParam_ReturnsStructuredWithDual(string dual, string contents)
    => RenderAndCheck(new(dual, contents), [
      "!_DualBase",
      "description: " + contents.Quoted("'"),
      "dual: " + dual
      ]);
}

namespace GqlPlus.Rendering.Objects;

public class DualArgRendererTests
  : RendererClassTestBase<DualArgModel>
{
  protected override IRenderer<DualArgModel> Renderer { get; }
    = new DualArgRenderer();

  [Theory, RepeatData]
  public void Render_WithTypeParam_ReturnsStructuredWithTypeParam(string dual, string contents)
    => RenderAndCheck(new(dual, contents) { IsTypeParam = true }, [
      "!_DualArg",
      "description: " + contents.Quoted("'"),
      "typeParam: " + dual
      ]);

  [Theory, RepeatData]
  public void Render_WithoutTypeParam_ReturnsStructuredWithDual(string dual, string contents)
    => RenderAndCheck(new(dual, contents), [
      "!_DualArg",
      "description: " + contents.Quoted("'"),
      "dual: " + dual
      ]);
}

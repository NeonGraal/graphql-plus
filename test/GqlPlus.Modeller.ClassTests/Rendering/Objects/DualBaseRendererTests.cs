namespace GqlPlus.Rendering.Objects;

public class DualBaseRendererTests
  : ObjectArgRendererBase<DualBaseModel, DualArgModel>
{
  public DualBaseRendererTests()
    => Renderer = new DualBaseRenderer(ObjArg);

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

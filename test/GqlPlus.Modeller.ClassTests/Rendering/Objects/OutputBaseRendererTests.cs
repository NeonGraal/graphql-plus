namespace GqlPlus.Rendering.Objects;

public class OutputBaseRendererTests
  : ObjectArgRendererBase<OutputBaseModel, OutputArgModel>
{
  private readonly IRenderer<DualBaseModel> _dual;

  public OutputBaseRendererTests()
  {
    _dual = RFor<DualBaseModel>();

    Renderer = new OutputBaseRenderer(ObjArg, _dual);
  }

  protected override IRenderer<OutputBaseModel> Renderer { get; }

  [Theory, RepeatData]
  public void Render_WithTypeParam_ReturnsStructuredWithTypeParam(string output, string contents)
    => RenderAndCheck(new(output, contents) { IsTypeParam = true }, [
      "!_OutputBase",
      "description: " + contents.Quoted("'"),
      "typeParam: " + output
      ]);

  [Theory, RepeatData]
  public void Render_WithoutTypeParam_ReturnsStructuredWithOutput(string output, string contents)
    => RenderAndCheck(new(output, contents), [
      "!_OutputBase",
      "description: " + contents.Quoted("'"),
      "output: " + output
      ]);
}

namespace GqlPlus.Rendering.Objects;

public class OutputArgRendererTests
  : RendererClassTestBase<OutputArgModel>
{
  private readonly IRenderer<DualArgModel> _dual;
  private readonly IRenderer<TypeRefModel<SimpleKindModel>> _label;

  public OutputArgRendererTests()
  {
    _dual = RFor<DualArgModel>();
    _label = RFor<TypeRefModel<SimpleKindModel>>();

    Renderer = new OutputArgRenderer(_dual, _label);
  }

  protected override IRenderer<OutputArgModel> Renderer { get; }

  [Theory, RepeatData]
  public void Render_WithTypeParam_ReturnsStructuredWithTypeParam(string output, string contents)
    => RenderAndCheck(new(output, contents) { IsTypeParam = true }, [
      "!_OutputArg",
      "description: " + contents.Quoted("'"),
      "typeParam: " + output
      ]);

  [Theory, RepeatData]
  public void Render_WithoutTypeParam_ReturnsStructuredWithOutput(string output, string contents)
    => RenderAndCheck(new(output, contents), [
      "!_OutputArg",
      "description: " + contents.Quoted("'"),
      "output: " + output
      ]);
}

namespace GqlPlus.Rendering.Objects;

public class InputArgRendererTests
  : RendererClassTestBase<InputArgModel>
{
  private readonly IRenderer<DualArgModel> _dual;

  public InputArgRendererTests()
  {
    _dual = RFor<DualArgModel>();

    Renderer = new InputArgRenderer(_dual);
  }

  protected override IRenderer<InputArgModel> Renderer { get; }

  [Theory, RepeatData]
  public void Render_WithTypeParam_ReturnsStructuredWithTypeParam(string input, string contents)
    => RenderAndCheck(new(input, contents) { IsTypeParam = true }, [
      "!_InputArg",
      "description: " + contents.Quoted("'"),
      "typeParam: " + input
      ]);

  [Theory, RepeatData]
  public void Render_WithoutTypeParam_ReturnsStructuredWithInput(string input, string contents)
    => RenderAndCheck(new(input, contents), [
      "!_InputArg",
      "description: " + contents.Quoted("'"),
      "input: " + input
      ]);
}

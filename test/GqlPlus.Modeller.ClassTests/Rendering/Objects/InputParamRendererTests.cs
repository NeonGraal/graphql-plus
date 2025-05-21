namespace GqlPlus.Rendering.Objects;

public class InputParamRendererTests
  : RendererClassTestBase<InputParamModel>
{
  private readonly IRenderer<InputArgModel> _objArg;
  private readonly IRenderer<DualBaseModel> _dual;
  private readonly IRenderer<ModifierModel> _modifier;
  private readonly IRenderer<ConstantModel> _constant;

  public InputParamRendererTests()
  {
    _objArg = RFor<InputArgModel>();
    _dual = RFor<DualBaseModel>();
    _modifier = RFor<ModifierModel>();
    _constant = RFor<ConstantModel>();

    Renderer = new InputParamRenderer(_objArg, _dual, _modifier, _constant);
  }

  protected override IRenderer<InputParamModel> Renderer { get; }

  [Theory, RepeatData]
  public void Render_WithValidModel_ReturnsStructured(string input, string contents)
    => RenderAndCheck(new(input, contents), [
      "!_InputParam",
      "description: " + contents.Quoted("'"),
      "input: " + input
      ]);
}

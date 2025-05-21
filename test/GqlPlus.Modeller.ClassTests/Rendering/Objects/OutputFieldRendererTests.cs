namespace GqlPlus.Rendering.Objects;

public class OutputFieldRendererTests
  : ObjectBaseRendererBase<OutputFieldModel, OutputBaseModel>
{
  private readonly IRenderer<ModifierModel> _modifer;
  private readonly IRenderer<OutputEnumModel> _outputEnum;
  private readonly IRenderer<InputParamModel> _parameter;

  public OutputFieldRendererTests()
  {
    _outputEnum = RFor<OutputEnumModel>();
    _modifer = RFor<ModifierModel>();
    _parameter = RFor<InputParamModel>();

    Renderer = new OutputFieldRenderer(_outputEnum, new(_modifer, Base), _parameter);
  }

  protected override IRenderer<OutputFieldModel> Renderer { get; }

  [Theory, RepeatData]
  public void Render_WithValidModel_ReturnsStructured(string name, string output, string contents)
  {
    // Arrange
    OutputBaseModel outputBase = new(output, "");
    Base.Render(outputBase).Returns(new Structured(output));

    // Act & Accept
    RenderAndCheck(new(name, outputBase, contents), [
      "!_OutputField",
      "description: " + contents.Quoted("'"),
      "name: " + name,
      "type: " + output
      ]);
  }
}

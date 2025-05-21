namespace GqlPlus.Rendering;

public class ConstantRendererTests
  : RendererClassTestBase<ConstantModel>
{
  private readonly IRenderer<SimpleModel> _simpleRenderer;

  public ConstantRendererTests()
  {
    _simpleRenderer = RFor<SimpleModel>();

    Renderer = new ConstantRenderer(_simpleRenderer);
  }

  protected override IRenderer<ConstantModel> Renderer { get; }

  [Theory, RepeatData]
  public void Render_WithMap_ReturnsStructuredMap(string key, string value)
  {
    // Arrange
    SimpleModel simpleKey = SimpleModel.Str("", key);
    SimpleModel simpleValue = SimpleModel.Str("", value);
    ConstantModel valueModel = new(simpleValue);

    Structured renderedKey = new(key);
    Structured renderedValue = new(value);
    _simpleRenderer.Render(simpleKey).Returns(renderedKey);
    _simpleRenderer.Render(simpleValue).Returns(renderedValue);

    // Act
    RenderAndCheck(new(new Dictionary<SimpleModel, ConstantModel> { { simpleKey, valueModel } }), [
        "!_ConstantMap", key + ": " + value]);
  }

  [Theory, RepeatData]
  public void Render_WithList_ReturnsStructuredList(string value)
  {
    // Arrange
    ConstantModel valueModel = new(SimpleModel.Str("", value));

    Structured renderedValue = new(value);
    Renderer.Render(valueModel).Returns(renderedValue);

    // Act
    RenderAndCheck(new([valueModel]), ["- " + value]);
  }

  [Theory, RepeatData]
  public void Render_WithValue_ReturnsSimpleRenderedValue(string value)
  {
    // Arrange
    SimpleModel valueModel = SimpleModel.Str("", value);
    Structured renderedValue = new(value);
    _simpleRenderer.Render(valueModel).Returns(renderedValue);

    RenderAndCheck(new(valueModel), [value]);
  }
}

using Shouldly;

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

  [Fact]
  public void Render_WithMap_ReturnsStructuredMap()
  {
    // Arrange
    SimpleModel simpleKey = SimpleModel.Str("", "Key");
    SimpleModel simpleValue = SimpleModel.Str("", "Value");
    ConstantModel value = new(simpleValue);
    ConstantModel model = new(new Dictionary<SimpleModel, ConstantModel> { { simpleKey, value } });

    Structured renderedKey = new("Key");
    Structured renderedValue = new("Value");
    _simpleRenderer.Render(simpleKey).Returns(renderedKey);
    _simpleRenderer.Render(simpleValue).Returns(renderedValue);

    // Act
    Structured result = Renderer.Render(model);

    // Assert
    result.ShouldNotBeNull()
      .ToLines(false).ToLines()
      .ShouldBe([
        "!_ConstantMap", "Key: Value"]);
  }

  [Fact]
  public void Render_WithList_ReturnsStructuredList()
  {
    // Arrange
    ConstantModel value = new(new SimpleModel());
    ConstantModel model = new([value]);

    Structured renderedValue = new("Value");
    Renderer.Render(value).Returns(renderedValue);

    // Act
    Structured result = Renderer.Render(model);

    // Assert
    result.ShouldNotBeNull()
      .ToLines(false).ToLines()
      .ShouldBe([
        "- Value"]);
  }

  [Fact]
  public void Render_WithValue_ReturnsSimpleRenderedValue()
  {
    // Arrange
    SimpleModel value = new();
    ConstantModel model = new(value);

    Structured renderedValue = new("Value");
    _simpleRenderer.Render(value).Returns(renderedValue);

    // Act
    Structured result = Renderer.Render(model);

    // Assert
    result.ShouldNotBeNull()
      .ToLines(false).ToLines()
      .ShouldBe([
        "Value"]);
  }
}

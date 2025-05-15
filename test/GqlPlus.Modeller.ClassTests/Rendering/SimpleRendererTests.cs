namespace GqlPlus.Rendering;

public class SimpleRendererTests
  : RendererClassTestBase<SimpleModel>
{
  protected override IRenderer<SimpleModel> Renderer { get; }
    = new SimpleRenderer();

  [Fact]
  public void Render_WithBoolean_ReturnsStructuredBoolean()
  {
    // Arrange
    SimpleModel model = SimpleModel.Bool(true);

    // Act
    Structured result = Renderer.Render(model);

    // Assert
    result.ShouldNotBeNull()
      .ToLines(false).ToLines()
      .ShouldBe([
        "true"
        ]);
  }

  [Fact]
  public void Render_WithNumber_ReturnsStructuredNumber()
  {
    // Arrange
    SimpleModel model = SimpleModel.Num("Type", 42);

    // Act
    Structured result = Renderer.Render(model);

    // Assert
    result.ShouldNotBeNull()
      .ToLines(false).ToLines()
      .ShouldBe([
        "!Type 42"
        ]);
  }

  [Fact]
  public void Render_WithString_ReturnsStructuredString()
  {
    // Arrange
    SimpleModel model = SimpleModel.Str("Type", "Text");

    // Act
    Structured result = Renderer.Render(model);

    // Assert
    result.ShouldNotBeNull()
      .ToLines(false).ToLines()
      .ShouldBe([
        "!Type 'Text'"
        ]);
  }
}

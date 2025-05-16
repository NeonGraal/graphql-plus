namespace GqlPlus.Rendering;

public class SimpleRendererTests
  : RendererClassTestBase<SimpleModel>
{
  protected override IRenderer<SimpleModel> Renderer { get; }
    = new SimpleRenderer();

  [Theory, RepeatData]
  public void Render_WithBoolean_ReturnsStructuredBoolean(bool value)
  {
    // Arrange
    SimpleModel model = SimpleModel.Bool(value);

    // Act
    Structured result = Renderer.Render(model);

    // Assert
    result.ShouldNotBeNull()
      .ToLines(false).ToLines()
      .ShouldBe([
        value.TrueFalse()
        ]);
  }

  [Theory, RepeatData]
  public void Render_WithNumber_ReturnsStructuredNumber(decimal value)
  {
    // Arrange
    SimpleModel model = SimpleModel.Num("Type", value);

    // Act
    Structured result = Renderer.Render(model);

    // Assert
    result.ShouldNotBeNull()
      .ToLines(false).ToLines()
      .ShouldBe([
        $"!Type {value:0.#####}"
        ]);
  }

  [Theory, RepeatData]
  public void Render_WithString_ReturnsStructuredString(string type, string value)
  {
    // Arrange
    SimpleModel model = SimpleModel.Str(type, value);

    // Act
    Structured result = Renderer.Render(model);

    // Assert
    result.ShouldNotBeNull()
      .ToLines(false).ToLines()
      .ShouldBe([
        $"!{type} '{value}'"
        ]);
  }
}

namespace GqlPlus.Rendering;

public class SimpleRendererTests
  : RendererClassTestBase<SimpleModel>
{
  protected override IRenderer<SimpleModel> Renderer { get; }
    = new SimpleRenderer();

  [Theory, RepeatData]
  public void Render_WithBoolean_ReturnsStructuredBoolean(bool value)
    => RenderAndCheck(SimpleModel.Bool(value), [
        value.TrueFalse()
        ]);

  [Theory, RepeatData]
  public void Render_WithNumber_ReturnsStructuredNumber(decimal value)
    => RenderAndCheck(SimpleModel.Num("Type", value), [
        $"!Type {value:0.#####}"
        ]);

  [Theory, RepeatData]
  public void Render_WithString_ReturnsStructuredString(string type, string value)
    => RenderAndCheck(SimpleModel.Str(type, value), [
        $"!{type} '{value}'"
        ]);
}

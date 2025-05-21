namespace GqlPlus.Rendering.Simple;

public class EnumLabelRendererTests : RendererClassTestBase<EnumLabelModel>
{
  protected override IRenderer<EnumLabelModel> Renderer { get; }
    = new EnumLabelRenderer();

  [Theory, RepeatData]
  public void Render_WithValidModel_ReturnsStructured(string name, string ofEnum, string contents)
    => RenderAndCheck(new(name, ofEnum, contents), [
      "!_EnumLabel",
      "description: " + contents.Quoted("'"),
      "enum: " + ofEnum,
      "name: " + name
      ]);
}

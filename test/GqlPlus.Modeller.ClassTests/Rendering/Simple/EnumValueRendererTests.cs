namespace GqlPlus.Rendering.Simple;

public class EnumValueRendererTests
  : RendererClassTestBase<EnumValueModel>
{
  protected override IRenderer<EnumValueModel> Renderer { get; }
    = new EnumValueRenderer();

  [Theory, RepeatData]
  public void Render_WithValidModel_ReturnsStructured(string enumType, string label, string contents)
    => RenderAndCheck(new(enumType, label, contents), [
      "!_EnumValue",
      "description: " + contents.Quoted("'"),
      "label: " + label,
      "name: " + enumType,
      "typeKind: !_SimpleKind Enum"
      ]);
}

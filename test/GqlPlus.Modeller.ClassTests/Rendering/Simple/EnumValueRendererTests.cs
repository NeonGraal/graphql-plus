namespace GqlPlus.Rendering.Simple;

public class EnumValueRendererTests
  : RendererClassTestBase<EnumValueModel>
{
  protected override IRenderer<EnumValueModel> Renderer { get; }
    = new EnumValueRenderer();

  [Theory, RepeatData]
  public void Render_WithValidModel_ReturnsStructured(EnumLabelInput input, string contents)
    => RenderAndCheck(new(input.EnumType, input.Label, contents), [
      "!_EnumValue",
      "description: " + contents.Quoted("'"),
      "label: " + input.Label,
      "typeKind: !_SimpleKind Enum",
      "typeName: " + input.EnumType
      ]);
}

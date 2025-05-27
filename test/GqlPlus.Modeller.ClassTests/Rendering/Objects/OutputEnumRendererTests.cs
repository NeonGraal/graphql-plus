namespace GqlPlus.Rendering.Objects;

public class OutputEnumRendererTests
  : RendererClassTestBase<OutputEnumModel>
{
  protected override IRenderer<OutputEnumModel> Renderer { get; }
    = new OutputEnumRenderer();

  [Theory, RepeatData]
  public void Render_WithValidModel_ReturnsStructured(string field, string enumType, string enumLabel, string contents)
    => RenderAndCheck(new(field, enumType, enumLabel, contents), [
      "!_OutputEnum",
      "description: " + contents.Quoted("'"),
      "field: " + field,
      "label: " + enumLabel,
      "typeKind: !_SimpleKind Enum",
      "typeName: " + enumType
    ]);
}

namespace GqlPlus.Rendering;

public class SpecialTypeRendererTests
  : RendererClassTestBase<SpecialTypeModel>
{
  protected override IRenderer<SpecialTypeModel> Renderer { get; }
    = new SpecialTypeRenderer();

  [Theory, RepeatData]
  public void Render_WithValidSpecialTypeModel_ReturnsStructured(string name, string content)
    => RenderAndCheck(new(name, content), [
        "!_SpecialType",
        $"description: '{content}'",
        "name: " + name,
        "typeKind: !_TypeKind Special"
        ]);
}

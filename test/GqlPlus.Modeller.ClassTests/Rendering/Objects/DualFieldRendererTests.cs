namespace GqlPlus.Rendering.Objects;

public class DualFieldRendererTests
  : RendererClassTestBase<DualFieldModel>
{
  private readonly IRenderer<ModifierModel> _modifer;
  private readonly IRenderer<DualBaseModel> _baseRenderers;

  public DualFieldRendererTests()
  {
    _modifer = RFor<ModifierModel>();
    _baseRenderers = RFor<DualBaseModel>();

    Renderer = new DualFieldRenderer(new(_modifer, _baseRenderers));
  }

  protected override IRenderer<DualFieldModel> Renderer { get; }

  [Theory, RepeatData]
  public void Render_WithValidModel_ReturnsStructured(string name, string dual, string contents)
  {
    // Arrange
    DualBaseModel dualBase = new(dual, "");
    _baseRenderers.Render(dualBase).Returns(new Structured(dual));

    // Act & Accept
    RenderAndCheck(new(name, dualBase, contents), [
      "!_DualField",
      "description: " + contents.Quoted("'"),
      "name: " + name,
      "type: " + dual
      ]);
  }
}

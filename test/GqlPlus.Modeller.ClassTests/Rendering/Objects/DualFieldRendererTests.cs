namespace GqlPlus.Rendering.Objects;

public class DualFieldRendererTests
  : ObjectBaseRendererBase<DualFieldModel, DualBaseModel>
{
  private readonly IRenderer<ModifierModel> _modifer;

  public DualFieldRendererTests()
  {
    _modifer = RFor<ModifierModel>();

    Renderer = new DualFieldRenderer(new(_modifer, Base));
  }

  protected override IRenderer<DualFieldModel> Renderer { get; }

  [Theory, RepeatData]
  public void Render_WithValidModel_ReturnsStructured(string name, string dual, string contents)
  {
    // Arrange
    DualBaseModel dualBase = new(dual, "");
    Base.Render(dualBase).Returns(new Structured(dual));

    // Act & Accept
    RenderAndCheck(new(name, dualBase, contents), [
      "!_DualField",
      "description: " + contents.Quoted("'"),
      "name: " + name,
      "type: " + dual
      ]);
  }
}

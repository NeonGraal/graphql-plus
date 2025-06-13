namespace GqlPlus.Rendering.Simple;

public class DomainLabelRendererTests
  : RendererClassTestBase<DomainLabelModel>
{
  private readonly IRenderer<EnumValueModel> _enumValueRenderer;

  public DomainLabelRendererTests()
  {
    _enumValueRenderer = RFor<EnumValueModel>();
    Renderer = new DomainLabelRenderer(_enumValueRenderer);
  }

  protected override IRenderer<DomainLabelModel> Renderer { get; }

  [Theory, RepeatData]
  public void Render_WithValidModel_ReturnsStructured(string name, string label, bool exclude)
  {
    // Arrange
    EnumValueModel enumValue = new(name, label, "");
    DomainLabelModel model = new(enumValue, exclude);
    Map<string> map = new() { ["name"] = name, ["label"] = label };
    _enumValueRenderer.Render(enumValue).Returns(map.Render(s => new Structured(s)));

    // Act
    RenderAndCheck(model, [
      "!_DomainLabel",
      "exclude: " + exclude.TrueFalse(),
      "value:",
      "  label: " + label,
      "  name: " + name,
      ]);
  }
}

public class DomainEnumRendererTests
  : BaseDomainRendererTests<DomainLabelModel, string>
{
  protected override DomainKindModel DomainKind => DomainKindModel.Enum;

  protected override DomainLabelModel NewItem(string item) => new(item, "", false);
}

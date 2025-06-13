namespace GqlPlus.Rendering.Simple;

public class DomainTrueFalseRendererTests
  : RendererClassTestBase<DomainTrueFalseModel>
{
  protected override IRenderer<DomainTrueFalseModel> Renderer { get; }
    = new DomainTrueFalseRenderer();

  [Theory, RepeatData]
  public void Render_WithValidModel_ReturnsStructured(bool value, bool exclude)
    => RenderAndCheck(new(value, exclude), [
      "!_DomainTrueFalse",
      "exclude: " + exclude.TrueFalse(),
      "value: " + value.TrueFalse()
      ]);
}

public class DomainBooleanRendererTests
  : BaseDomainRendererTests<DomainTrueFalseModel, bool>
{
  protected override DomainKindModel DomainKind => DomainKindModel.Boolean;

  protected override DomainTrueFalseModel NewItem(bool item) => new(item, false);
}

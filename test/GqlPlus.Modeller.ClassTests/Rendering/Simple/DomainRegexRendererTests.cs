namespace GqlPlus.Rendering.Simple;

public class DomainRegexRendererTests
  : RendererClassTestBase<DomainRegexModel>
{
  protected override IRenderer<DomainRegexModel> Renderer { get; }
    = new DomainRegexRenderer();

  [Theory, RepeatData]
  public void Render_WithValidModel_ReturnsStructured(string pattern, bool exclude)
    => RenderAndCheck(new(pattern, exclude), [
      "!_DomainRegex",
      "exclude: " + exclude.TrueFalse(),
      "pattern: " + pattern
      ]);
}

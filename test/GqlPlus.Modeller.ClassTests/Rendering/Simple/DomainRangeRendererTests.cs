namespace GqlPlus.Rendering.Simple;

public class DomainRangeRendererTests
  : RendererClassTestBase<DomainRangeModel>
{
  protected override IRenderer<DomainRangeModel> Renderer { get; }
    = new DomainRangeRenderer();

  [Theory, RepeatData]
  public void Render_WithValidModel_ReturnsStructured(decimal? from, decimal? to, bool exclude)
    => RenderAndCheck(new(from, to, exclude), [
      "!_DomainRange",
      "exclude: " + exclude.TrueFalse(),
      $"from: {from:0.#####}",
      $"to: {to:0.#####}"
      ]);
}

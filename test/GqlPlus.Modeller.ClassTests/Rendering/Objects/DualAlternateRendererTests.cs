namespace GqlPlus.Rendering.Objects;

public class DualAlternateRendererTests
  : RendererClassTestBase<DualAlternateModel>
{
  private readonly IRenderer<CollectionModel> _collection;
  private readonly IRenderer<DualArgModel> _objArg;

  public DualAlternateRendererTests()
  {
    _objArg = RFor<DualArgModel>();
    _collection = RFor<CollectionModel>();

    Renderer = new DualAlternateRenderer(new(_objArg, _collection));
  }

  protected override IRenderer<DualAlternateModel> Renderer { get; }

  [Theory, RepeatData]
  public void Render_WithTypeParam_ReturnsStructuredWithTypeParam(string dual, string contents)
    => RenderAndCheck(new(dual, contents) { IsTypeParam = true }, [
      "!_DualAlternate",
      "description: " + contents.Quoted("'"),
      "typeParam: " + dual
      ]);

  [Theory, RepeatData]
  public void Render_WithoutTypeParam_ReturnsStructuredWithDual(string dual, string contents)
    => RenderAndCheck(new(dual, contents), [
      "!_DualAlternate",
      "description: " + contents.Quoted("'"),
      "dual: " + dual
      ]);
}

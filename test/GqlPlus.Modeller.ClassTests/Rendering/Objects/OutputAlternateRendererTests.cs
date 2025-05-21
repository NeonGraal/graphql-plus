namespace GqlPlus.Rendering.Objects;

public class OutputAlternateRendererTests
  : ObjectArgRendererBase<OutputAlternateModel, OutputArgModel>
{
  private readonly IRenderer<CollectionModel> _collection;
  private readonly IRenderer<DualAlternateModel> _dual;

  public OutputAlternateRendererTests()
  {
    _collection = RFor<CollectionModel>();
    _dual = RFor<DualAlternateModel>();

    Renderer = new OutputAlternateRenderer(new(ObjArg, _collection), _dual);
  }

  protected override IRenderer<OutputAlternateModel> Renderer { get; }

  [Theory, RepeatData]
  public void Render_WithTypeParam_ReturnsStructuredWithTypeParam(string output, string contents)
    => RenderAndCheck(new(output, contents) { IsTypeParam = true }, [
      "!_OutputAlternate",
      "description: " + contents.Quoted("'"),
      "typeParam: " + output
      ]);

  [Theory, RepeatData]
  public void Render_WithoutTypeParam_ReturnsStructuredWithOutput(string output, string contents)
    => RenderAndCheck(new(output, contents), [
      "!_OutputAlternate",
      "description: " + contents.Quoted("'"),
      "output: " + output
      ]);
}

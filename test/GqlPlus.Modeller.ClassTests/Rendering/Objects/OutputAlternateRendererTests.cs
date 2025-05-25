namespace GqlPlus.Rendering.Objects;

public class OutputAlternateRendererTests
  : ObjectBaseRendererBase<OutputAlternateModel, OutputBaseModel>
{
  private readonly IRenderer<CollectionModel> _collection;

  public OutputAlternateRendererTests()
  {
    _collection = RFor<CollectionModel>();

    Renderer = new ObjectAlternateRenderer<OutputAlternateModel, OutputBaseModel>(new(_collection, ObjBase));
  }

  protected override IRenderer<OutputAlternateModel> Renderer { get; }

  [Theory, RepeatData]
  public void Render_ReturnsStructuredWithOutput(string output)
  {
    OutputBaseModel objBase = new(output, "");
    ObjBase.Render(objBase).Returns(new Structured(output));
    RenderAndCheck(new(objBase), [
        "!_OutputAlternate",
        "type: " + output
      ]);
  }
}

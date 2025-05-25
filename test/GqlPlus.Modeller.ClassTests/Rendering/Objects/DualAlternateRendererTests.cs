namespace GqlPlus.Rendering.Objects;

public class DualAlternateRendererTests
  : ObjectBaseRendererBase<DualAlternateModel, DualBaseModel>
{
  private readonly IRenderer<CollectionModel> _collection;

  public DualAlternateRendererTests()
  {
    _collection = RFor<CollectionModel>();

    Renderer = new ObjectAlternateRenderer<DualAlternateModel, DualBaseModel>(new(_collection, ObjBase));
  }

  protected override IRenderer<DualAlternateModel> Renderer { get; }

  [Theory, RepeatData]
  public void Render_WithoutTypeParam_ReturnsStructuredWithDual(string dual)
  {
    DualBaseModel objBase = new(dual, "");
    ObjBase.Render(objBase).Returns(new Structured(dual));
    RenderAndCheck(new(objBase), [
        "!_DualAlternate",
        "type: " + dual
      ]);
  }
}

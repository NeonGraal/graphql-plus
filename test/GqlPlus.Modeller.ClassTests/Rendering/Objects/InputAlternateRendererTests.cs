namespace GqlPlus.Rendering.Objects;

public class InputAlternateRendererTests
  : ObjectBaseRendererBase<InputAlternateModel, InputBaseModel>
{
  private readonly IRenderer<CollectionModel> _collection;

  public InputAlternateRendererTests()
  {
    _collection = RFor<CollectionModel>();

    Renderer = new ObjectAlternateRenderer<InputAlternateModel, InputBaseModel>(new(_collection, ObjBase));
  }

  protected override IRenderer<InputAlternateModel> Renderer { get; }

  [Theory, RepeatData]
  public void Render_ReturnsStructuredWithOutput(string input)
  {
    InputBaseModel objBase = new(input, "");
    ObjBase.Render(objBase).Returns(new Structured(input));
    RenderAndCheck(new(objBase), [
        "!_InputAlternate",
        "type: " + input
      ]);
  }
}

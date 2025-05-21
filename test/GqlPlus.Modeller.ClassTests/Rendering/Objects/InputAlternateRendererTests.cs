namespace GqlPlus.Rendering.Objects;

public class InputAlternateRendererTests
  : ObjectArgRendererBase<InputAlternateModel, InputArgModel>
{
  private readonly IRenderer<CollectionModel> _collection;
  private readonly IRenderer<DualAlternateModel> _dual;

  public InputAlternateRendererTests()
  {
    _collection = RFor<CollectionModel>();
    _dual = RFor<DualAlternateModel>();

    Renderer = new InputAlternateRenderer(new(ObjArg, _collection), _dual);
  }

  protected override IRenderer<InputAlternateModel> Renderer { get; }

  [Theory, RepeatData]
  public void Render_WithTypeParam_ReturnsStructuredWithTypeParam(string input, string contents)
    => RenderAndCheck(new(input, contents) { IsTypeParam = true }, [
      "!_InputAlternate",
      "description: " + contents.Quoted("'"),
      "typeParam: " + input
      ]);

  [Theory, RepeatData]
  public void Render_WithoutTypeParam_ReturnsStructuredWithInput(string input, string contents)
    => RenderAndCheck(new(input, contents), [
      "!_InputAlternate",
      "description: " + contents.Quoted("'"),
      "input: " + input
      ]);
}

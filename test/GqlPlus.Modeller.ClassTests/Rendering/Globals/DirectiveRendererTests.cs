using GqlPlus;

namespace GqlPlus.Rendering.Globals;

public class DirectiveRendererTests
  : RendererClassTestBase<DirectiveModel>
{
  public DirectiveRendererTests()
  {
    _parameter = RFor<InputParamModel>();
    Renderer = new DirectiveRenderer(_parameter);
  }

  private readonly IRenderer<InputParamModel> _parameter;

  protected override IRenderer<DirectiveModel> Renderer { get; }

  [Theory, RepeatData]
  public void Render_WithValidDirectiveModel_ReturnsStructured(string name, string contents, string input)
  {
    // Arrange
    InputParamModel parameter = new(input, "");
    _parameter.Render(parameter).Returns(new Structured(input));

    // Act
    RenderAndCheck(new(name, contents) {
      Locations = DirectiveLocation.Operation,
      Parameters = [parameter],
      Repeatable = true,
    }, [
        "!_Directive",
        $"description: " + contents.Quoted("'"),
        "locations: !_Set(_Location){Operation:_}",
        "name: " + name,
        "parameters:",
        "  - " + input,
        "repeatable: true"
        ]);
  }
}

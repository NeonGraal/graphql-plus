using GqlPlus;

namespace GqlPlus.Rendering.Globals;

public class DirectivesRendererTests
  : RendererClassTestBase<DirectivesModel>
{
  public DirectivesRendererTests()
  {
    _directive = RFor<DirectiveModel>();
    _baseType = RFor<BaseTypeModel>();
    Renderer = new DirectivesRenderer(new(_directive, _baseType));
  }

  private readonly IRenderer<DirectiveModel> _directive;
  private readonly IRenderer<BaseTypeModel> _baseType;

  protected override IRenderer<DirectivesModel> Renderer { get; }

  [Theory, RepeatData]
  public void Render_WithValidDirectivesModel_ReturnsStructured(string name)
  {
    // Arrange
    BaseTypeModel type = new TypeInputModel(name, "");
    DirectiveModel directive = new(name, "");
    DirectivesModel model = new() {
      Type = type,
      And = directive
    };
    _baseType.Render(type).Returns(new Structured(name, "Input"));
    _directive.Render(directive).Returns(new Structured(name, "Directive"));

    // Act
    Structured result = Renderer.Render(model);

    // Assert
    result.ShouldNotBeNull()
      .ToLines(false).ToLines()
      .ShouldBe([
        "!_Directives",
        "directive: !Directive " + name,
        "type: !Input " + name
        ]);
  }
}

namespace GqlPlus.Rendering;

public class SpecialTypeRendererTests
  : RendererClassTestBase<SpecialTypeModel>
{
  protected override IRenderer<SpecialTypeModel> Renderer { get; }
    = new SpecialTypeRenderer();

  [Theory, RepeatData]
  public void Render_WithValidSpecialTypeModel_ReturnsStructured(string name, string content)
  {
    // Arrange
    SpecialTypeModel model = new(name, content);

    // Act
    Structured result = Renderer.Render(model);

    // Assert
    result.ShouldNotBeNull()
      .ToLines(false).ToLines()
      .ShouldBe([
        "!_SpecialType",
        $"description: '{content}'",
        "name: " + name,
        "typeKind: !_TypeKind Special"
        ]);
  }
}

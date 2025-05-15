using Shouldly;

namespace GqlPlus.Rendering;

public class ModifierRendererTests
  : RendererClassTestBase<ModifierModel>
{
  protected override IRenderer<ModifierModel> Renderer { get; }
  = new ModifierRenderer();

  [Fact]
  public void Render_WithValidModifier_ReturnsStructuredModifier()
  {
    // Arrange
    ModifierModel model = new(ModifierKind.Optional);
    StructureValue key = new("modifierKind");

    // Act
    Structured result = Renderer.Render(model);

    // Assert
    result.ShouldNotBeNull()
      .ToLines(false).ToLines()
      .ShouldBe([
        "!_Modifier",
        "modifierKind: !_ModifierKind Opt"
        ]);
  }
}

namespace GqlPlus.Rendering;

public class CollectionRendererTests
  : RendererClassTestBase<CollectionModel>
{
  protected override IRenderer<CollectionModel> Renderer { get; }
    = new CollectionRenderer();

  [Fact]
  public void Render_WithModifierKindDict_ReturnsStructuredWithKey()
  {
    // Arrange
    CollectionModel model = new(ModifierKind.Dict) {
      Key = "Key",
      IsOptional = true
    };

    // Act
    Structured result = Renderer.Render(model);

    // Assert
    result.ShouldNotBeNull()
      .ToLines(false).ToLines()
      .ShouldBe([
        "!_ModifierDictionary",
        "by: Key",
        "modifierKind: !_ModifierKind Dict",
        "optional: true"
        ]);
  }
}

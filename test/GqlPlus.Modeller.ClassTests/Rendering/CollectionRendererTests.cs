namespace GqlPlus.Rendering;

public class CollectionRendererTests
  : RendererClassTestBase<CollectionModel>
{
  protected override IRenderer<CollectionModel> Renderer { get; }
    = new CollectionRenderer();

  [Theory, RepeatData]
  public void Render_WithModifierKindDict_ReturnsStructuredWithKey(string key)
  {
    // Arrange
    CollectionModel model = new(ModifierKind.Dict) {
      Key = key,
      IsOptional = true
    };

    // Act
    Structured result = Renderer.Render(model);

    // Assert
    result.ShouldNotBeNull()
      .ToLines(false).ToLines()
      .ShouldBe([
        "!_ModifierDictionary",
        "by: " + key,
        "modifierKind: !_ModifierKind Dict",
        "optional: true"
        ]);
  }
}

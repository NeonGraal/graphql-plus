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
    RenderAndCheck(new(ModifierKind.Dict) {
      Key = key,
      IsOptional = true
    }, [
        "!_ModifierDictionary",
        "by: " + key,
        "modifierKind: !_ModifierKind Dict",
        "optional: true"
        ]);
  }
}

namespace GqlPlus.Rendering;

public class ModifierRendererTests
  : RendererClassTestBase<ModifierModel>
{
  protected override IRenderer<ModifierModel> Renderer { get; }
  = new ModifierRenderer();

  [Theory, RepeatData]
  public void Render_WithValidModifier_ReturnsStructuredModifier(ModifierKind modifier, string key)
  {
    // Arrange
    string[] keyExpected = [];
    string tag = "!_Modifier";
    if (modifier is ModifierKind.Dict or ModifierKind.Param) {
      keyExpected = [$"by: {key}"];
      tag += modifier is ModifierKind.Param ? "TypeParam" : "Dictionary";
    }

    // Act
    RenderAndCheck(new(modifier) {
      Key = key,
    }, [
        tag,
        ..keyExpected,
        $"modifierKind: !_ModifierKind {modifier}"
        ]);
  }
}

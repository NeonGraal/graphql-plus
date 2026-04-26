namespace GqlPlus.Encoding;

public class ModifierEncoderTests
  : EncoderClassTestBase<ModifierModel>
{
  protected override IEncoder<ModifierModel> Encoder { get; }
  = new ModifierEncoder();

  [Theory, RepeatData]
  public void Encode_WithValidModifier_ReturnsStructuredModifier(ModifierKindModel modifier, string key)
  {
    // Arrange
    string[] keyExpected = [];
    string tag = "_Modifier";
    if (modifier is ModifierKindModel.Dict or ModifierKindModel.Param) {
      tag += modifier is ModifierKindModel.Param ? "TypeParam" : "Dictionary";
      keyExpected = [$"[{tag}]:by={key}"];
    }

    // Act
    EncodeAndCheck(new(modifier) {
      Key = key,
    }, [
        ..keyExpected,
        $"[{tag}]:modifierKind=[_ModifierKind]{modifier}"
        ]);
  }
}

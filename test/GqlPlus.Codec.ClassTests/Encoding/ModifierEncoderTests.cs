namespace GqlPlus.Encoding;

public class ModifierEncoderTests
  : EncoderClassTestBase<ModifierModel>
{
  protected override IEncoder<ModifierModel> Encoder { get; }
  = new ModifierEncoder();

  [Theory, RepeatData]
  public void Encode_WithValidModifier_ReturnsStructuredModifier(ModifierKind modifier, string key)
  {
    // Arrange
    string[] keyExpected = [];
    string tag = "!_Modifier";
    if (modifier is ModifierKind.Dict or ModifierKind.Param) {
      keyExpected = [$"by: {key}"];
      tag += modifier is ModifierKind.Param ? "TypeParam" : "Dictionary";
    }

    // Act
    EncodeAndCheck(new(modifier) {
      Key = key,
    }, [
        tag,
        ..keyExpected,
        $"modifierKind: !_ModifierKind {modifier}"
        ]);
  }
}

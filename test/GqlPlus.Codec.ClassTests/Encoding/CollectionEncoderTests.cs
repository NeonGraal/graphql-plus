namespace GqlPlus.Encoding;

public class CollectionEncoderTests
  : EncoderClassTestBase<CollectionModel>
{
  protected override IEncoder<CollectionModel> Encoder { get; }
    = new CollectionEncoder();

  [Theory, RepeatData]
  public void Encode_WithModifierKindDict_ReturnsStructuredWithKey(string key)
  {
    // Arrange
    EncodeAndCheck(new(ModifierKind.Dict) {
      Key = key,
      IsOptional = true
    }, TagAll("_ModifierDictionary",
        ":by=" + key,
        ":modifierKind=[_ModifierKind]Dict",
        ":optional=true"));
  }
}

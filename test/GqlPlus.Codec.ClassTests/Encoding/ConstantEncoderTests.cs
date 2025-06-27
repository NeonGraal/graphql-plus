namespace GqlPlus.Encoding;

public class ConstantEncoderTests
  : EncoderClassTestBase<ConstantModel>
{
  private readonly IEncoder<SimpleModel> _simpleEncoder;

  public ConstantEncoderTests()
  {
    _simpleEncoder = RFor<SimpleModel>();

    Encoder = new ConstantEncoder(_simpleEncoder);
  }

  protected override IEncoder<ConstantModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithMap_ReturnsStructuredMap(string key, string value)
  {
    // Arrange
    SimpleModel simpleKey = SimpleModel.Str("", key);
    SimpleModel simpleValue = SimpleModel.Str("", value);
    ConstantModel valueModel = new(simpleValue);

    Structured encodedKey = new(key);
    Structured encodedValue = new(value);
    _simpleEncoder.Encode(simpleKey).Returns(encodedKey);
    _simpleEncoder.Encode(simpleValue).Returns(encodedValue);

    // Act
    EncodeAndCheck(new(new Dictionary<SimpleModel, ConstantModel> { { simpleKey, valueModel } }), [
        "!_ConstantMap", key + ": " + value]);
  }

  [Theory, RepeatData]
  public void Encode_WithList_ReturnsStructuredList(string value)
  {
    // Arrange
    ConstantModel valueModel = new(SimpleModel.Str("", value));

    Structured encodedValue = new(value);
    Encoder.Encode(valueModel).Returns(encodedValue);

    // Act
    EncodeAndCheck(new([valueModel]), ["- " + value]);
  }

  [Theory, RepeatData]
  public void Encode_WithValue_ReturnsSimpleEncodedValue(string value)
  {
    // Arrange
    SimpleModel valueModel = SimpleModel.Str("", value);
    Structured encodedValue = new(value);
    _simpleEncoder.Encode(valueModel).Returns(encodedValue);

    EncodeAndCheck(new(valueModel), [value]);
  }
}

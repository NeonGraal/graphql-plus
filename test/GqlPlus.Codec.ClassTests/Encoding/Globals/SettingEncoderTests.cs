namespace GqlPlus.Encoding.Globals;

public class SettingEncoderTests
  : EncoderClassTestBase<SettingModel>
{
  public SettingEncoderTests()
  {
    _constant = RFor<ConstantModel>();
    Encoder = new SettingEncoder(_constant);
  }

  private readonly IEncoder<ConstantModel> _constant;

  protected override IEncoder<SettingModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithValidSettingModel_ReturnsStructured(string name, string value)
  {
    // Arrange
    SimpleModel simple = SimpleModel.Str(value);
    ConstantModel constant = new(simple);
    _constant.Encode(constant).Returns(new Structured(value));

    // Act
    EncodeAndCheck(new(name, constant, ""),
      TagAll("_Setting",
        ":name=" + name,
        ":value=" + value));
  }
}

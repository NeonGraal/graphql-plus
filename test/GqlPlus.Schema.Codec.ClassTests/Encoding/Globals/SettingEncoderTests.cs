namespace GqlPlus.Encoding.Globals;

public class SettingEncoderTests
  : EncoderClassTestBase<SettingModel>
{
  public SettingEncoderTests()
  {
    _constant = RFor<ConstantModel>();
    IEncoderRepository encoders = A.Of<IEncoderRepository>();
    encoders.EncoderForReturns(_constant);
    Encoder = new SettingEncoder(encoders);
  }

  private readonly IEncoder<ConstantModel> _constant;

  protected override IEncoder<SettingModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithValidSettingModel_ReturnsStructured(string name, string value)
  {
    // Arrange
    SimpleModel simple = SimpleModel.Str(value);
    ConstantModel constant = new(simple);
    _constant.Encode(constant).Returns(value.Encode());

    // Act
    EncodeAndCheck(new(name, constant, ""),
      TagAll("_Setting",
        ":name=" + name,
        ":value=" + value));
  }
}

namespace GqlPlus.Encoding.Objects;

public class TypeArgEncoderTests
  : EncoderClassTestBase<ITypeArgModel>
{
  private readonly IEncoder<EnumValueModel> _enumValue;

  public TypeArgEncoderTests()
  {
    _enumValue = RFor<EnumValueModel>();
    IEncoderRepository encoders = A.Of<IEncoderRepository>();
    encoders.EncoderForReturns(_enumValue);
    Encoder = new TypeArgEncoder(encoders);
  }

  protected override IEncoder<ITypeArgModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithTypeParam_ReturnsStructuredWithTypeParam(string output, string contents)
    => EncodeAndCheck(new TypeArgModel(TypeKindModel.Output, output, contents) { IsTypeParam = true },
      TagAll("_TypeArg",
      ":description=" + contents.QuotedIdentifier(),
      ":typeParam=" + output));

  [Theory, RepeatData]
  public void Encode_WithoutTypeParam_ReturnsStructuredWithOutput(string output, string contents)
    => EncodeAndCheck(new TypeArgModel(TypeKindModel.Output, output, contents),
      TagAll("_TypeArg",
      ":description=" + contents.QuotedIdentifier(),
      ":name=" + output));

  [Theory, RepeatData]
  public void Encode_WithEnumValue_ReturnsStructuredWithEnumValue(string output, string enumType, string label, string contents)
  {
    EnumValueModel enumValue = new(enumType, label, "");
    _enumValue.Encode(enumValue).Returns(enumType.Encode());
    EncodeAndCheck(new TypeArgModel(TypeKindModel.Output, output, contents) { EnumValue = enumValue },
      TagAll("_TypeArg",
      ":description=" + contents.QuotedIdentifier(),
      ":enumValue=" + enumType));
  }
}

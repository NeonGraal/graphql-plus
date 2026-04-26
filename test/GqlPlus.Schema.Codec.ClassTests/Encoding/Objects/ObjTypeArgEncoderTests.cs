namespace GqlPlus.Encoding.Objects;

public class TypeArgEncoderTests
  : EncoderClassTestBase<ITypeArgModel>
{
  private readonly IEncoder<EnumValueModel> _enumValue;

  public TypeArgEncoderTests()
  {
    _enumValue = RFor<EnumValueModel>();
    IEncoderRepository encoders = A.Of<IEncoderRepository>();
    encoders.EncoderFor<EnumValueModel>().Returns(_enumValue);
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
}

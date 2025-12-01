namespace GqlPlus.Encoding.Objects;

public class TypeArgEncoderTests
  : EncoderClassTestBase<TypeArgModel>
{
  private readonly IEncoder<EnumValueModel> _enumValue;

  public TypeArgEncoderTests()
  {
    _enumValue = RFor<EnumValueModel>();

    Encoder = new TypeArgEncoder(_enumValue);
  }

  protected override IEncoder<TypeArgModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithTypeParam_ReturnsStructuredWithTypeParam(string output, string contents)
    => EncodeAndCheck(new(TypeKindModel.Output, output, contents) { IsTypeParam = true }, [
      "!_TypeArg",
      "description: " + contents.QuotedIdentifier(),
      "typeParam: " + output
      ]);

  [Theory, RepeatData]
  public void Encode_WithoutTypeParam_ReturnsStructuredWithOutput(string output, string contents)
    => EncodeAndCheck(new(TypeKindModel.Output, output, contents), [
      "!_TypeArg",
      "description: " + contents.QuotedIdentifier(),
      "name: " + output
      ]);
}

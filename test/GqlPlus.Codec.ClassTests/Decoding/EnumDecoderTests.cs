
namespace GqlPlus.Decoding;

public class EnumDecoderTests
  : DecoderClassTestBase<TypeKindModel?>
{
  [Theory, InlineData(0, TypeKindModel.Basic), InlineData(10, TypeKindModel.Dual), InlineData(20, null)]
  public void Decode_Specific_Number(decimal value, TypeKindModel? expected)
  {
    IMessages messages = Decoder.Decode(new Structured(value), out TypeKindModel? result);

    result.ShouldSatisfyAllConditions(
      () => result.ShouldBeEquivalentTo(expected),
      MessagesContain(messages, expected is null ? "Unable" : "Mapped"));
  }

  [Theory, InlineData("Enum", TypeKindModel.Enum), InlineData("Input", TypeKindModel.Input), InlineData("", null)]
  public void Decode_Specific_Text(string value, TypeKindModel? expected)
  {
    IMessages messages = Decoder.Decode(new Structured(value), out TypeKindModel? result);

    result.ShouldSatisfyAllConditions(
      () => result.ShouldBeEquivalentTo(expected),
      MessagesEmpty(messages, expected));
  }

  [Theory, InlineData("", TypeKindModel.Enum), InlineData("_TypeKind", TypeKindModel.Enum), InlineData("_BadTag", null)]
  public void Decode_Specific_Tag(string value, TypeKindModel? expected)
  {
    IMessages messages = Decoder.Decode(new Structured("Enum", value), out TypeKindModel? result);

    result.ShouldSatisfyAllConditions(
      () => result.ShouldBeEquivalentTo(expected),
      MessagesEmpty(messages, expected));
  }

  protected override IDecoder<TypeKindModel?> Decoder { get; }
    = new EnumDecoder<TypeKindModel>();
}

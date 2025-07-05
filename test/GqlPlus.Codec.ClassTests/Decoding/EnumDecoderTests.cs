
namespace GqlPlus.Decoding;

public class EnumDecoderTests
  : DecoderClassTestBase<TypeKindModel>
{
  [Theory, InlineData(0, TypeKindModel.Basic), InlineData(10, TypeKindModel.Dual), InlineData(20, null)]
  public void Decode_Specific_Number(decimal value, TypeKindModel? expected)
  {
    TypeKindModel? result = Decoder.Decode(new Structured(value));

    result.ShouldBeEquivalentTo(expected);
  }

  [Theory, InlineData("Enum", TypeKindModel.Enum), InlineData("Input", TypeKindModel.Input), InlineData("", null)]
  public void Decode_Specific_Text(string value, TypeKindModel? expected)
  {
    TypeKindModel? result = Decoder.Decode(new Structured(value));

    result.ShouldBeEquivalentTo(expected);
  }

  [Theory, InlineData("", TypeKindModel.Enum), InlineData("_TypeKindModel", TypeKindModel.Enum), InlineData("_BadTag", null)]
  public void Decode_Specific_Tag(string value, TypeKindModel? expected)
  {
    TypeKindModel? result = Decoder.Decode(new Structured("Enum", value));

    result.ShouldBeEquivalentTo(expected);
  }

  protected override IDecoder<TypeKindModel> Decoder { get; }
    = new EnumDecoder<TypeKindModel>();
}

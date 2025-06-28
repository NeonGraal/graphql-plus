
namespace GqlPlus.Decoding;

public class ConstantDecoderTests
  : ScalarDecoderClassTestBase<ConstantModel>
{
  protected override IDecoder<ConstantModel> Decoder { get; }
    = new ConstantDecoder();

  protected override ConstantModel? ExpectedBool(bool value)
    => new(SimpleModel.Bool("", value));
  protected override ConstantModel? ExpectedNumber(decimal value)
    => new(SimpleModel.Num("", value));
  protected override ConstantModel? ExpectedText(string value)
    => new(SimpleModel.Str("", value));
  protected override ConstantModel? ExpectedList(string value)
    => new([ExpectedText(value)!]);
  protected override ConstantModel? ExpectedDict(string key, string value)
  {
    Dictionary<SimpleModel, ConstantModel> dict = new() { [SimpleModel.Str("", key)] = ExpectedText(value)! };
    return new(dict);
  }
}

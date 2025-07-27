
namespace GqlPlus.Decoding;

public class SimpleDecoderTests
  : ScalarDecoderClassTestBase<SimpleModel>
{
  protected override IDecoder<SimpleModel> Decoder { get; }
    = new SimpleDecoder();

  protected override SimpleModel? ExpectedBool(bool value)
    => SimpleModel.Bool(value);
  protected override SimpleModel? ExpectedNumber(decimal value)
    => SimpleModel.Num(value);
  protected override SimpleModel? ExpectedText(string value)
    => value.IsWhiteSpace() ? null : SimpleModel.Str(value);
  protected override SimpleModel? ExpectedList(string value)
    => SimpleModel.Str(value);
  protected override SimpleModel? ExpectedDict(string key, string value)
    => null;
}

namespace GqlPlus.Decoding.Simple;

public class NameFilterModelDecoderTests
  : SimpleDecoderClassTestBase<string>
{
  public NameFilterModelDecoderTests()
    => BoolMapped = "not a valid NameFilter value";

  protected override IDecoder<string> Decoder { get; }
    = new NameFilterModelDecoder();

  protected override string? ExpectedBool(bool value) => null;
  protected override string? ExpectedNumber(decimal value) => null;
  protected override string? ExpectedText(string value) => NameFilterModelDecoder.Valid.IsMatch(value) ? value : null;
  protected override string? ExpectedList(string value) => NameFilterModelDecoder.Valid.IsMatch(value) ? value : null;
  protected override string? ExpectedDict(string key, string value) => null;
}

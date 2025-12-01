namespace GqlPlus.Encoding.Simple;

public class UnionMemberEncoderTests
  : EncoderClassTestBase<UnionMemberModel>
{
  protected override IEncoder<UnionMemberModel> Encoder { get; }
    = new UnionMemberEncoder();

  [Theory, RepeatData]
  public void Encode_WithValidModel_ReturnsStructured(string name, string ofUnion, string contents)
    => EncodeAndCheck(new(name, ofUnion, contents), [
      "!_UnionMember",
      "description: " + contents.QuotedIdentifier(),
      "name: " + name,
      "union: " + ofUnion
      ]);
}

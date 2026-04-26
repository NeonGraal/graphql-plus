namespace GqlPlus.Encoding.Objects;

public class ObjectBaseEncoderTests
  : ObjectArgEncoderBase<ObjBaseModel>
{
  public ObjectBaseEncoderTests()
  {
    IEncoderRepository encoders = A.Of<IEncoderRepository>();
    encoders.EncoderFor<TypeArgModel>().Returns(TypeArg);
    Encoder = new ObjectBaseEncoder<ObjBaseModel>(encoders);
  }

  protected override IEncoder<ObjBaseModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithTypeParam_ReturnsStructuredWithTypeParam(string dual, string contents)
    => EncodeAndCheck(new(dual, contents) { IsTypeParam = true },
      TagAll("_ObjBase",
      ":description=" + contents.QuotedIdentifier(),
      ":typeParam=" + dual));

  [Theory, RepeatData]
  public void Encode_WithoutTypeParam_ReturnsStructuredWithDual(string dual, string contents)
    => EncodeAndCheck(new(dual, contents),
      TagAll("_ObjBase",
      ":description=" + contents.QuotedIdentifier(),
      ":name=" + dual));
}

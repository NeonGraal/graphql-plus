namespace GqlPlus.Encoding.Objects;

public class DualFieldEncoderTests
  : ObjectBaseEncoderBase<DualFieldModel, ObjBaseModel>
{
  private readonly IEncoder<ModifierModel> _modifer;

  public DualFieldEncoderTests()
  {
    _modifer = RFor<ModifierModel>();
    IEncoderRepository encoders = A.Of<IEncoderRepository>();
    encoders.EncoderForReturns(_modifer);
    encoders.EncoderForReturns(ObjBase);
    Encoder = new DualFieldEncoder(encoders);
  }

  protected override IEncoder<DualFieldModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithValidModel_ReturnsStructured(string name, string dual, string contents)
  {
    // Arrange
    ObjBaseModel dualBase = new(dual, "");
    ObjBase.Encode(dualBase).Returns(dual.Encode());

    // Act & Accept
    EncodeAndCheck(new(name, dualBase, contents),
      TagAll("_DualField",
      ":description=" + contents.QuotedIdentifier(),
      ":name=" + name,
      ":type=" + dual));
  }
}

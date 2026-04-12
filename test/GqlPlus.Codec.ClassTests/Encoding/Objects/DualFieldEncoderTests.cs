namespace GqlPlus.Encoding.Objects;

public class DualFieldEncoderTests
  : ObjectBaseEncoderBase<DualFieldModel, ObjBaseModel>
{
  private readonly IEncoder<ModifierModel> _modifer;

  public DualFieldEncoderTests()
  {
    _modifer = RFor<ModifierModel>();
    IEncoderRepository encoders = A.Of<IEncoderRepository>();
    encoders.EncoderFor<ModifierModel>().Returns(_modifer);
    encoders.EncoderFor<ObjBaseModel>().Returns(ObjBase);
    Encoder = new DualFieldEncoder(encoders);
  }

  protected override IEncoder<DualFieldModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithValidModel_ReturnsStructured(string name, string dual, string contents)
  {
    // Arrange
    ObjBaseModel dualBase = new(dual, "");
    ObjBase.Encode(dualBase).Returns(new Structured(dual));

    // Act & Accept
    EncodeAndCheck(new(name, dualBase, contents),
      TagAll("_DualField",
      ":description=" + contents.QuotedIdentifier(),
      ":name=" + name,
      ":type=" + dual));
  }
}

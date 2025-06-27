namespace GqlPlus.Encoding.Objects;

public class DualFieldEncoderTests
  : ObjectBaseEncoderBase<DualFieldModel, DualBaseModel>
{
  private readonly IEncoder<ModifierModel> _modifer;

  public DualFieldEncoderTests()
  {
    _modifer = RFor<ModifierModel>();

    Encoder = new DualFieldEncoder(new(_modifer, ObjBase));
  }

  protected override IEncoder<DualFieldModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithValidModel_ReturnsStructured(string name, string dual, string contents)
  {
    // Arrange
    DualBaseModel dualBase = new(dual, "");
    ObjBase.Encode(dualBase).Returns(new Structured(dual));

    // Act & Accept
    EncodeAndCheck(new(name, dualBase, contents), [
      "!_DualField",
      "description: " + contents.Quoted("'"),
      "name: " + name,
      "type: " + dual
      ]);
  }
}

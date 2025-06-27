namespace GqlPlus.Encoding.Objects;

public class InputFieldEncoderTests
  : ObjectBaseEncoderBase<InputFieldModel, InputBaseModel>
{
  private readonly IEncoder<ModifierModel> _modifer;
  private readonly IEncoder<ConstantModel> _constant;

  public InputFieldEncoderTests()
  {
    _modifer = RFor<ModifierModel>();
    _constant = RFor<ConstantModel>();

    Encoder = new InputFieldEncoder(_constant, new(_modifer, ObjBase));
  }

  protected override IEncoder<InputFieldModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithValidModel_ReturnsStructured(string name, string input, string contents)
  {
    // Arrange
    InputBaseModel inputBase = new(input, "");
    ObjBase.Encode(inputBase).Returns(new Structured(input));

    // Act & Accept
    EncodeAndCheck(new(name, inputBase, contents), [
      "!_InputField",
      "description: " + contents.Quoted("'"),
      "name: " + name,
      "type: " + input
      ]);
  }
}

namespace GqlPlus.Encoding;

public class OperationsEncoderTests
  : EncoderClassTestBase<OperationsModel>
{
  private readonly IEncoder<OperationModel> _operation;
  private readonly IEncoder<BaseTypeModel> _type;

  public OperationsEncoderTests()
  {
    _operation = RFor<OperationModel>();
    _type = RFor<BaseTypeModel>();
    IEncoderRepository encoders = A.Of<IEncoderRepository>();
    encoders.EncoderForReturns(_operation);
    encoders.EncoderForReturns(_type);
    Encoder = new OperationsEncoder(encoders);
  }

  protected override IEncoder<OperationsModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithValidOperationsModel_ReturnsStructured(string name, string opName)
  {
    // Arrange
    BaseTypeModel type = new TypeInputModel(name, string.Empty);
    OperationModel operation = new(opName, "query", string.Empty);
    _type.Encode(type).Returns(name.Encode("Input"));
    _operation.Encode(operation).Returns(opName.Encode("Operation"));

    // Act
    EncodeAndCheck(new() {
      Type = type,
      And = operation
    }, TagAll("_Operations",
        ":operation=[Operation]" + opName,
        ":type=[Input]" + name));
  }
}

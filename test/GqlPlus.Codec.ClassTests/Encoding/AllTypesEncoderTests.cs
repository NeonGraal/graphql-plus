namespace GqlPlus.Encoding;

public class AllTypesEncoderTests
  : EncoderClassTestBase<BaseTypeModel>
{
  private readonly ITypeEncoder _typeEncoder;

  public AllTypesEncoderTests()
  {
    _typeEncoder = A.Of<ITypeEncoder>();
    Encoder = new AllTypesEncoder([_typeEncoder]);
  }

  protected override IEncoder<BaseTypeModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithMatchingTypeEncoder_ReturnsStructured(string type)
  {
    // Arrange
    SpecialTypeModel model = new(type, "");
    _typeEncoder.ForType(model).Returns(true);
    Structured expectedStructured = new(type);
    _typeEncoder.TypeEncode(model).Returns(expectedStructured);

    // Act
    EncodeAndCheck(model, [type]);
  }

  [Fact]
  public void Encode_WithNoMatchingTypeEncoder_ThrowsInvalidOperationException()
  {
    // Arrange
    SpecialTypeModel model = new("", "");
    _typeEncoder.ForType(model).Returns(false);

    // Act
    void Result() => Encoder.Encode(model);

    // Assert
    Should.Throw<InvalidOperationException>(Result)
        .Message.ShouldContain("Unable to find Encoder for");
  }
}

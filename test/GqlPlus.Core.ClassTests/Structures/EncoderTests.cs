namespace GqlPlus.Structures;

public class EncoderTests
  : SubstituteBase
{
  [Theory, RepeatData]
  public void Encode_WhenCalled_DelegatesToValue(string input)
  {
    IEncoder<string> inner = A.Of<IEncoder<string>>();
    Structured encoded = input.Encode();
    inner.Encode(input).Returns(encoded);

    Encoder<string> encoder = new(() => inner);

    Structured result = encoder.Encode(input);

    result.ShouldBe(encoded);
  }

  [Theory, RepeatData]
  public void ImplicitConvert_FromDelegate_ReturnsEncoder(string input)
  {
    IEncoder<string> inner = A.Of<IEncoder<string>>();
    Structured encoded = input.Encode();
    inner.Encode(input).Returns(encoded);

    Encoder<string>.D factory = () => inner;
    Encoder<string> result = factory;

    result.Encode(input).ShouldBe(encoded);
  }

  [Fact]
  public void ImplicitConvert_NullFactory_ThrowsArgumentNullException()
  {
    Encoder<string>.D? factory = null;

    Action result = () => _ = (Encoder<string>)factory!;

    result.ShouldThrow<ArgumentNullException>();
  }
}

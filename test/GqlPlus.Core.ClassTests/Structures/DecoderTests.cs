using GqlPlus.Structures;

namespace GqlPlus.Structures;

public class DecoderTests
  : SubstituteBase
{
  [Theory, RepeatData]
  public void Decode_WhenCalled_DelegatesToValue(string output)
  {
    IDecoder<string> inner = A.Of<IDecoder<string>>();
    IMessages messages = A.Of<IMessages>();
    string? dummy;
    inner.Decode(Arg.Any<IValue>(), out dummy).ReturnsForAnyArgs(x => {
      x[1] = output;
      return messages;
    });

    Decoder<string> decoder = new(() => inner);

    IMessages result = decoder.Decode(A.Of<IValue>(), out string? decoded);

    result.ShouldBeSameAs(messages);
    decoded.ShouldBe(output);
  }

  [Theory, RepeatData]
  public void ImplicitConvert_FromDelegate_ReturnsDecoder(string output)
  {
    IDecoder<string> inner = A.Of<IDecoder<string>>();
    IMessages messages = A.Of<IMessages>();
    string? dummy;
    inner.Decode(Arg.Any<IValue>(), out dummy).ReturnsForAnyArgs(x => {
      x[1] = output;
      return messages;
    });

    Decoder<string>.D factory = () => inner;
    Decoder<string> result = factory;

    result.Decode(A.Of<IValue>(), out string? decoded).ShouldBeSameAs(messages);
    decoded.ShouldBe(output);
  }

  [Fact]
  public void ImplicitConvert_NullFactory_ThrowsArgumentNullException()
  {
    Decoder<string>.D? factory = null;

    Action result = () => _ = (Decoder<string>)factory!;

    result.ShouldThrow<ArgumentNullException>();
  }
}

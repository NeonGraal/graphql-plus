//HintName: test_output-parent-generic_Enc.gen.cs
// Generated from {CurrentDirectory}output-parent-generic.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_parent_generic;

internal class testOutpPrntGnrcEncoder : IEncoder<ItestOutpPrntGnrcObject>
{
  public Structured Encode(ItestOutpPrntGnrcObject input)
    => Structured.Empty();
}

internal class testRefOutpPrntGnrcEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefOutpPrntGnrcObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestRefOutpPrntGnrcObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumOutpPrntGnrcEncoder : IEncoder<testEnumOutpPrntGnrc>
{
  public Structured Encode(testEnumOutpPrntGnrc input)
    => new(input.ToString(), "_EnumOutpPrntGnrc");
}

internal class testPrntOutpPrntGnrcEncoder : IEncoder<testPrntOutpPrntGnrc>
{
  public Structured Encode(testPrntOutpPrntGnrc input)
    => new(input.ToString(), "_PrntOutpPrntGnrc");
}

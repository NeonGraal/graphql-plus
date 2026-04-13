//HintName: test_parent-alt+Output_Enc.gen.cs
// Generated from {CurrentDirectory}parent-alt+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_alt_Output;

internal class testPrntAltOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntAltOutpObject>
{
  private readonly IEncoder<ItestRefPrntAltOutpObject> _itestRefPrntAltOutp = encoders.EncoderFor<ItestRefPrntAltOutpObject>();
  public Structured Encode(ItestPrntAltOutpObject input)
    => _itestRefPrntAltOutp.Encode(input);
}

internal class testRefPrntAltOutpEncoder : IEncoder<ItestRefPrntAltOutpObject>
{
  public Structured Encode(ItestRefPrntAltOutpObject input)
    => Structured.Empty()
      .Add("parent", input.Parent);
}

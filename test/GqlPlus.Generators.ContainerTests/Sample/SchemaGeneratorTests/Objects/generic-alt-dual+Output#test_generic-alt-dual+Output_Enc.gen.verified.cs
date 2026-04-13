//HintName: test_generic-alt-dual+Output_Enc.gen.cs
// Generated from {CurrentDirectory}generic-alt-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Output;

internal class testGnrcAltDualOutpEncoder : IEncoder<ItestGnrcAltDualOutpObject>
{
  public Structured Encode(ItestGnrcAltDualOutpObject input)
    => Structured.Empty();
}

internal class testRefGnrcAltDualOutpEncoder : IEncoder<ItestRefGnrcAltDualOutpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltDualOutpObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcAltDualOutpEncoder : IEncoder<ItestAltGnrcAltDualOutpObject>
{
  public Structured Encode(ItestAltGnrcAltDualOutpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);
}

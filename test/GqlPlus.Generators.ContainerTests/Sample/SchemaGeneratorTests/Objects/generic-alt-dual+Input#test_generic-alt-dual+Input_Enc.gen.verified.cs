//HintName: test_generic-alt-dual+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-alt-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Input;

internal class testGnrcAltDualInpEncoder : IEncoder<ItestGnrcAltDualInpObject>
{
  public Structured Encode(ItestGnrcAltDualInpObject input)
    => Structured.Empty();
}

internal class testRefGnrcAltDualInpEncoder : IEncoder<ItestRefGnrcAltDualInpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltDualInpObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcAltDualInpEncoder : IEncoder<ItestAltGnrcAltDualInpObject>
{
  public Structured Encode(ItestAltGnrcAltDualInpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);
}

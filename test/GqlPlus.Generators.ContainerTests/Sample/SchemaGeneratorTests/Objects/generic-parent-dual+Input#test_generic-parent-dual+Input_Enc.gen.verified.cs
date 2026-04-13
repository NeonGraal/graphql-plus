//HintName: test_generic-parent-dual+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_Input;

internal class testGnrcPrntDualInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntDualInpObject>
{
  private readonly IEncoder<ItestRefGnrcPrntDualInpObject<ItestAltGnrcPrntDualInp>> _itestRefGnrcPrntDualInp = encoders.EncoderFor<ItestRefGnrcPrntDualInpObject<ItestAltGnrcPrntDualInp>>();
  public Structured Encode(ItestGnrcPrntDualInpObject input)
    => _itestRefGnrcPrntDualInp.Encode(input);
}

internal class testRefGnrcPrntDualInpEncoder<TRef> : IEncoder<ItestRefGnrcPrntDualInpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcPrntDualInpObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcPrntDualInpEncoder : IEncoder<ItestAltGnrcPrntDualInpObject>
{
  public Structured Encode(ItestAltGnrcPrntDualInpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);
}

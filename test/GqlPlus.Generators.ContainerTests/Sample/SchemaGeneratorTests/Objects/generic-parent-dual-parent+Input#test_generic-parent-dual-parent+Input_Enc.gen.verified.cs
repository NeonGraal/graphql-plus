//HintName: test_generic-parent-dual-parent+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-dual-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_parent_Input;

internal class testGnrcPrntDualPrntInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntDualPrntInpObject>
{
  private readonly IEncoder<ItestRefGnrcPrntDualPrntInpObject<ItestAltGnrcPrntDualPrntInp>> _itestRefGnrcPrntDualPrntInpObject<ItestAltGnrcPrntDualPrntInp> = encoders.EncoderFor<ItestRefGnrcPrntDualPrntInpObject<ItestAltGnrcPrntDualPrntInp>>();
  public Structured Encode(ItestGnrcPrntDualPrntInpObject input)
    => _itestRefGnrcPrntDualPrntInpObject<ItestAltGnrcPrntDualPrntInp>.Encode(input);
}

internal class testRefGnrcPrntDualPrntInpEncoder : IEncoder<ItestRefGnrcPrntDualPrntInpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcPrntDualPrntInpObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcPrntDualPrntInpEncoder : IEncoder<ItestAltGnrcPrntDualPrntInpObject>
{
  public Structured Encode(ItestAltGnrcPrntDualPrntInpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);
}

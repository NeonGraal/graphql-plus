//HintName: test_generic-parent-param-parent+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-param-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_parent_Input;

internal class testGnrcPrntParamPrntInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntParamPrntInpObject>
{
  private readonly IEncoder<ItestRefGnrcPrntParamPrntInpObject<ItestAltGnrcPrntParamPrntInp>> _itestRefGnrcPrntParamPrntInp = encoders.EncoderFor<ItestRefGnrcPrntParamPrntInpObject<ItestAltGnrcPrntParamPrntInp>>();
  public Structured Encode(ItestGnrcPrntParamPrntInpObject input)
    => _itestRefGnrcPrntParamPrntInp.Encode(input);
}

internal class testRefGnrcPrntParamPrntInpEncoder<TRef> : IEncoder<ItestRefGnrcPrntParamPrntInpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcPrntParamPrntInpObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcPrntParamPrntInpEncoder : IEncoder<ItestAltGnrcPrntParamPrntInpObject>
{
  public Structured Encode(ItestAltGnrcPrntParamPrntInpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);
}

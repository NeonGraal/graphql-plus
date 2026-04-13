//HintName: test_generic-parent-param-parent+Output_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-param-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_parent_Output;

internal class testGnrcPrntParamPrntOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntParamPrntOutpObject>
{
  private readonly IEncoder<ItestRefGnrcPrntParamPrntOutpObject<ItestAltGnrcPrntParamPrntOutp>> _itestRefGnrcPrntParamPrntOutp = encoders.EncoderFor<ItestRefGnrcPrntParamPrntOutpObject<ItestAltGnrcPrntParamPrntOutp>>();
  public Structured Encode(ItestGnrcPrntParamPrntOutpObject input)
    => _itestRefGnrcPrntParamPrntOutp.Encode(input);
}

internal class testRefGnrcPrntParamPrntOutpEncoder<TRef> : IEncoder<ItestRefGnrcPrntParamPrntOutpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcPrntParamPrntOutpObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcPrntParamPrntOutpEncoder : IEncoder<ItestAltGnrcPrntParamPrntOutpObject>
{
  public Structured Encode(ItestAltGnrcPrntParamPrntOutpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);
}

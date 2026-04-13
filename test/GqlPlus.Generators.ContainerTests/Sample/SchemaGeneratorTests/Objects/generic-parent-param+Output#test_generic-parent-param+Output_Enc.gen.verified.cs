//HintName: test_generic-parent-param+Output_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-param+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_Output;

internal class testGnrcPrntParamOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntParamOutpObject>
{
  private readonly IEncoder<ItestRefGnrcPrntParamOutpObject<ItestAltGnrcPrntParamOutp>> _itestRefGnrcPrntParamOutpObject<ItestAltGnrcPrntParamOutp> = encoders.EncoderFor<ItestRefGnrcPrntParamOutpObject<ItestAltGnrcPrntParamOutp>>();
  public Structured Encode(ItestGnrcPrntParamOutpObject input)
    => _itestRefGnrcPrntParamOutpObject<ItestAltGnrcPrntParamOutp>.Encode(input);
}

internal class testRefGnrcPrntParamOutpEncoder : IEncoder<ItestRefGnrcPrntParamOutpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcPrntParamOutpObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcPrntParamOutpEncoder : IEncoder<ItestAltGnrcPrntParamOutpObject>
{
  public Structured Encode(ItestAltGnrcPrntParamOutpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);
}

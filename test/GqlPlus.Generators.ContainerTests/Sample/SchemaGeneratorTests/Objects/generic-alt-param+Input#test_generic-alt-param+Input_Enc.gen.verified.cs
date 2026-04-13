//HintName: test_generic-alt-param+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-alt-param+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Input;

internal class testGnrcAltParamInpEncoder : IEncoder<ItestGnrcAltParamInpObject>
{
  public Structured Encode(ItestGnrcAltParamInpObject input)
    => Structured.Empty();
}

internal class testRefGnrcAltParamInpEncoder : IEncoder<ItestRefGnrcAltParamInpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltParamInpObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcAltParamInpEncoder : IEncoder<ItestAltGnrcAltParamInpObject>
{
  public Structured Encode(ItestAltGnrcAltParamInpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);
}

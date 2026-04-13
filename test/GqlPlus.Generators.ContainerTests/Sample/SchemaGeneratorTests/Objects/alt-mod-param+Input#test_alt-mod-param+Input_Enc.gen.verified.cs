//HintName: test_alt-mod-param+Input_Enc.gen.cs
// Generated from {CurrentDirectory}alt-mod-param+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_param_Input;

internal class testAltModParamInpEncoder<TMod> : IEncoder<ItestAltModParamInpObject<TMod>>
{
  public Structured Encode(ItestAltModParamInpObject<TMod> input)
    => Structured.Empty();
}

internal class testAltAltModParamInpEncoder : IEncoder<ItestAltAltModParamInpObject>
{
  public Structured Encode(ItestAltAltModParamInpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);
}

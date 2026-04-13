//HintName: test_field-mod-param+Input_Enc.gen.cs
// Generated from {CurrentDirectory}field-mod-param+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_param_Input;

internal class testFieldModParamInpEncoder : IEncoder<ItestFieldModParamInpObject<TMod>>
{
  public Structured Encode(ItestFieldModParamInpObject<TMod> input)
    => Structured.Empty();
}

internal class testFldFieldModParamInpEncoder : IEncoder<ItestFldFieldModParamInpObject>
{
  public Structured Encode(ItestFldFieldModParamInpObject input)
    => Structured.Empty()
      .Add("field", input.Field);
}

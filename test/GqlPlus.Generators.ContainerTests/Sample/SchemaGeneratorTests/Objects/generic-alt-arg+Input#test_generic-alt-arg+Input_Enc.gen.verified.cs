//HintName: test_generic-alt-arg+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-alt-arg+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_Input;

internal class testGnrcAltArgInpEncoder : IEncoder<ItestGnrcAltArgInpObject<TType>>
{
  public Structured Encode(ItestGnrcAltArgInpObject<TType> input)
    => Structured.Empty();
}

internal class testRefGnrcAltArgInpEncoder : IEncoder<ItestRefGnrcAltArgInpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltArgInpObject<TRef> input)
    => Structured.Empty();
}

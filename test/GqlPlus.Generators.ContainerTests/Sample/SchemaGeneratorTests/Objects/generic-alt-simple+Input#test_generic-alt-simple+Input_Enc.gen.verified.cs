//HintName: test_generic-alt-simple+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-alt-simple+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_simple_Input;

internal class testGnrcAltSmplInpEncoder : IEncoder<ItestGnrcAltSmplInpObject>
{
  public Structured Encode(ItestGnrcAltSmplInpObject input)
    => Structured.Empty();
}

internal class testRefGnrcAltSmplInpEncoder : IEncoder<ItestRefGnrcAltSmplInpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltSmplInpObject<TRef> input)
    => Structured.Empty();
}

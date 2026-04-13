//HintName: test_generic-alt-arg+Output_Enc.gen.cs
// Generated from {CurrentDirectory}generic-alt-arg+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_Output;

internal class testGnrcAltArgOutpEncoder : IEncoder<ItestGnrcAltArgOutpObject<TType>>
{
  public Structured Encode(ItestGnrcAltArgOutpObject<TType> input)
    => Structured.Empty();
}

internal class testRefGnrcAltArgOutpEncoder : IEncoder<ItestRefGnrcAltArgOutpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltArgOutpObject<TRef> input)
    => Structured.Empty();
}

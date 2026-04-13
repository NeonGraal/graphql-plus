//HintName: test_generic-alt-arg+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}generic-alt-arg+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_Dual;

internal class testGnrcAltArgDualEncoder : IEncoder<ItestGnrcAltArgDualObject<TType>>
{
  public Structured Encode(ItestGnrcAltArgDualObject<TType> input)
    => Structured.Empty();
}

internal class testRefGnrcAltArgDualEncoder : IEncoder<ItestRefGnrcAltArgDualObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltArgDualObject<TRef> input)
    => Structured.Empty();
}

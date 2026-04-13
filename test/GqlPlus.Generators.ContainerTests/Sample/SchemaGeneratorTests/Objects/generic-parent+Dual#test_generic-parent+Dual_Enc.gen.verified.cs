//HintName: test_generic-parent+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_Dual;

internal class testGnrcPrntDualEncoder<TType> : IEncoder<ItestGnrcPrntDualObject<TType>>
{
  public Structured Encode(ItestGnrcPrntDualObject<TType> input)
    => Structured.Empty();
}

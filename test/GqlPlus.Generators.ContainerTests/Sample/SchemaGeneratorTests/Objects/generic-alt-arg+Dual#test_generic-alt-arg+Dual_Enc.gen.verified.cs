//HintName: test_generic-alt-arg+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}generic-alt-arg+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_Dual;

internal class testGnrcAltArgDualEncoder<TType> : IEncoder<ItestGnrcAltArgDualObject<TType>>
{
  public IGqlpValue Encode(ItestGnrcAltArgDualObject<TType> input)
    => new GqlpUnit();
}

internal class testRefGnrcAltArgDualEncoder<TRef> : IEncoder<ItestRefGnrcAltArgDualObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcAltArgDualObject<TRef> input)
    => new GqlpUnit();
}

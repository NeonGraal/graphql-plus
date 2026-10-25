//HintName: test_generic-alt-arg-descr+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}generic-alt-arg-descr+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_descr_Dual;

internal class testGnrcAltArgDescrDualEncoder<TType> : IEncoder<ItestGnrcAltArgDescrDualObject<TType>>
{
  public IGqlpValue Encode(ItestGnrcAltArgDescrDualObject<TType> input)
    => new GqlpUnit();
}

internal class testRefGnrcAltArgDescrDualEncoder<TRef> : IEncoder<ItestRefGnrcAltArgDescrDualObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcAltArgDescrDualObject<TRef> input)
    => new GqlpUnit();
}

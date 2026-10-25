//HintName: test_generic-alt-arg-descr+Output_Enc.gen.cs
// Generated from {CurrentDirectory}generic-alt-arg-descr+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_descr_Output;

internal class testGnrcAltArgDescrOutpEncoder<TType> : IEncoder<ItestGnrcAltArgDescrOutpObject<TType>>
{
  public IGqlpValue Encode(ItestGnrcAltArgDescrOutpObject<TType> input)
    => new GqlpUnit();
}

internal class testRefGnrcAltArgDescrOutpEncoder<TRef> : IEncoder<ItestRefGnrcAltArgDescrOutpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcAltArgDescrOutpObject<TRef> input)
    => new GqlpUnit();
}

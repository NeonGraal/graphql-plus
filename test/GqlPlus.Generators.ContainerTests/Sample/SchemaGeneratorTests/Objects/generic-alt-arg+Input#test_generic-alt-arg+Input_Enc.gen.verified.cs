//HintName: test_generic-alt-arg+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-alt-arg+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_Input;

internal class testGnrcAltArgInpEncoder<TType> : IEncoder<ItestGnrcAltArgInpObject<TType>>
{
  public IGqlpValue Encode(ItestGnrcAltArgInpObject<TType> input)
    => new GqlpUnit();
}

internal class testRefGnrcAltArgInpEncoder<TRef> : IEncoder<ItestRefGnrcAltArgInpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcAltArgInpObject<TRef> input)
    => new GqlpUnit();
}

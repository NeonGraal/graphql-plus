//HintName: test_generic-alt+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-alt+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_Input;

internal class testGnrcAltInpEncoder<TType> : IEncoder<ItestGnrcAltInpObject<TType>>
{
  public Structured Encode(ItestGnrcAltInpObject<TType> input)
    => Structured.Empty();
}

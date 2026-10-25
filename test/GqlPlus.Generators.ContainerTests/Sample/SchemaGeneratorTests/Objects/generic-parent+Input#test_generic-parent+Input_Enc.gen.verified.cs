//HintName: test_generic-parent+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_Input;

internal class testGnrcPrntInpEncoder<TType> : IEncoder<ItestGnrcPrntInpObject<TType>>
{
  public IGqlpValue Encode(ItestGnrcPrntInpObject<TType> input)
    => new GqlpUnit();
}

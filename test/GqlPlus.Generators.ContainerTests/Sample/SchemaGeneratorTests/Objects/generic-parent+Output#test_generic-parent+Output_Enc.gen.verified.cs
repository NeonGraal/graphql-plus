//HintName: test_generic-parent+Output_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_Output;

internal class testGnrcPrntOutpEncoder<TType> : IEncoder<ItestGnrcPrntOutpObject<TType>>
{
  public Structured Encode(ItestGnrcPrntOutpObject<TType> input)
    => Structured.Empty();
}

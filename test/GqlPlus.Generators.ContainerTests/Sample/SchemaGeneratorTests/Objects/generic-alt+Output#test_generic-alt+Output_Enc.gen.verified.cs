//HintName: test_generic-alt+Output_Enc.gen.cs
// Generated from {CurrentDirectory}generic-alt+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_Output;

internal class testGnrcAltOutpEncoder<TType> : IEncoder<ItestGnrcAltOutpObject<TType>>
{
  public Structured Encode(ItestGnrcAltOutpObject<TType> input)
    => Structured.Empty();
}

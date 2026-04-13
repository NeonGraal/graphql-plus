//HintName: test_domain-boolean_Enc.gen.cs
// Generated from {CurrentDirectory}domain-boolean.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_boolean;

internal class testDmnBoolEncoder : IEncoder<ItestDmnBool>
{
  public Structured Encode(ItestDmnBool input)
    => new(input.Value);
}

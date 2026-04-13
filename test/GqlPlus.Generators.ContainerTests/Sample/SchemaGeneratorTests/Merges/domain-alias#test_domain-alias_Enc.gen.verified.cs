//HintName: test_domain-alias_Enc.gen.cs
// Generated from {CurrentDirectory}domain-alias.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_alias;

internal class testDmnAliasEncoder : IEncoder<ItestDmnAlias>
{
  public Structured Encode(ItestDmnAlias input)
    => new(input.Value);
}

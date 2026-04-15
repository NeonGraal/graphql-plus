//HintName: test_domain-string-same_Enc.gen.cs
// Generated from {CurrentDirectory}domain-string-same.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_string_same;

internal class testDmnStrSameEncoder : IEncoder<ItestDmnStrSame>
{
  public Structured Encode(ItestDmnStrSame input)
    => new(input.Value);
}

internal static class test_domain_string_sameEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_domain_string_sameEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDmnStrSame>(_ => new testDmnStrSameEncoder());
}

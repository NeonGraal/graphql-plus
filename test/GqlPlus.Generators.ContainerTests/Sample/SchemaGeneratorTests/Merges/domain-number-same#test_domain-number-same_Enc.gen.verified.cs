//HintName: test_domain-number-same_Enc.gen.cs
// Generated from {CurrentDirectory}domain-number-same.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_number_same;

internal class testDmnNmbrSameEncoder : IEncoder<ItestDmnNmbrSame>
{
  public Structured Encode(ItestDmnNmbrSame input)
    => new(input.Value);
}

internal static class test_domain_number_sameEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_domain_number_sameEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDmnNmbrSame>(_ => new testDmnNmbrSameEncoder());
}

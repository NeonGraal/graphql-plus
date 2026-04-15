//HintName: test_domain-number-positive_Enc.gen.cs
// Generated from {CurrentDirectory}domain-number-positive.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_number_positive;

internal class testDmnNmbrPstvEncoder : IEncoder<ItestDmnNmbrPstv>
{
  public Structured Encode(ItestDmnNmbrPstv input)
    => new(input.Value);
}

internal static class test_domain_number_positiveEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_domain_number_positiveEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDmnNmbrPstv>(_ => new testDmnNmbrPstvEncoder());
}

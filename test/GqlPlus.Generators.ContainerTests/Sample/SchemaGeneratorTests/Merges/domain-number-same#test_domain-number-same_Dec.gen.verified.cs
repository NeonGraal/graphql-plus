//HintName: test_domain-number-same_Dec.gen.cs
// Generated from {CurrentDirectory}domain-number-same.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_number_same;

internal class testDmnNmbrSameDecoder
{
}

internal static class test_domain_number_sameDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_number_sameDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnNmbrSame>(_ => new testDmnNmbrSameDecoder());
}

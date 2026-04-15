//HintName: test_domain-string-same_Dec.gen.cs
// Generated from {CurrentDirectory}domain-string-same.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_string_same;

internal class testDmnStrSameDecoder
{
}

internal static class test_domain_string_sameDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_string_sameDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnStrSame>(_ => new testDmnStrSameDecoder());
}

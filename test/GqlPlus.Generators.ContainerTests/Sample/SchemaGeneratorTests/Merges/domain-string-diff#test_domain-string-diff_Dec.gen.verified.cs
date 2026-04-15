//HintName: test_domain-string-diff_Dec.gen.cs
// Generated from {CurrentDirectory}domain-string-diff.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_string_diff;

internal class testDmnStrDiffDecoder
{
}

internal static class test_domain_string_diffDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_string_diffDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnStrDiff>(_ => new testDmnStrDiffDecoder());
}

//HintName: test_domain-boolean-diff_Dec.gen.cs
// Generated from {CurrentDirectory}domain-boolean-diff.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_boolean_diff;

internal class testDmnBoolDiffDecoder
{
}

internal static class test_domain_boolean_diffDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_boolean_diffDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnBoolDiff>(_ => new testDmnBoolDiffDecoder());
}

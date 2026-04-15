//HintName: test_domain-enum-diff_Dec.gen.cs
// Generated from {CurrentDirectory}domain-enum-diff.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_diff;

internal class testDmnEnumDiffDecoder
{
}

internal static class test_domain_enum_diffDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_enum_diffDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnEnumDiff>(_ => new testDmnEnumDiffDecoder());
}

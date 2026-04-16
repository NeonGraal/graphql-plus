//HintName: test_domain-number-diff_Dec.gen.cs
// Generated from {CurrentDirectory}domain-number-diff.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_number_diff;

internal class testDmnNmbrDiffDecoder
{

  internal static testDmnNmbrDiffDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_domain_number_diffDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_number_diffDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnNmbrDiff>(testDmnNmbrDiffDecoder.Factory);
}

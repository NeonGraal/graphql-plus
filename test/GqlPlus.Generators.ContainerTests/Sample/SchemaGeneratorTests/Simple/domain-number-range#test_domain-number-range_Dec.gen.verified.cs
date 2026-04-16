//HintName: test_domain-number-range_Dec.gen.cs
// Generated from {CurrentDirectory}domain-number-range.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_number_range;

internal class testDmnNmbrRangeDecoder
{

  internal static testDmnNmbrRangeDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_domain_number_rangeDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_number_rangeDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnNmbrRange>(testDmnNmbrRangeDecoder.Factory);
}

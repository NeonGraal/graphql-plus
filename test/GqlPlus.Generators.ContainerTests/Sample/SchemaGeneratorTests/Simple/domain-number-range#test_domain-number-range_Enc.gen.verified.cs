//HintName: test_domain-number-range_Enc.gen.cs
// Generated from {CurrentDirectory}domain-number-range.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_number_range;

internal class testDmnNmbrRangeEncoder : IEncoder<ItestDmnNmbrRange>
{
  public Structured Encode(ItestDmnNmbrRange input)
    => new(input.Value);

  internal static testDmnNmbrRangeEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_domain_number_rangeEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_domain_number_rangeEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDmnNmbrRange>(testDmnNmbrRangeEncoder.Factory);
}

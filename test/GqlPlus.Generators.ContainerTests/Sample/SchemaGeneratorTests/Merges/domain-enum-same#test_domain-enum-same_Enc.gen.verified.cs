//HintName: test_domain-enum-same_Enc.gen.cs
// Generated from {CurrentDirectory}domain-enum-same.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_same;

internal class testDmnEnumSameEncoder : IEncoder<ItestDmnEnumSame>
{
  public Structured Encode(ItestDmnEnumSame input)
    => new((decimal?)input.Value);
}

internal static class test_domain_enum_sameEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_domain_enum_sameEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDmnEnumSame>(_ => new testDmnEnumSameEncoder());
}

//HintName: test_domain-enum-all_Enc.gen.cs
// Generated from {CurrentDirectory}domain-enum-all.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_all;

internal class testDmnEnumAllEncoder : IEncoder<ItestDmnEnumAll>
{
  public Structured Encode(ItestDmnEnumAll input)
    => new((decimal?)input.Value);
}

internal class testEnumDmnEnumAllEncoder : IEncoder<testEnumDmnEnumAll>
{
  public Structured Encode(testEnumDmnEnumAll input)
    => new(input.ToString(), "_EnumDmnEnumAll");
}

internal static class test_domain_enum_allEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_domain_enum_allEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDmnEnumAll>(_ => new testDmnEnumAllEncoder())
      .AddEncoder<testEnumDmnEnumAll>(_ => new testEnumDmnEnumAllEncoder());
}

//HintName: test_domain-enum-all_Dec.gen.cs
// Generated from {CurrentDirectory}domain-enum-all.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_all;

internal class testDmnEnumAllDecoder
{

  internal static testDmnEnumAllDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumAllDecoder
{
  public string dmnEnumAll { get; set; }
  public string enum_dmnEnumAll { get; set; }
  public string dmnEnumAllValue { get; set; }

  internal static testEnumDmnEnumAllDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_domain_enum_allDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_enum_allDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnEnumAll>(testDmnEnumAllDecoder.Factory)
      .AddDecoder<testEnumDmnEnumAll>(testEnumDmnEnumAllDecoder.Factory);
}

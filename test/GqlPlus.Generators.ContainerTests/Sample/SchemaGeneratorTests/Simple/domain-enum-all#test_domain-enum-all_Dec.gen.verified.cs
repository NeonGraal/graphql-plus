//HintName: test_domain-enum-all_Dec.gen.cs
// Generated from {CurrentDirectory}domain-enum-all.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_all;

internal class testDmnEnumAllDecoder : NullDecoder<ItestDmnEnumAll>
{

  internal static testDmnEnumAllDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumAllDecoder : NullDecoder<testEnumDmnEnumAll>
{
  public string dmnEnumAll { get; set; } = default!;
  public string enum_dmnEnumAll { get; set; } = default!;
  public string dmnEnumAllValue { get; set; } = default!;

  internal static testEnumDmnEnumAllDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_domain_enum_allDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_enum_allDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnEnumAll>(testDmnEnumAllDecoder.Factory)
      .AddDecoder<testEnumDmnEnumAll>(testEnumDmnEnumAllDecoder.Factory);
}

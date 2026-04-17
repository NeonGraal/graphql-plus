//HintName: test_domain-enum-exclude_Dec.gen.cs
// Generated from {CurrentDirectory}domain-enum-exclude.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_exclude;

internal class testDmnEnumExclDecoder
{

  internal static testDmnEnumExclDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumExclDecoder
{
  public string dmnEnumExcl { get; set; }
  public string enum_dmnEnumExcl { get; set; }
  public string dmnEnumExclValue { get; set; }

  internal static testEnumDmnEnumExclDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_domain_enum_excludeDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_enum_excludeDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnEnumExcl>(testDmnEnumExclDecoder.Factory)
      .AddDecoder<testEnumDmnEnumExcl>(testEnumDmnEnumExclDecoder.Factory);
}

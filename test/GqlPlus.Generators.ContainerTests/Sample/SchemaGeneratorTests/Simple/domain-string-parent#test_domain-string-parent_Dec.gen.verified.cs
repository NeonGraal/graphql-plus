//HintName: test_domain-string-parent_Dec.gen.cs
// Generated from {CurrentDirectory}domain-string-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_string_parent;

internal class testDmnStrPrntDecoder
{

  internal static testDmnStrPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnStrPrntDecoder
{

  internal static testPrntDmnStrPrntDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_domain_string_parentDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_string_parentDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnStrPrnt>(testDmnStrPrntDecoder.Factory)
      .AddDecoder<ItestPrntDmnStrPrnt>(testPrntDmnStrPrntDecoder.Factory);
}

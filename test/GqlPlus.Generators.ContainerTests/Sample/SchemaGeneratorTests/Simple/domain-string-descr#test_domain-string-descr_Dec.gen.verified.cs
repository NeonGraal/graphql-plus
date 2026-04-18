//HintName: test_domain-string-descr_Dec.gen.cs
// Generated from {CurrentDirectory}domain-string-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_string_descr;

internal class testDmnStrDescrDecoder
{

  internal static testDmnStrDescrDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_domain_string_descrDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_string_descrDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnStrDescr>(testDmnStrDescrDecoder.Factory);
}

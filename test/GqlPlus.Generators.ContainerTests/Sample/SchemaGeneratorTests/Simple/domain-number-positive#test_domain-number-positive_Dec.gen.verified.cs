//HintName: test_domain-number-positive_Dec.gen.cs
// Generated from {CurrentDirectory}domain-number-positive.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_number_positive;

internal class testDmnNmbrPstvDecoder
{

  internal static testDmnNmbrPstvDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_domain_number_positiveDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_number_positiveDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnNmbrPstv>(testDmnNmbrPstvDecoder.Factory);
}

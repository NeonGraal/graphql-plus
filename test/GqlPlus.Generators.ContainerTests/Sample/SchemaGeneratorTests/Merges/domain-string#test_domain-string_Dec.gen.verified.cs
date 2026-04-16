//HintName: test_domain-string_Dec.gen.cs
// Generated from {CurrentDirectory}domain-string.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_string;

internal class testDmnStrDecoder
{

  internal static testDmnStrDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_domain_stringDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_stringDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnStr>(testDmnStrDecoder.Factory);
}

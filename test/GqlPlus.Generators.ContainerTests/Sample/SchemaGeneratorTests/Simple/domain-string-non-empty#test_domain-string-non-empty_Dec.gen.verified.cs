//HintName: test_domain-string-non-empty_Dec.gen.cs
// Generated from {CurrentDirectory}domain-string-non-empty.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_string_non_empty;

internal class testDmnStrNonEmptyDecoder
{
}

internal static class test_domain_string_non_emptyDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_string_non_emptyDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnStrNonEmpty>(_ => new testDmnStrNonEmptyDecoder());
}

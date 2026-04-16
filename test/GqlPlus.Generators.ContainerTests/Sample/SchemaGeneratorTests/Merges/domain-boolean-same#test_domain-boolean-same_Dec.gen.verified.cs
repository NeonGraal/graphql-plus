//HintName: test_domain-boolean-same_Dec.gen.cs
// Generated from {CurrentDirectory}domain-boolean-same.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_boolean_same;

internal class testDmnBoolSameDecoder
{

  internal static testDmnBoolSameDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_domain_boolean_sameDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_boolean_sameDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnBoolSame>(testDmnBoolSameDecoder.Factory);
}

//HintName: test_domain-number_Dec.gen.cs
// Generated from {CurrentDirectory}domain-number.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_number;

internal class testDmnNmbrDecoder
{

  internal static testDmnNmbrDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_domain_numberDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_numberDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnNmbr>(testDmnNmbrDecoder.Factory);
}

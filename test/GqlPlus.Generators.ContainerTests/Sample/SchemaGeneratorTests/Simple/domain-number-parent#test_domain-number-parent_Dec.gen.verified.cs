//HintName: test_domain-number-parent_Dec.gen.cs
// Generated from {CurrentDirectory}domain-number-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_number_parent;

internal class testDmnNmbrPrntDecoder
{

  internal static testDmnNmbrPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnNmbrPrntDecoder
{

  internal static testPrntDmnNmbrPrntDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_domain_number_parentDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_number_parentDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnNmbrPrnt>(testDmnNmbrPrntDecoder.Factory)
      .AddDecoder<ItestPrntDmnNmbrPrnt>(testPrntDmnNmbrPrntDecoder.Factory);
}

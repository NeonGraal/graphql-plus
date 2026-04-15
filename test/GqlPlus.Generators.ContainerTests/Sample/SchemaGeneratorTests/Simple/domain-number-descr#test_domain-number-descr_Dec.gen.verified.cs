//HintName: test_domain-number-descr_Dec.gen.cs
// Generated from {CurrentDirectory}domain-number-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_number_descr;

internal class testDmnNmbrDescrDecoder
{
}

internal static class test_domain_number_descrDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_number_descrDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnNmbrDescr>(_ => new testDmnNmbrDescrDecoder());
}

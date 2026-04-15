//HintName: test_domain-number-parent-descr_Dec.gen.cs
// Generated from {CurrentDirectory}domain-number-parent-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_number_parent_descr;

internal class testDmnNmbrPrntDescrDecoder
{
}

internal class testPrntDmnNmbrPrntDescrDecoder
{
}

internal static class test_domain_number_parent_descrDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_number_parent_descrDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnNmbrPrntDescr>(_ => new testDmnNmbrPrntDescrDecoder())
      .AddDecoder<ItestPrntDmnNmbrPrntDescr>(_ => new testPrntDmnNmbrPrntDescrDecoder());
}

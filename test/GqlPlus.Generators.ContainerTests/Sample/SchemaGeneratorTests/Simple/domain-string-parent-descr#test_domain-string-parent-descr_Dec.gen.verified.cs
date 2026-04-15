//HintName: test_domain-string-parent-descr_Dec.gen.cs
// Generated from {CurrentDirectory}domain-string-parent-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_string_parent_descr;

internal class testDmnStrPrntDescrDecoder
{
}

internal class testPrntDmnStrPrntDescrDecoder
{
}

internal static class test_domain_string_parent_descrDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_string_parent_descrDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnStrPrntDescr>(_ => new testDmnStrPrntDescrDecoder())
      .AddDecoder<ItestPrntDmnStrPrntDescr>(_ => new testPrntDmnStrPrntDescrDecoder());
}

//HintName: test_domain-bool-parent-descr_Dec.gen.cs
// Generated from {CurrentDirectory}domain-bool-parent-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_bool_parent_descr;

internal class testDmnBoolPrntDescrDecoder
{
}

internal class testPrntDmnBoolPrntDescrDecoder
{
}

internal static class test_domain_bool_parent_descrDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_bool_parent_descrDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnBoolPrntDescr>(_ => new testDmnBoolPrntDescrDecoder())
      .AddDecoder<ItestPrntDmnBoolPrntDescr>(_ => new testPrntDmnBoolPrntDescrDecoder());
}

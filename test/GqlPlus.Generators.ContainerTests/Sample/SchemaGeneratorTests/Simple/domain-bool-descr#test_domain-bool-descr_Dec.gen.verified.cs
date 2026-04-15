//HintName: test_domain-bool-descr_Dec.gen.cs
// Generated from {CurrentDirectory}domain-bool-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_bool_descr;

internal class testDmnBoolDescrDecoder
{
}

internal static class test_domain_bool_descrDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_bool_descrDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnBoolDescr>(_ => new testDmnBoolDescrDecoder());
}

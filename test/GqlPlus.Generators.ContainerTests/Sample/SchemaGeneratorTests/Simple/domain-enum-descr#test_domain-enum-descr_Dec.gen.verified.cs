//HintName: test_domain-enum-descr_Dec.gen.cs
// Generated from {CurrentDirectory}domain-enum-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_descr;

internal class testDmnEnumDescrDecoder
{
}

internal class testEnumDmnEnumDescrDecoder
{
  public string dmnEnumDescr { get; set; }
}

internal static class test_domain_enum_descrDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_enum_descrDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnEnumDescr>(_ => new testDmnEnumDescrDecoder())
      .AddDecoder<testEnumDmnEnumDescr>(_ => new testEnumDmnEnumDescrDecoder());
}
